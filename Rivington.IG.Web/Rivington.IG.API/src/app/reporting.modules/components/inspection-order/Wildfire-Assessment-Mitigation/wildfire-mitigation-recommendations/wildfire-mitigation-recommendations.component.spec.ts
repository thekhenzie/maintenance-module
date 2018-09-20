import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WildfireMitigationRecommendationsComponent } from './wildfire-mitigation-recommendations.component';

describe('WildfireMitigationRecommendationsComponent', () => {
  let component: WildfireMitigationRecommendationsComponent;
  let fixture: ComponentFixture<WildfireMitigationRecommendationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WildfireMitigationRecommendationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WildfireMitigationRecommendationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
