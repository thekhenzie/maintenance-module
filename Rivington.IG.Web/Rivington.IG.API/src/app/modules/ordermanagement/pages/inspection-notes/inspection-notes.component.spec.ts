import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionNotesComponent } from './inspection-notes.component';

describe('InspectionNotesComponent', () => {
  let component: InspectionNotesComponent;
  let fixture: ComponentFixture<InspectionNotesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionNotesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionNotesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
