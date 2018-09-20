import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsuredMitigationComponent } from './insured-mitigation.component';

describe('InsuredMitigationComponent', () => {
  let component: InsuredMitigationComponent;
  let fixture: ComponentFixture<InsuredMitigationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InsuredMitigationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InsuredMitigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
