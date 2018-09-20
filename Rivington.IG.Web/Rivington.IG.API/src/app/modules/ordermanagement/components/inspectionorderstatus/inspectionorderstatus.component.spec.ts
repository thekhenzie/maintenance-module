import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionorderstatusComponent } from './inspectionorderstatus.component';

describe('InspectionorderstatusComponent', () => {
  let component: InspectionorderstatusComponent;
  let fixture: ComponentFixture<InspectionorderstatusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionorderstatusComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionorderstatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
