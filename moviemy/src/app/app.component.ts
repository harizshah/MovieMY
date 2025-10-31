import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DatePipe, UpperCasePipe, CurrencyPipe} from '@angular/common';
import {MoviesListComponent} from './movies/movies-list/movies-list.component';

@Component({
  selector: 'app-root',
  imports: [MoviesListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

}
