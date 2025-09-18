import { TestBed } from '@angular/core/testing';

import { LearnerApiService } from './learner-api.service';

describe('LearnerApiService', () => {
  let service: LearnerApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LearnerApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
