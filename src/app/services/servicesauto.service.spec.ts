import { TestBed } from '@angular/core/testing';

import { ServicesautoService } from './servicesauto.service';

describe('ServicesautoService', () => {
  let service: ServicesautoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServicesautoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
