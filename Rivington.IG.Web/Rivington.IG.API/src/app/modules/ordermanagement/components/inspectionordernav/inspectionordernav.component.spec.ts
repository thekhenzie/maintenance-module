import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionordernavComponent } from './inspectionordernav.component';

describe('InspectionordernavComponent', () => {
  let component: InspectionordernavComponent;
  let fixture: ComponentFixture<InspectionordernavComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionordernavComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionordernavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
