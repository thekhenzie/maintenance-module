import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistWildfireSurroundingsComponent } from './inspection-checklist-wildfire-surroundings.component';

describe('InspectionChecklistWildfireSurroundingsComponent', () => {
  let component: InspectionChecklistWildfireSurroundingsComponent;
  let fixture: ComponentFixture<InspectionChecklistWildfireSurroundingsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistWildfireSurroundingsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistWildfireSurroundingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
