import { Component } from '@angular/core';
import { Team } from 'src/app/models/team';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-teams-list',
  templateUrl: './teams-list.component.html',
  styleUrls: ['./teams-list.component.css']
})
export class TeamsListComponent {
    filter = "";
    teams: Team[] = [];

    constructor(private teamService: TeamService) {}
  
    ngOnInit () : void {
      this.teamService
        .getTeams()
        .subscribe((result: Team[]) => (this.teams = result.sort((a, b) => (a.name > b.name) ? 1 : -1)));
    }
}
