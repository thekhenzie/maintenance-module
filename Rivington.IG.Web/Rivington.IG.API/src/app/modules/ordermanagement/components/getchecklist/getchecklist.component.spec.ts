import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetchecklistComponent } from './getchecklist.component';

describe('GetchecklistComponent', () => {
  let component: GetchecklistComponent;
  let fixture: ComponentFixture<GetchecklistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetchecklistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetchecklistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
