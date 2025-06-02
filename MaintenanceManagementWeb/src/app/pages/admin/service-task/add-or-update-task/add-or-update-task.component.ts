import { Component } from '@angular/core';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { TaskForm } from '../../../../form-groups/task-form';
import { TaskService } from '../../../../services/task.service';

@Component({
  selector: 'app-add-or-update-task',
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
  templateUrl: './add-or-update-task.component.html',
  styleUrl: './add-or-update-task.component.css'
})
export class AddOrUpdateTaskComponent {

  //#region Properties

  //#endregion

  //#region Initialization

  constructor(
    public taskForm: TaskForm,
    private toastr: ToastrService,
    private taskService: TaskService,
    private dialogRef: MatDialogRef<AddOrUpdateTaskComponent>
  ) { }

  ngOnInit(): void { }
  //#endregion

  //#region Methods

  Save() {
    if (this.taskForm.addOrUpdateForm.valid) {
      if (this.taskForm.addOrUpdateForm.value.id === null)
        this.Add();
      else this.Update();
    }
  }

  Add() {
    delete this.taskForm.addOrUpdateForm.value.id;
    this.taskService
      .Add(this.taskForm.addOrUpdateForm.value)
      .subscribe((response: any) => {
        if (response) {
          this.toastr.success(response.message);
          this.dialogRef.close('confirmed');
          this.taskForm.addOrUpdateForm.reset();
        }
      });
  }

  Update() {
    this.taskService
      .Update(this.taskForm.addOrUpdateForm.value)
      .subscribe((response: any) => {
        if (response) {
          this.toastr.success(response.message);
          this.dialogRef.close('confirmed');
        }
      });
  }
  //#endregion
}
