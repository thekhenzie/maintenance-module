import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionOrderComponent } from './inspection-order.component';

describe('InspectionOrderComponent', () => {
  let component: InspectionOrderComponent;
  let fixture: ComponentFixture<InspectionOrderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionOrderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
