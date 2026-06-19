import { TestBed } from '@angular/core/testing';

import { UnitMapService } from './unit-map.service';

describe('UnitMapService', () => {
  let service: UnitMapService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UnitMapService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
