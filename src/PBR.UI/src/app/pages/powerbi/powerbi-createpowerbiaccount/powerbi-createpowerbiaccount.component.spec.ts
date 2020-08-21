/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PowerbiCreatepowerbiaccountComponent } from './powerbi-createpowerbiaccount.component';

describe('PowerbiCreatepowerbiaccountComponent', () => {
  let component: PowerbiCreatepowerbiaccountComponent;
  let fixture: ComponentFixture<PowerbiCreatepowerbiaccountComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PowerbiCreatepowerbiaccountComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PowerbiCreatepowerbiaccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
