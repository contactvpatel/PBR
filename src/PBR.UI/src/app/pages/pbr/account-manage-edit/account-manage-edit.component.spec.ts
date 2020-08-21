import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountManageEditComponent } from './account-manage-edit.component';

describe('AccountManageEditComponent', () => {
  let component: AccountManageEditComponent;
  let fixture: ComponentFixture<AccountManageEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountManageEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountManageEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
