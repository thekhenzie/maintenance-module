import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PhotosOfYourHomeComponent } from './photos-of-your-home.component';

describe('PhotosOfYourHomeComponent', () => {
  let component: PhotosOfYourHomeComponent;
  let fixture: ComponentFixture<PhotosOfYourHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhotosOfYourHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhotosOfYourHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
