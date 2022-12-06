import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HighlightGameComponent } from './highlight-game.component';

describe('HighlightGameComponent', () => {
  let component: HighlightGameComponent;
  let fixture: ComponentFixture<HighlightGameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HighlightGameComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HighlightGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
