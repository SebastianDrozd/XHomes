import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewestimateComponent } from './viewestimate.component';

describe('ViewestimateComponent', () => {
  let component: ViewestimateComponent;
  let fixture: ComponentFixture<ViewestimateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewestimateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewestimateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
