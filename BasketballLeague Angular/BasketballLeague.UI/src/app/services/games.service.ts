import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { Game } from '../models/game';


@Injectable({ providedIn: 'root'})
export class GameService {
    private url = "Game";  
    constructor(private http: HttpClient) { }

    public getGames() : Observable<Game[]> {
        return this.http.get<Game[]>(`${environment.apiUrl}/${this.url}`);
    }
  }

@Injectable({ providedIn: 'root'})
export class HighlightGameService {
    private url = "HighlightGame";  
    constructor(private http: HttpClient) { }

    public getHighlightGame() : Observable<Game> {
        return this.http.get<Game>(`${environment.apiUrl}/Game/${this.url}`);
    }
}