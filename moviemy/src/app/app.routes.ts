import { Routes } from '@angular/router';
import {LandingPageComponent} from './landing-page/landing-page.component';
import {IndexGenresComponent} from './genres/index-genres/index-genres.component';
import {CreateGenreComponent} from './genres/create-genres/create-genres.component';
import {IndexActorsComponent} from './actors/index-actors/index-actors.component';
import {CreateActorComponent} from './actors/create-actor/create-actor.component';
import {IndexTheatersComponent} from './theaters/index-theaters/index-theaters.component';
import {CreateTheaterComponent} from './theaters/create-theater/create-theater.component';
import {CreateMovieComponent} from './movies/create-movie/create-movie.component';
import {EditMovieComponent} from './movies/edit-movie/edit-movie.component';

export const routes: Routes = [
  {path: '', component: LandingPageComponent},
  {path: 'genres', component: IndexGenresComponent},
  {path: 'genres/create', component: CreateGenreComponent},

  {path: 'actors', component: IndexActorsComponent},
  {path: 'actors/create', component: CreateActorComponent},

  {path: 'theaters', component: IndexTheatersComponent},
  {path: 'theaters/create', component: CreateTheaterComponent},

  {path: 'movies/create', component: CreateMovieComponent},
  {path: 'movies/edit/:id', component: EditMovieComponent},

];
