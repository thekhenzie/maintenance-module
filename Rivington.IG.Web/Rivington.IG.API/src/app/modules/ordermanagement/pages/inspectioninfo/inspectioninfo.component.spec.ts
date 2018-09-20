import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectioninfoComponent } from './inspectioninfo.component';

describe('InspectioninfoComponent', () => {
  let component: InspectioninfoComponent;
  let fixture: ComponentFixture<InspectioninfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectioninfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectioninfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
