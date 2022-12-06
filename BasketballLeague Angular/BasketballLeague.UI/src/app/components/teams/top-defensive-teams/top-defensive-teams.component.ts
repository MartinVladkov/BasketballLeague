import { Component } from '@angular/core';
import { TopTeam } from 'src/app/models/top-team';
import { TopDefensiveTeamsService } from 'src/app/services/team.service';

@Component({
  selector: 'app-top-defensive-teams',
  templateUrl: './top-defensive-teams.component.html',
  styleUrls: ['./top-defensive-teams.component.css']
})
export class TopDefensiveTeamsComponent {
    topDefensiveTeams: TopTeam[] = [];

    constructor(private topDefensiveTeam: TopDefensiveTeamsService) {}
  
    ngOnInit () : void {
      this.topDefensiveTeam
        .getTopDefensiveTeams()
        .subscribe((result: TopTeam[]) => (this.topDefensiveTeams = result.slice(0, 5)));
    }
}
