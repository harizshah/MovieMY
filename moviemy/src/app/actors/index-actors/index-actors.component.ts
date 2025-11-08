import { inject, Component } from '@angular/core';
import {MatButtonModule} from "@angular/material/button";
import {RouterLink} from "@angular/router";
import {MatIconModule} from '@angular/material/icon';
import {GenericListComponent} from '../../shared/components/generic-list/generic-list.component';
import {MatPaginatorModule, PageEvent} from '@angular/material/paginator';
import {ActorsService} from '../actors.service';
import {PaginationDTO} from '../../shared/models/PaginationDTO';
import {ActorDTO} from '../actors.model';
import {HttpResponse} from '@angular/common/http';
import {MatColumnDef, MatHeaderCell, MatHeaderRow, MatTable, MatTableModule} from '@angular/material/table';
import {SweetAlert2Module} from '@sweetalert2/ngx-sweetalert2';
import {CRUD_SERVICE_TOKEN} from '../../shared/providers/providers';
import {IndexEntitiesComponent} from '../../shared/components/index-entities/index-entities.component';

@Component({
  selector: 'app-index-actors',
  imports: [
    IndexEntitiesComponent
  ],
  templateUrl: './index-actors.component.html',
  styleUrl: './index-actors.component.css',
  providers: [ {provide: CRUD_SERVICE_TOKEN, useClass: ActorsService}
  ]
})
export class IndexActorsComponent {

}
