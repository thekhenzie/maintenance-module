import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistPropertyInteriorDetailComponent } from './inspection-checklist-property-interior-detail.component';

describe('InspectionChecklistPropertyInteriorDetailComponent', () => {
  let component: InspectionChecklistPropertyInteriorDetailComponent;
  let fixture: ComponentFixture<InspectionChecklistPropertyInteriorDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistPropertyInteriorDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistPropertyInteriorDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
