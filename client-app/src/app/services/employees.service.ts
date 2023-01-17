import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import CustomStore from 'devextreme/data/custom_store';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.models';

export interface Employees {
  Id: Number,
  Name: String,
  Age: String,
}

const employees: Employee[] = [];

@Injectable({
  providedIn: 'root'
})

export class EmployeesServicee {
  // store: CustomStore;
  //TODO: Fix naming
  //TODO: not correct but there is no environement folder to store the const
  baseApiUrl: string = 'http://localhost:5010'; 

  constructor(private http: HttpClient) { }

  getAllEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseApiUrl + '/api/employees');
  }

  getEmployee(id: Number): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseApiUrl + '/api/employees/' + id)
  }

  createEmployee() {
    return this.http.post<Employee[]>(this.baseApiUrl + '/api/employees', employees)
  }

  updateEmployee(id: Number, employee: Employee){
    return this.http.put(this.baseApiUrl + '/api/employees/' + id, employee)
  }

  deleteEmployee(id: Number) {
    return this.http.delete(this.baseApiUrl + '/api/employees/' + id)
  }
}