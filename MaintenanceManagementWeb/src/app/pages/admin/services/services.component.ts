import { Component, inject, ViewChild } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';

import { ServiceService } from '../../../services/service.service';
import { DatePipe } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';
import { AddOrUpdateDialogComponent } from './add-or-update-dialog/add-or-update-dialog.component';
import { ServiceForm } from '../../../form-groups/service-form';


@Component({
  selector: 'app-services',
  imports: [MatTableModule, MatPaginatorModule, MatSortModule, MatCardModule, MatIconModule, RouterModule, DatePipe],
  providers: [{ provide: MatDialogRef, useValue: {} }],
  templateUrl: './services.component.html',
  styleUrl: './services.component.css'
})
export class ServicesComponent {

  //#region Properties
  readonly dialog = inject(MatDialog);
  displayedColumns: string[] = ['serviceName', 'servicDate', 'action'];
  dataSource = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  //#endregion

  // #region Initialization

  constructor(
    private serviceService: ServiceService,
    private serviceForm: ServiceForm
  ) { }

  ngOnInit(): void {
    this.GetAll();
  }
  //#endregion

  //#region Methods

  GetAll() {
    this.serviceService
      .GetAll()
      .subscribe((response: any) => {
        if (response) {
          this.dataSource.data = response.body;
          this.dataSource.paginator = this.paginator;
        }
      });
  }

  OnAdd() {
    this.serviceForm.addOrUpdateForm.reset();
    const dialogRef = this.dialog.open(AddOrUpdateDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'confirmed') {
        this.GetAll();
      }
    });
  }

  OnUpdate(service: any) {
    this.serviceForm.addOrUpdateForm.reset({
      id: service.id,
      serviceName: service.serviceName,
      serviceDate: service.serviceDate,
    });

    const dialogRef = this.dialog.open(AddOrUpdateDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'confirmed') {
        this.GetAll();
      }
    });
  }

  OnDelete(id: string) {
    this.serviceService.serviceId = id;
    const dialogRef = this.dialog.open(DeleteDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'confirmed') {
        this.GetAll();
      }
    });
  }
  //#endregion
}
