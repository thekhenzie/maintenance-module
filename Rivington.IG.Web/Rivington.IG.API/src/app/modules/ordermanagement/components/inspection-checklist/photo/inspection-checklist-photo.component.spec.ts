import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistPhotoComponent } from './inspection-checklist-photo.component';

describe('InspectionChecklistPhotoComponent', () => {
  let component: InspectionChecklistPhotoComponent;
  let fixture: ComponentFixture<InspectionChecklistPhotoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistPhotoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistPhotoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
