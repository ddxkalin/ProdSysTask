import { Component, OnInit, ViewChild } from '@angular/core';
import { DxDataGridComponent, DxPopupComponent } from 'devextreme-angular';
import { Employee, EmployeesService } from 'src/app/models/employee.models';
import { EmployeesServicee } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent {

  cityAndCountryPattern = '^[^0-9]+$';

  employees: Employee[] = [];

  constructor(private service: EmployeesService) {
    this.service.getAllEmployees().subscribe((res: Employee[]) => {
      this.employees = res;
      console.log(res);
    })
  }

  insertEmployee(e: any) {
    let employee: Employee = e.data;

    this.service.createEmployee(employee).subscribe((res => {
      e.data = res;
    }), (error) => {
      alert("An error occured while trying to add the new employee, please try again!");
      e.cancel = true; // To Stop the insert row in case of error
    })
  }

  employeeInserted(e: any) {
    console.log("Inserted", e);
  }

  initCreateNewEmployee(e: any) {
    (e.data as Employee).isActive = true;
    (e.data as Employee).signingDate = new Date();
  }

}