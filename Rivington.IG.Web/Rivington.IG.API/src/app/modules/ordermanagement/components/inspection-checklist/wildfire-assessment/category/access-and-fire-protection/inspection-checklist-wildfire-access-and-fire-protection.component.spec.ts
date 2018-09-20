import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistWildfireAccessAndFireProtectionComponent } from './inspection-checklist-wildfire-access-and-fire-protection.component';

describe('InspectionChecklistWildfireAccessAndFireProtectionComponent', () => {
  let component: InspectionChecklistWildfireAccessAndFireProtectionComponent;
  let fixture: ComponentFixture<InspectionChecklistWildfireAccessAndFireProtectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistWildfireAccessAndFireProtectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistWildfireAccessAndFireProtectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
