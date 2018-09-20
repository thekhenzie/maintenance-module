import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistPropertyGeneralComponent } from './inspection-checklist-property-general.component';

describe('InspectionChecklistPropertyGeneralComponent', () => {
  let component: InspectionChecklistPropertyGeneralComponent;
  let fixture: ComponentFixture<InspectionChecklistPropertyGeneralComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistPropertyGeneralComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistPropertyGeneralComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
