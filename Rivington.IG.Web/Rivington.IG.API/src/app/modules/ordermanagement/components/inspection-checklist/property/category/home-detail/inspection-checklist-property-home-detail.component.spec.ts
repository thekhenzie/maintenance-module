import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistPropertyHomeDetailComponent } from './inspection-checklist-property-home-detail.component';

describe('InspectionChecklistPropertyHomeDetailComponent', () => {
  let component: InspectionChecklistPropertyHomeDetailComponent;
  let fixture: ComponentFixture<InspectionChecklistPropertyHomeDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistPropertyHomeDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistPropertyHomeDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
