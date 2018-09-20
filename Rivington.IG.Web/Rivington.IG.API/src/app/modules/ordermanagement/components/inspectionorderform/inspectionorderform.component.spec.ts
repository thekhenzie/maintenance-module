import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionorderformComponent } from './inspectionorderform.component';

describe('InspectionorderformComponent', () => {
  let component: InspectionorderformComponent;
  let fixture: ComponentFixture<InspectionorderformComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionorderformComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionorderformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
