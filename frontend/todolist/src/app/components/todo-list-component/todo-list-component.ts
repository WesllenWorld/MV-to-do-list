import { Component, OnInit } from '@angular/core';
import { Todo } from '../../models/todo';
import { TodoService } from '../../services/todo-service/todo-service';
import { SingleTodoComponent } from '../single-todo-component/single-todo-component';
import { UpdateTodo } from '../../models/update-todo';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-todo-list-component',
  imports: [SingleTodoComponent, CommonModule, FormsModule],
  templateUrl: './todo-list-component.html',
  styleUrl: './todo-list-component.css',
})
export class TodoListComponent implements OnInit {
  todos: Todo[] = [];

  showAddForm = false;
  newTitle = '';
  newDescription = '';

  constructor(private todoService: TodoService, private cdr: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.loadAllTodos();
  }

  loadAllTodos(): void {
    this.todoService.getAllTodos().subscribe((todos) => {
      this.todos = todos;
      this.cdr.detectChanges();
    });
  }

  toggleAddForm() {
    this.showAddForm = !this.showAddForm;
  }

  addTodo() {
    if (!this.newTitle.trim()) return;

    const createTodo = {
      title: this.newTitle,
      description: this.newDescription
    };

    this.todoService.createTodo(createTodo).subscribe({
      next: todo => {
        this.todos.push(todo);
        this.newTitle = '';
        this.newDescription = '';
        this.showAddForm = false;
        this.cdr.detectChanges();
      }
      ,
      error: err => {
        console.error('Falha ao criar todo:', err);
      }
    });
  }


  updateTodo(id: number, updatedTodo: UpdateTodo) {
    const todo = this.todos.find(t => t.id === id);
    if (todo) {
      todo.status = updatedTodo.status;
    }

    this.todoService.updateTodoStatusById(id, updatedTodo).subscribe(() => {
      const index = this.todos.findIndex(t => t.id === id);
      error: () => {
        console.error('Falha ao atualizar status');
      }
    });
  }

  deleteTodo(id: number) {
    this.todoService.deleteTodoById(id).subscribe({
      next: () => {
        this.todos = this.todos.filter(t => t.id !== id);
        this.cdr.detectChanges();
      },
      error: err => {
        console.error('Falha ao deletar todo');
      }
    });
  }


}
