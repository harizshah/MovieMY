import { Component } from '@angular/core';
import {MatButtonModule} from "@angular/material/button";
import {RouterLink} from "@angular/router";
import {MatIconModule} from '@angular/material/icon';

@Component({
  selector: 'app-index-theaters',
    imports: [
        MatIconModule,
        MatButtonModule,
        RouterLink
    ],
  templateUrl: './index-theaters.component.html',
  styleUrl: './index-theaters.component.css'
})
export class IndexTheatersComponent {

}
