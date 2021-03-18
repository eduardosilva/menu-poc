import { Component } from '@angular/core';
import { SearchHistory } from '../models';
import { SearchFacadeService } from '../services/search-facade.service';
import { Subject, of } from 'rxjs';
import { catchError, tap, last, map, startWith } from 'rxjs/operators';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styles: [
  ]
})
export class TableComponent {
  readonly error$ = this.facade.error$;
  readonly historic$ = this.facade.state$.pipe(
    map((state) => state.history),
    startWith([] as SearchHistory[])
  );

  constructor(private facade: SearchFacadeService) {}
}
