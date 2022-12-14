import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllGamesComponent } from './components/games/all-games/all-games.component';
import { HighlightGameComponent } from './components/games/highlight-game/highlight-game.component';
import { TeamsListComponent } from './components/teams/teams-list/teams-list.component';
import { TopDefensiveTeamsComponent } from './components/teams/top-defensive-teams/top-defensive-teams.component';
import { TopOffensiveTeamsComponent } from './components/teams/top-offensive-teams/top-offensive-teams.component';

const routes: Routes = [
    {
        path: '',
        component: TeamsListComponent
    },
    {
        path: 'teams',
        component: TeamsListComponent
    },
    {
        path: 'games',
        component: AllGamesComponent
    },
    {
        path: 'teams/topOffensive',
        component: TopOffensiveTeamsComponent
    },
    {
        path: 'teams/topDefensive',
        component: TopDefensiveTeamsComponent
    },
    {
        path: 'games/highlight',
        component: HighlightGameComponent
    },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
