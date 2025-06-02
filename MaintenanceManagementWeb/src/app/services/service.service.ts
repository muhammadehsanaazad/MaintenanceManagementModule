import { Injectable } from '@angular/core';
import { BackendService } from './backend.service';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  serviceId: string | undefined;

  constructor(
    private backendService: BackendService
  ) { }

  Add(requestBody: any) {
    return this.backendService.Post('Service', requestBody);
  }

  GetAll() {
    return this.backendService.Get('Service');
  }

  Update(requestBody: any) {
    return this.backendService.Put('Service', requestBody);
  }

  Delete() {
    return this.backendService.Delete('Service?id=' + this.serviceId);
  }
}
