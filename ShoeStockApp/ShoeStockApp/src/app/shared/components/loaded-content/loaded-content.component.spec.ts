import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoadedContentComponent } from './loaded-content.component';

describe('LoadedContentComponent', () => {
  let component: LoadedContentComponent;
  let fixture: ComponentFixture<LoadedContentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoadedContentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoadedContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
