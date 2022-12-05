import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeamsListComponent } from './components/teams/teams-list/teams-list.component';

const routes: Routes = [
    {
        path: '',
        component: TeamsListComponent
    },
    {
        path: 'teams',
        component: TeamsListComponent
    }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
