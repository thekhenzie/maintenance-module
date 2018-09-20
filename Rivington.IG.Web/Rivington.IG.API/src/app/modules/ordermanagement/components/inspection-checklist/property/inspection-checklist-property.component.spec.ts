import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistPropertyComponent } from './inspection-checklist-property.component';

describe('InspectionChecklistPropertyComponent', () => {
  let component: InspectionChecklistPropertyComponent;
  let fixture: ComponentFixture<InspectionChecklistPropertyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistPropertyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistPropertyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
