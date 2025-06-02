import { Component, inject, ViewChild } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatDialog, MatDialogRef, } from '@angular/material/dialog';

import { TaskService } from '../../../services/task.service';
import { TaskForm } from '../../../form-groups/task-form';
import { AddOrUpdateTaskComponent } from './add-or-update-task/add-or-update-task.component';
import { DeleteTaskComponent } from './delete-task/delete-task.component';


@Component({
  selector: 'app-service-task',
  imports: [MatTableModule, MatPaginatorModule, MatSortModule, MatCardModule, MatIconModule, RouterModule, DatePipe],
  providers: [{ provide: MatDialogRef, useValue: {} }],
  templateUrl: './service-task.component.html',
  styleUrl: './service-task.component.css'
})
export class ServiceTaskComponent {

  //#region Properties

  readonly dialog = inject(MatDialog);
  displayedColumns: string[] = ['taskName', 'description', 'remarks', 'action',];
  dataSource = new MatTableDataSource<any>([]);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  //#endregion

  //#region Initialization

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private toastr: ToastrService,
    private taskService: TaskService,
    private taskForm: TaskForm
  ) { }

  ngOnInit(): void {
    this.taskService.serviceId = this.activatedRoute.snapshot.paramMap.get('id');
    this.GetAll();
  }
  //#endregion

  //#region Methods

  GetAll() {
    this.taskService
      .GetAll()
      .subscribe((response: any) => {
        if (response) {
          this.dataSource.data = response.body;
          this.dataSource.paginator = this.paginator;
        }
      });
  }

  OnAdd() {
    this.taskForm.addOrUpdateForm.reset({
      serviceId: this.taskService.serviceId
    });
    const dialogRef = this.dialog.open(AddOrUpdateTaskComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'confirmed') {
        this.GetAll();
      }
    });
  }

  OnUpdate(task: any) {
    this.taskForm.addOrUpdateForm.reset({
      id: task.id,
      taskName: task.taskName,
      description: task.description,
      remarks: task.remarks,
      serviceId: this.taskService.serviceId
    });

    const dialogRef = this.dialog.open(AddOrUpdateTaskComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'confirmed') {
        this.GetAll();
      }
    });
  }

  OnDelete(id: string) {
    this.taskService.taskId = id;
    const dialogRef = this.dialog.open(DeleteTaskComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'confirmed') {
        this.GetAll();
      }
    });
  }
  //#endregion
}

