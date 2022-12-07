import { Component } from '@angular/core';
import { Team } from 'src/app/models/team';
import { TeamService } from 'src/app/services/team.service';
import { faSort } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-teams-list',
  templateUrl: './teams-list.component.html',
  styleUrls: ['./teams-list.component.css']
})
export class TeamsListComponent {
    faSort = faSort
    filter = "";
    teams: Team[] = [];

    constructor(private teamService: TeamService) {}
  
    ngOnInit () : void {
      this.teamService
        .getTeams()
        .subscribe((result: Team[]) => (this.teams = result.sort((a, b) => (a.name > b.name) ? 1 : -1)));
    }

    reverse: boolean = false;
    sort(name: String, order: boolean) {
        if (order == true){
            this.teams.sort((a, b) => a.name < b.name ? 1 : a.name > b.name ? -1 : 0)
            this.reverse = !this.reverse
        }
        else{
            this.teams.sort((a, b) => a.name > b.name ? 1 : a.name < b.name ? -1 : 0)
            this.reverse = !this.reverse
        }
    }
}
