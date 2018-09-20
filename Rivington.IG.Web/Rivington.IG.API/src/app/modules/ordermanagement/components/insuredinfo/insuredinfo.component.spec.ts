import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsuredinfoComponent } from './insuredinfo.component';

describe('InsuredinfoComponent', () => {
  let component: InsuredinfoComponent;
  let fixture: ComponentFixture<InsuredinfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InsuredinfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InsuredinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
