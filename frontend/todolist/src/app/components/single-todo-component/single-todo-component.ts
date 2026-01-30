import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TodoService } from '../../services/todo-service/todo-service';
import { Todo } from '../../models/todo';
import { UpdateTodo } from '../../models/update-todo';
import { NgStyle } from '@angular/common';

@Component({
  selector: 'app-single-todo-component',
  imports: [NgStyle],
  templateUrl: './single-todo-component.html',
  styleUrl: './single-todo-component.css',
})
export class SingleTodoComponent{
  constructor(private TodoService: TodoService) { }
  
  
  // ngOnInit(): void {
  //     this.TodoService.getTodoById(1).subscribe((todo) => {
  //       console.log(todo);
  //     });
    
  // }
  @Input() todo!: Todo;
  @Output() delete = new EventEmitter<number>();
  @Output() update = new EventEmitter<{ id: number, updatedTodo: UpdateTodo }>();

  onClick(): void {
      this.TodoService.getTodoById(1).subscribe((todo) => {
        console.log(todo);
      });
    
  }
}
