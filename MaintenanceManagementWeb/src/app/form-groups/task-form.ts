import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class TaskForm {
  addOrUpdateForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
  ) {
    this.addOrUpdateForm = this.formBuilder.group({
      id: '',
      taskName: ['', Validators.required],
      description: '',
      remarks: '',
      serviceId: ['', Validators.required],
    });
  }

}
