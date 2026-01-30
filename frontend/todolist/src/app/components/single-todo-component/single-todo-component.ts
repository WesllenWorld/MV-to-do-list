import { Component, OnInit } from '@angular/core';
import { TodoService } from '../../services/todo-service/todo-service';

@Component({
  selector: 'app-single-todo-component',
  imports: [],
  templateUrl: './single-todo-component.html',
  styleUrl: './single-todo-component.css',
})
export class SingleTodoComponent implements OnInit{
  constructor(private TodoService: TodoService) { }
  
  ngOnInit(): void {
      this.TodoService.getTodoById(1).subscribe((todo) => {
        console.log(todo);
      });
    
  }

  onClick(): void {
      this.TodoService.getTodoById(1).subscribe((todo) => {
        console.log(todo);
      });
    
  }
}
