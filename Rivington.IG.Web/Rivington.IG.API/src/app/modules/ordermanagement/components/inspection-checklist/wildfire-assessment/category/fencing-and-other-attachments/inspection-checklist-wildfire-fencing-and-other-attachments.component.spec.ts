import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistWildfireFencingAndOtherAttachmentsComponent } from './inspection-checklist-wildfire-fencing-and-other-attachments.component';

describe('InspectionChecklistWildfireFencingAndOtherAttachmentsComponent', () => {
  let component: InspectionChecklistWildfireFencingAndOtherAttachmentsComponent;
  let fixture: ComponentFixture<InspectionChecklistWildfireFencingAndOtherAttachmentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistWildfireFencingAndOtherAttachmentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistWildfireFencingAndOtherAttachmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
