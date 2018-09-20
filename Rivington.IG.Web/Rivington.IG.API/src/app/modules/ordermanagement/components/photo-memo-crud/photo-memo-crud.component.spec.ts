import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PhotoMemoCrudComponent } from './photo-memo-crud.component';

describe('PhotoMemoCrudComponent', () => {
  let component: PhotoMemoCrudComponent;
  let fixture: ComponentFixture<PhotoMemoCrudComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhotoMemoCrudComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhotoMemoCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
