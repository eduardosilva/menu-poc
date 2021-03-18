import { Injectable } from '@angular/core';
import { SearchState, SearchHistory } from '../models';
import { BehaviorSubject, Observable, of, Subject } from 'rxjs';

import { SearchService } from './search.service';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SearchFacadeService {

  private state = new SearchState();
  private dispatch = new Subject<SearchState>();

  readonly error$ = new Subject<string>();
  readonly state$ = this.dispatch.asObservable();

  constructor(private service: SearchService) { }

  loadMenu(input: string): void {
    this.service.getMenu(input).pipe(tap(() => this.error$.next()))
      .subscribe(output => {
        this.state = {
          ... this.state,
          history: [
            ... this.state.history || [],
            {
              moment: new Date(),
              input,
              output
            }
          ]
        };

        this.dispatch.next(this.state);
      }, (error) => this.error$.next(error.message));
  }
}
