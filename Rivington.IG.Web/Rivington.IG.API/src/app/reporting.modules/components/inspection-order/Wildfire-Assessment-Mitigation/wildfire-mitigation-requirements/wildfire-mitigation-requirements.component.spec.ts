import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WildfireMitigationRequirementsComponent } from './wildfire-mitigation-requirements.component';

describe('WildfireMitigationRequirementsComponent', () => {
  let component: WildfireMitigationRequirementsComponent;
  let fixture: ComponentFixture<WildfireMitigationRequirementsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WildfireMitigationRequirementsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WildfireMitigationRequirementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
