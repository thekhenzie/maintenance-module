import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistPropertyDetachedStructureComponent } from './inspection-checklist-property-detached-structure.component';

describe('InspectionChecklistPropertyDetachedStructureComponent', () => {
  let component: InspectionChecklistPropertyDetachedStructureComponent;
  let fixture: ComponentFixture<InspectionChecklistPropertyDetachedStructureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistPropertyDetachedStructureComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistPropertyDetachedStructureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
