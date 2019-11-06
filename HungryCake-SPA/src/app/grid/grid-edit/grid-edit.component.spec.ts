/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GridEditComponent as GridEditComponent } from './grid-edit.component';

describe('GridEditComponent', () => {
  let component: GridEditComponent;
  let fixture: ComponentFixture<GridEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
