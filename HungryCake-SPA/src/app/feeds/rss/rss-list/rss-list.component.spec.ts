/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RssListComponent } from './rss-list.component';

describe('RssListComponent', () => {
  let component: RssListComponent;
  let fixture: ComponentFixture<RssListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RssListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RssListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
