import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistWildfireRoofComponent } from './inspection-checklist-wildfire-roof.component';

describe('InspectionChecklistWildfireRoofComponent', () => {
  let component: InspectionChecklistWildfireRoofComponent;
  let fixture: ComponentFixture<InspectionChecklistWildfireRoofComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistWildfireRoofComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistWildfireRoofComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
