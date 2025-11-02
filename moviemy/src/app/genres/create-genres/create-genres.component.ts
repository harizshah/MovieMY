import {Component, inject} from '@angular/core';
import {Router} from '@angular/router';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-create-genre',
  imports: [MatButtonModule],
  templateUrl: './create-genres.component.html',
  styleUrl: './create-genres.component.css'
})
export class CreateGenreComponent {

  router = inject(Router);

  saveChanges(){
    // ..save changes

    this.router.navigate(['/genres']);
  }
}
