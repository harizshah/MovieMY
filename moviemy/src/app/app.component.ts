import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DatePipe, UpperCasePipe, CurrencyPipe} from '@angular/common';
import {MoviesListComponent} from './movies/movies-list/movies-list.component';
import {MenuComponent} from './shared/components/menu/menu.component';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-root',
  imports: [MenuComponent, MatButtonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

}
