import { Component, OnInit, ViewChild } from '@angular/core';
import { DxDataGridComponent, DxPopupComponent } from 'devextreme-angular';
import { ToastType } from 'devextreme/ui/toast';
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

  /* TOAST */
  isVisible = false;
  type: ToastType = 'info';
  message: string = "message example";
  /* TOAST */

  constructor(private service: EmployeesService) {
    this.getEmployees()
  }

  getEmployees() {
    this.service.getAllEmployees().subscribe((res: Employee[]) => {
      this.employees = res;
    })
  }

  insertEmployee(e: any) {
    let employee: Employee = e.data;

    this.service.createEmployee(employee).subscribe((res => {
      this.employees = [];
      this.getEmployees();

      this.showToast(`The employee ${employee.name} has been added successfully`, "success");

    }), (error) => {
      this.showToast("An error occured while trying to add the new employee, please try again!", "error");
      e.cancel = true; // To Stop the insert row in case of error
    })
  }

  onEmployeeUpdating(e: any) {
    let employee: any = e.oldData;

    //Map changed data from newData
    let newEmployeeData: any = e.newData;
    this.updateEntry(employee, newEmployeeData);

    this.service.updateEmployee(e.key, employee).subscribe((res => {
      e.data = res;

      this.showToast(`The employee ${employee.name} has been updated successfully`, "success");
    }), (error) => {
      this.showToast(`An error occured while trying to update the employee ${employee.name}, please try again!`, "error");
      e.cancel = true; // To Stop the insert row in case of error
    })
  }

  initCreateNewEmployee(e: any) {
    (e.data as Employee).isActive = true;
    (e.data as Employee).signingDate = new Date();
  }

  onEmployeeRemoving(e: any) {
    let employeeID: Number = (e.data as Employee).id;
    let employee = this.employees.find(E => E.id == employeeID);
    this.service.deleteEmployee(employeeID).subscribe((res => {
      this.showToast(`The employee ${employee?.name} has been deleted successfully`, "success");
    }), (error) => {
      this.showToast("An error occured while trying to delete the employee, please try again!", "error");
      e.cancel = true; // To Stop deleting the row in case of error
    })
  }

  updateEntry(oldObj: any, newObj: any) {
    Object.entries(newObj).forEach(([key, value]) => {
      if (typeof value != 'object')
        oldObj[key] = value;
      else {
        if (key == "address" && !oldObj["address"])
          oldObj.address = {};
        if (key == "position" && !oldObj["position"])
          oldObj.position = {};
        this.updateEntry(oldObj[key], value);
      }
    });
  }

  showToast(_message: string, type: ToastType) {
    this.isVisible = true;
    this.message = _message;
    this.type = type;
  }

}