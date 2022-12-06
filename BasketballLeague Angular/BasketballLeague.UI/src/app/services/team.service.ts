import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { Team } from '../models/team';
import { TopTeam } from '../models/top-team';

@Injectable({ providedIn: 'root'})
export class TeamService {
    private url = "Team";  
    constructor(private http: HttpClient) { }

    public getTeams() : Observable<Team[]> {
        return this.http.get<Team[]>(`${environment.apiUrl}/${this.url}`);
    }
  }

@Injectable({ providedIn: 'root'})
export class TopOffensiveTeamsService {
    private url = "TopOffensiveTeams";  
    constructor(private http: HttpClient) { }

    public getTopOffensiveTeams() : Observable<TopTeam[]> {
        return this.http.get<TopTeam[]>(`${environment.apiUrl}/Team/${this.url}`);
    }
  }