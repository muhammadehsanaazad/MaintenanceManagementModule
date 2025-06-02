import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ServiceService } from '../../../../services/service.service';

@Component({
  selector: 'app-delete-dialog',
  imports: [MatDialogModule, MatButtonModule],
  templateUrl: './delete-dialog.component.html',
  styleUrl: './delete-dialog.component.css'
})
export class DeleteDialogComponent {

  //#region Properties

  //#endregion

  //#region Initialization

  constructor(
    private toastr: ToastrService,
    private serviceService: ServiceService,
    private dialogRef: MatDialogRef<DeleteDialogComponent>
  ) { }

  ngOnInit(): void { }
  //#endregion

  //#region Methods

  Delete() {
    this.serviceService
      .Delete()
      .subscribe((response: any) => {
        if (response) {
          this.toastr.success(response.message);
          this.dialogRef.close('confirmed');
        }
      });
  }
  //#endregion
}
