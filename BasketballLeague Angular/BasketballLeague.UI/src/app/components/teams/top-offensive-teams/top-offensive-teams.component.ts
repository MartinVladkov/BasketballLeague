import { Component } from '@angular/core';
import { TopTeam } from 'src/app/models/top-team';
import { TopOffensiveTeamsService } from 'src/app/services/team.service';

@Component({
  selector: 'app-top-offensive-teams',
  templateUrl: './top-offensive-teams.component.html',
  styleUrls: ['./top-offensive-teams.component.css']
})

export class TopOffensiveTeamsComponent {
    topOffensiveTeams: TopTeam[] = [];

    constructor(private topOffensiveTeam: TopOffensiveTeamsService) {}
  
    ngOnInit () : void {
      this.topOffensiveTeam
        .getTopOffensiveTeams()
        .subscribe((result: TopTeam[]) => (this.topOffensiveTeams = result.slice(0, 5)));
    }
}
