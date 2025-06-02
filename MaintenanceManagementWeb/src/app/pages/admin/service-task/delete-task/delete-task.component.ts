import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { TaskService } from '../../../../services/task.service';

@Component({
  selector: 'app-delete-task',
  imports: [MatDialogModule, MatButtonModule],
  templateUrl: './delete-task.component.html',
  styleUrl: './delete-task.component.css'
})
export class DeleteTaskComponent {

  //#region Properties

  //#endregion

  //#region Initialization

  constructor(
    private toastr: ToastrService,
    private taskService: TaskService,
    private dialogRef: MatDialogRef<DeleteTaskComponent>
  ) { }

  ngOnInit(): void { }
  //#endregion

  //#region Methods

  Delete() {
    this.taskService
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
