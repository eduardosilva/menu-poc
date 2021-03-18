import { Component, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators, ValidatorFn, AbstractControl } from '@angular/forms';
import { SearchFacadeService } from '../services/search-facade.service';
import { Subscription, Observable, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, map, last, switchMap, startWith, takeLast } from 'rxjs/operators';
import { SearchHistory } from '../models';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html'
})
export class FormComponent {

  lastOutput$ = this.facade.state$.pipe(
    map((state) => state.history),
    startWith([] as SearchHistory[]),
    map((state) => {
      const array = state || [];
      const result = array[array.length - 1] || { output: '' };
      return result.output;
    })
  );

  constructor(private facade: SearchFacadeService) {}

  form = new FormGroup({
    input: new FormControl('', [this.inputValidator(), Validators.required])
  });

  submitForm(): void {
    this.facade.loadMenu(this.form.get('input').value);
    this.form.reset();
  }

  inputValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const invalid = Array.from(control.value || '').filter(i => i === ',').length < 3;
      return invalid ? { invalidInput: { value: control.value } } : null;
    };
  }
}
