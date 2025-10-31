import {Component, Input} from '@angular/core';
import {CurrencyPipe, DatePipe, UpperCasePipe} from "@angular/common";

@Component({
  selector: 'app-movies-list',
    imports: [
        CurrencyPipe,
        DatePipe,
        UpperCasePipe
    ],
  templateUrl: './movies-list.component.html',
  styleUrl: './movies-list.component.css'
})
export class MoviesListComponent {

  @Input({required: true})
  movies?: any[] = [];
}
