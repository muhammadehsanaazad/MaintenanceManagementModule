import { Component } from '@angular/core';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ServiceService } from '../../../../services/service.service';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { ServiceForm } from '../../../../form-groups/service-form';

@Component({
  selector: 'app-add-or-update-dialog',
  imports: [
    MatDialogModule,
    MatButtonModule,
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatCardModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
  ],
  templateUrl: './add-or-update-dialog.component.html',
  styleUrl: './add-or-update-dialog.component.css'
})
export class AddOrUpdateDialogComponent {

  //#region Properties

  minDate = new Date();
  //#endregion

  //#region Initialization

  constructor(
    public serviceForm: ServiceForm,
    private toastr: ToastrService,
    private serviceService: ServiceService,
    private dialogRef: MatDialogRef<AddOrUpdateDialogComponent>
  ) { }

  ngOnInit(): void {

  }
  //#endregion

  //#region Methods

  Save() {
    if (this.serviceForm.addOrUpdateForm.valid) {
      if (this.serviceForm.addOrUpdateForm.value.id === null)
        this.Add();
      else this.Update();
    }
  }

  Add() {
    delete this.serviceForm.addOrUpdateForm.value.id;
    this.serviceService
      .Add(this.serviceForm.addOrUpdateForm.value)
      .subscribe((response: any) => {
        if (response) {
          this.toastr.success(response.message);
          this.dialogRef.close('confirmed');
          this.serviceForm.addOrUpdateForm.reset();
        }
      });
  }

  Update() {
    this.serviceService
      .Update(this.serviceForm.addOrUpdateForm.value)
      .subscribe((response: any) => {
        if (response) {
          this.toastr.success(response.message);
          this.dialogRef.close('confirmed');
        }
      });
  }
  //#endregion
}
