import { TestBed } from '@angular/core/testing';

import { BookcatalogServiceService } from './bookcatalog-service.service';

describe('BookcatalogServiceService', () => {
  let service: BookcatalogServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookcatalogServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
