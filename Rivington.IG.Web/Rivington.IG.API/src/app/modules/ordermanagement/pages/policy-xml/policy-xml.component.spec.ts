import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PolicyXmlComponent } from './policy-xml.component';

describe('PolicyXmlComponent', () => {
  let component: PolicyXmlComponent;
  let fixture: ComponentFixture<PolicyXmlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PolicyXmlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PolicyXmlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
