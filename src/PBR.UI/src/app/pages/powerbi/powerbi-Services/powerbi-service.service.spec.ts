/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PowerbiServiceService } from './powerbi-service.service';

describe('Service: PowerbiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PowerbiServiceService]
    });
  });

  it('should ...', inject([PowerbiServiceService], (service: PowerbiServiceService) => {
    expect(service).toBeTruthy();
  }));
});
