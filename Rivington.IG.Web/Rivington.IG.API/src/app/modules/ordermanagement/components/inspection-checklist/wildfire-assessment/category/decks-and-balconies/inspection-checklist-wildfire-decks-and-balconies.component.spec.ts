import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistWildfireDecksAndBalconiesComponent } from './inspection-checklist-wildfire-decks-and-balconies.component';

describe('InspectionChecklistWildfireDecksAndBalconiesComponent', () => {
  let component: InspectionChecklistWildfireDecksAndBalconiesComponent;
  let fixture: ComponentFixture<InspectionChecklistWildfireDecksAndBalconiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistWildfireDecksAndBalconiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistWildfireDecksAndBalconiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
