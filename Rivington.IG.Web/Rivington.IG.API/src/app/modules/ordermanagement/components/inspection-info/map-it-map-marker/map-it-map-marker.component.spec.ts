import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MapItMapMarkerComponent } from './map-it-map-marker.component';

describe('MapItInfoWindowComponent', () => {
  let component: MapItMapMarkerComponent;
  let fixture: ComponentFixture<MapItMapMarkerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MapItMapMarkerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MapItMapMarkerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
