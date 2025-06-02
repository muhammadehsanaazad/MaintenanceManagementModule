import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ServiceForm {
  addOrUpdateForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
  ) {
    this.addOrUpdateForm = this.formBuilder.group({
      id: '',
      serviceName: ['', [Validators.required, Validators.maxLength(100)]],
      serviceDate: ['', Validators.required]
    });
  }


}
