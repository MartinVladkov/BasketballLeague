import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopOffensiveTeamsComponent } from './top-offensive-teams.component';

describe('TopOffensiveTeamsComponent', () => {
  let component: TopOffensiveTeamsComponent;
  let fixture: ComponentFixture<TopOffensiveTeamsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TopOffensiveTeamsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopOffensiveTeamsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
