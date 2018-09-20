import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionOrderTimelineComponent } from './inspection-order-timeline.component';

describe('InspectionOrderTimelineComponent', () => {
  let component: InspectionOrderTimelineComponent;
  let fixture: ComponentFixture<InspectionOrderTimelineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionOrderTimelineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionOrderTimelineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
