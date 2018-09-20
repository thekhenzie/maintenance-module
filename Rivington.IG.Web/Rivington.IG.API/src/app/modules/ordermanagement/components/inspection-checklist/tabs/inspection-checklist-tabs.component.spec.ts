import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistTabsComponent } from './inspection-checklist-tabs.component';

describe('InspectionChecklistTabsComponent', () => {
  let component: InspectionChecklistTabsComponent;
  let fixture: ComponentFixture<InspectionChecklistTabsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistTabsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistTabsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
