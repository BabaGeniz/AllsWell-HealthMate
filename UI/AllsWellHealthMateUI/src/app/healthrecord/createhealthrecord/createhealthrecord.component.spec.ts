import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatehealthrecordComponent } from './createhealthrecord.component';

describe('CreatehealthrecordComponent', () => {
  let component: CreatehealthrecordComponent;
  let fixture: ComponentFixture<CreatehealthrecordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreatehealthrecordComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatehealthrecordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
