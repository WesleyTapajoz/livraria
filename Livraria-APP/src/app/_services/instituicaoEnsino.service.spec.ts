/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { InstituicaoEnsinoService } from './instituicaoEnsino.service';

describe('Service: InstituicaoEnsino', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [InstituicaoEnsinoService]
    });
  });

  it('should ...', inject([InstituicaoEnsinoService], (service: InstituicaoEnsinoService) => {
    expect(service).toBeTruthy();
  }));
});
