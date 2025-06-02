import { Injectable } from '@angular/core';
import { BackendService } from './backend.service';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  serviceId: string | null | undefined;
  taskId: string | undefined;

  constructor(
    private backendService: BackendService
  ) { }

  Add(requestBody: any) {
    return this.backendService.Post('Task', requestBody);
  }

  GetAll() {
    return this.backendService.Get('Task?serviceId=' + this.serviceId);
  }

  Update(requestBody: any) {
    return this.backendService.Put('Task', requestBody);
  }

  Delete() {
    return this.backendService.Delete('Task?id=' + this.taskId);
  }
}
