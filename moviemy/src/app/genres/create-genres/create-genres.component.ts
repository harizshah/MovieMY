import {Component, inject} from '@angular/core';
import {Router, RouterLink} from '@angular/router';
import {MatButtonModule} from '@angular/material/button';
import {FormBuilder, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';

@Component({
  selector: 'app-create-genre',
  imports: [MatButtonModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, RouterLink],
  templateUrl: './create-genres.component.html',
  styleUrl: './create-genres.component.css'
})
export class CreateGenreComponent {

  router = inject(Router);
  private formBuilder = inject(FormBuilder);

  form = this.formBuilder.group({
    name: ['', {validators: [Validators.required]}],
  });

  getErrorMessagesForName(): string {
    let field = this.form.controls.name;
    return "The name field is required";
  }

  saveChanges(){
    // ..save changes
    console.log(this.form.value);
    this.router.navigate(['/genres']);
  }
}
