import {Component, inject} from '@angular/core';
import {Router, RouterLink} from '@angular/router';
import {MatButtonModule} from '@angular/material/button';
import {FormBuilder, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {GenresFormComponent} from '../genres-form/genres-form.component';
import { firstLetterShouldBeUppercase } from '../../shared/functions/validations';
import { GenreCreationDTO } from '../genres.models';

@Component({
  selector: 'app-create-genre',
  imports: [MatButtonModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, GenresFormComponent],
  templateUrl: './create-genres.component.html',
  styleUrl: './create-genres.component.css'
})

export class CreateGenreComponent {

  router = inject(Router);

  saveChanges(genre: GenreCreationDTO){
    // .. save changes
    console.log(genre);
    this.router.navigate(['/genres']);
  }

}
