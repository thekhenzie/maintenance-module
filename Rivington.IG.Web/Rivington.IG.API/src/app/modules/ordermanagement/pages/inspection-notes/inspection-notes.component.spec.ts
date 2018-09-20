import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionnotesComponent } from './inspectionnotes.component';

describe('InspectionnotesComponent', () => {
  let component: InspectionnotesComponent;
  let fixture: ComponentFixture<InspectionnotesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionnotesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionnotesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
