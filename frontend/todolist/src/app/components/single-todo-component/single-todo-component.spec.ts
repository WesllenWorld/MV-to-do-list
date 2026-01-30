import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingleTodoComponent } from './single-todo-component';

describe('SingleTodoComponent', () => {
  let component: SingleTodoComponent;
  let fixture: ComponentFixture<SingleTodoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SingleTodoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SingleTodoComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
