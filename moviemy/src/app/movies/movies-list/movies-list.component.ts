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
  movies!: any[];
  addMovie(){
    this.movies?.push({
      title: 'Inception',
      releaseDate: new Date('2017-07-03'),
      price: 500
    })
  }

  removeMovie(movie: any){
    let index = this.movies?.findIndex((m: any) => m.title === movie.title);
    this.movies?.splice(index, 1);
  }
}
