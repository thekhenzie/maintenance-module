import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectiontableComponent } from './inspectiontable.component';

describe('InspectiontableComponent', () => {
  let component: InspectiontableComponent;
  let fixture: ComponentFixture<InspectiontableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectiontableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectiontableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
