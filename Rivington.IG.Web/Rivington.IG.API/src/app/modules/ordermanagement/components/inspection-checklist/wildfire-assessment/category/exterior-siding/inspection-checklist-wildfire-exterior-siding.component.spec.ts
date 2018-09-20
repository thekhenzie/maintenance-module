import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistWildfireExteriorSidingComponent } from './inspection-checklist-wildfire-exterior-siding.component';

describe('InspectionChecklistWildfireExteriorSidingComponent', () => {
  let component: InspectionChecklistWildfireExteriorSidingComponent;
  let fixture: ComponentFixture<InspectionChecklistWildfireExteriorSidingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistWildfireExteriorSidingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistWildfireExteriorSidingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
