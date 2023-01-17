import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

export interface Employee {
    id: Number,
    name: String,
    signingDate: Date,
    leavingDate: Date | undefined,
    isActive: boolean,

    address: Address,
    position: Position
}

export interface Position {
    id: number,
    name: number
}

export interface Address {
    id: number,
    city: string,
    country: string,
    address: string,
    postCode: string
}

@Injectable({
    providedIn: 'root'
})
export class EmployeesService {

    baseApiUrl: string = 'https://localhost:44370';

    constructor(private http: HttpClient) { }

    getAllEmployees(): Observable<Employee[]> {
        return this.http.get<Employee[]>(this.baseApiUrl + '/api/employees');
    }

    createEmployee(employee: Employee) {
        return this.http.post<Employee>(this.baseApiUrl + '/api/employees', employee)
    }

}