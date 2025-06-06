import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceTaskComponent } from './service-task.component';

describe('ServiceTaskComponent', () => {
  let component: ServiceTaskComponent;
  let fixture: ComponentFixture<ServiceTaskComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ServiceTaskComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServiceTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
