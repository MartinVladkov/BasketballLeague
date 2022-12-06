import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopDefensiveTeamsComponent } from './top-defensive-teams.component';

describe('TopDefensiveTeamsComponent', () => {
  let component: TopDefensiveTeamsComponent;
  let fixture: ComponentFixture<TopDefensiveTeamsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TopDefensiveTeamsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopDefensiveTeamsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
