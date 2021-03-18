import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(private http: HttpClient) { }

  getMenu(input: string){
    return this.http.post(environment.api + '/menu/dishes', JSON.stringify(input), {
      responseType: 'text',
      headers: {
        'content-type': 'application/json',
      },
    });
  }
}
