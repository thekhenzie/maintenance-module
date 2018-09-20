import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MapItComponent } from './map-it.component';

describe('MapItComponent', () => {
  let component: MapItComponent;
  let fixture: ComponentFixture<MapItComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MapItComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MapItComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
