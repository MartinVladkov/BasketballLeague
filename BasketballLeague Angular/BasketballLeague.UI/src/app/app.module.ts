import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TeamsListComponent } from './components/teams/teams-list/teams-list.component';
import { AllGamesComponent } from './components/games/all-games/all-games.component';
import { TopOffensiveTeamsComponent } from './components/teams/top-offensive-teams/top-offensive-teams.component';
import { TopDefensiveTeamsComponent } from './components/teams/top-defensive-teams/top-defensive-teams.component';

@NgModule({
  declarations: [
    AppComponent,
    TeamsListComponent,
    AllGamesComponent,
    TopOffensiveTeamsComponent,
    TopDefensiveTeamsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
