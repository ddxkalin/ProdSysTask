import { TestBed } from '@angular/core/testing';

import { EmployeesServicee } from './employees.service';

describe('EmployeesService', () => {
  let service: EmployeesServicee;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmployeesServicee);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
