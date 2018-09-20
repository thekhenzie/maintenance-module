import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProactiveProtectionComponent } from './proactive-protection.component';

describe('ProactiveProtectionComponent', () => {
  let component: ProactiveProtectionComponent;
  let fixture: ComponentFixture<ProactiveProtectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProactiveProtectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProactiveProtectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
