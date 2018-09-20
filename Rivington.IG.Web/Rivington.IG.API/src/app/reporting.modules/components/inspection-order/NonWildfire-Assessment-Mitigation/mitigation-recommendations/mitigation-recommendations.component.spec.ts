import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MitigationRecommendationsComponent } from './mitigation-recommendations.component';

describe('MitigationRecommendationsComponent', () => {
  let component: MitigationRecommendationsComponent;
  let fixture: ComponentFixture<MitigationRecommendationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MitigationRecommendationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MitigationRecommendationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
