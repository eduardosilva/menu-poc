import { TestBed, async } from '@angular/core/testing';

import { SearchFacadeService } from './search-facade.service';
import { SearchService } from './search.service';

import { HttpClient, HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { of, throwError } from 'rxjs';

describe('Demo for menu fetch serivce', () => {
  let facade: SearchFacadeService;
  let api: SearchService;

  beforeEach(async(() => {
    // Config Test
    TestBed.configureTestingModule({
      imports: [HttpClientModule, HttpClientJsonpModule, HttpClientTestingModule],
      providers: [SearchFacadeService, SearchService, HttpClient]
    });

    // Get Service
    api = TestBed.get(SearchService);
    facade = TestBed.get(SearchFacadeService);
  }));

  describe('Test by itself', () => {
    it('should be created', () => {
      expect(facade).toBeTruthy();
      expect(api).toBeTruthy();
    });
  });


  describe('Test returned menu via mock', () => {
    const validOutput = 'eggs, Toast, coffee';

    it('should return mocked menu', done => {
      spyOn(api, 'getMenu').and.returnValue(of(validOutput));

      api.getMenu('').subscribe((response) => {
        expect(response).toBe(validOutput);
        done();
      });
    });

    it('should change facade state with a valid output', done => {
      spyOn(api, 'getMenu').and.returnValue(of(validOutput));

      facade.state$.subscribe(s => {
        expect(s).not.toBeNull();
        expect(s.history.length).toBeGreaterThan(0);
        expect(s.history[0].output).toBe('eggs, Toast, coffee');
        done();
      });

      facade.loadMenu('morning, 1, 2, 3');
    });

    it('should get error with invalid input', done => {
      spyOn(api, 'getMenu').and.returnValue(throwError({ message: 'invalid input' }));

      facade.error$.subscribe(s => {
        expect(s).not.toBeNull();
        expect(s).toBe('invalid input');
        done();
      });

      facade.loadMenu('morning');
    });
  });
});
