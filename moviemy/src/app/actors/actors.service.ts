import { inject, Injectable } from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {ActorCreationDTO, ActorDTO} from './actors.model';
import {PaginationDTO} from '../shared/models/PaginationDTO';
import {Observable} from 'rxjs';
import {buildQueryParams} from '../shared/functions/buildQueryParams';

@Injectable({
  providedIn: 'root'
})
export class ActorsService {

  constructor() {}

  private http = inject(HttpClient);
  private baseUrl = environment.apiURL + '/actors';

  public getPaginated(pagination: PaginationDTO): Observable<HttpResponse<ActorDTO[]>> {
    let queryParams = buildQueryParams(pagination);
    return this.http.get<ActorDTO[]>(this.baseUrl, {params: queryParams, observe: 'response'});
  }

  public getById(id: number): Observable<ActorDTO> {
    return this.http.get<ActorDTO>(`${this.baseUrl}/${id}`);
  }

  public create(actor: ActorCreationDTO){
    const formData = this.buildFormData(actor);
    return this.http.post(this.baseUrl, formData);
  }

  public update(id: number, actor: ActorCreationDTO){
    const formData = this.buildFormData(actor);
    return this.http.put(`${this.baseUrl}/${id}`, formData);
  }

  private buildFormData(actor: ActorCreationDTO): FormData {
    const formData = new FormData();

    formData.append('name', actor.name);
    formData.append('dateofBirth', actor.dateOfBirth.toISOString().split('T')[0]);

    if (actor.picture){
      formData.append('picture', actor.picture);
    }
    return formData;
  }

}
