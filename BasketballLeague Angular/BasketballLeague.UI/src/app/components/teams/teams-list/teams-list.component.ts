import { Component } from '@angular/core';
import { Team } from 'src/app/models/team';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-teams-list',
  templateUrl: './teams-list.component.html',
  styleUrls: ['./teams-list.component.css']
})
export class TeamsListComponent {
    teams: Team[] = [];

    constructor(private teamService: TeamService) {}
  
    ngOnInit () : void {
      this.teams = this.teamService.getTeams();
      console.log(this.teams);
    }
}
