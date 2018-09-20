import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildPhotoMemoCrudComponent } from './child-photo-memo-crud.component';

describe('ChildPhotoMemoCrudComponent', () => {
  let component: ChildPhotoMemoCrudComponent;
  let fixture: ComponentFixture<ChildPhotoMemoCrudComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChildPhotoMemoCrudComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChildPhotoMemoCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
