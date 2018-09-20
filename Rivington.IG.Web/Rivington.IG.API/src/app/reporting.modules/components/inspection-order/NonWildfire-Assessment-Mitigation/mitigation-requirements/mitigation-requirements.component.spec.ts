import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MitigationRequirementsComponent } from './mitigation-requirements.component';

describe('MitigationRequirementsComponent', () => {
  let component: MitigationRequirementsComponent;
  let fixture: ComponentFixture<MitigationRequirementsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MitigationRequirementsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MitigationRequirementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
