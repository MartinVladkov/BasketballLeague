import { Component } from '@angular/core';
import { Game } from 'src/app/models/game';
import { GameService } from 'src/app/services/games.service';

@Component({
  selector: 'app-all-games',
  templateUrl: './all-games.component.html',
  styleUrls: ['./all-games.component.css']
})
export class AllGamesComponent {
    games: Game[] = [];
    constructor(private gamesService: GameService) {}
  
    ngOnInit () : void {
      this.gamesService
        .getGames()
        .subscribe((result: Game[]) => (this.games = result));
    }
}
