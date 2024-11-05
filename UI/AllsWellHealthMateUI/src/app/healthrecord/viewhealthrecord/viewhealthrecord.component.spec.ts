import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewhealthrecordComponent } from './viewhealthrecord.component';

describe('ViewhealthrecordComponent', () => {
  let component: ViewhealthrecordComponent;
  let fixture: ComponentFixture<ViewhealthrecordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewhealthrecordComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewhealthrecordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
