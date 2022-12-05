import { Injectable } from '@angular/core';
import { Team } from '../models/team';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  constructor() { }

  public getTeams() : Team[] {
    let team = new Team();
    team.id = 1; 
    team.name = "LA Lakers";

    return[team];
  }
}
