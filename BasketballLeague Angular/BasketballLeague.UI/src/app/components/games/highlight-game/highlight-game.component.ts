import { Component } from '@angular/core';
import { Game } from 'src/app/models/game';
import { HighlightGameService } from 'src/app/services/games.service';

@Component({
  selector: 'app-highlight-game',
  templateUrl: './highlight-game.component.html',
  styleUrls: ['./highlight-game.component.css']
})
export class HighlightGameComponent {
    highlightGame?: Game
    constructor(private highlightGameService: HighlightGameService) {}
  
    ngOnInit () : void {
      this.highlightGameService
        .getHighlightGame()
        .subscribe((result: Game) => (this.highlightGame = result));
    }
}
