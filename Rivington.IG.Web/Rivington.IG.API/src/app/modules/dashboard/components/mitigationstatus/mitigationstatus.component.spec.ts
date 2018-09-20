import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MitigationstatusComponent } from './mitigationstatus.component';

describe('MitigationstatusComponent', () => {
  let component: MitigationstatusComponent;
  let fixture: ComponentFixture<MitigationstatusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MitigationstatusComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MitigationstatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
