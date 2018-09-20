import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistWildfireFoundationToFrameComponent } from './inspection-checklist-wildfire-foundation-to-frame.component';

describe('InspectionChecklistWildfireFoundationToFrameComponent', () => {
  let component: InspectionChecklistWildfireFoundationToFrameComponent;
  let fixture: ComponentFixture<InspectionChecklistWildfireFoundationToFrameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistWildfireFoundationToFrameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistWildfireFoundationToFrameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
