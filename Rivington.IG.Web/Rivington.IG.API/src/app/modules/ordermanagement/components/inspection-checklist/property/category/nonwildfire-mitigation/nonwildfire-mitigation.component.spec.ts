import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NonwildfireMitigationComponent } from './nonwildfire-mitigation.component';

describe('NonwildfireMitigationComponent', () => {
  let component: NonwildfireMitigationComponent;
  let fixture: ComponentFixture<NonwildfireMitigationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NonwildfireMitigationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NonwildfireMitigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
