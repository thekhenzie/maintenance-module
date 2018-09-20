import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrimeArtTable } from './p.art.table';

describe('PrimeArtTable', () => {
  let component: PrimeArtTable;
  let fixture: ComponentFixture<PrimeArtTable>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrimeArtTable ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrimeArtTable);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
