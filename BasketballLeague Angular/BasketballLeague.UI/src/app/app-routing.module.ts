import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllGamesComponent } from './components/games/all-games/all-games.component';
import { TeamsListComponent } from './components/teams/teams-list/teams-list.component';
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
    // {
    //     path: 'teams/topDefensive',
    //     component: AllGamesComponent
    // },
    // {
    //     path: 'games/highlight',
    //     component: AllGamesComponent
    // },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
