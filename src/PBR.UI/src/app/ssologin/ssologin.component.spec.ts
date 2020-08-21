import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SsologinComponent } from './ssologin.component';

describe('SsologinComponent', () => {
  let component: SsologinComponent;
  let fixture: ComponentFixture<SsologinComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SsologinComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SsologinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
