import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistWildfireWindowsComponent } from './inspection-checklist-wildfire-windows.component';

describe('InspectionChecklistWildfireWindowsComponent', () => {
  let component: InspectionChecklistWildfireWindowsComponent;
  let fixture: ComponentFixture<InspectionChecklistWildfireWindowsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistWildfireWindowsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistWildfireWindowsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
