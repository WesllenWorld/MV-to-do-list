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
  errorMessages: string[] = [];

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
  // if (!this.newTitle.trim()) alert('O título é obrigatório.');

  const createTodo = {
    Title: this.newTitle,
    Description: this.newDescription
  };

  this.todoService.createTodo(createTodo).subscribe({
    next: (todo) => {
      this.todos.push(todo);
      this.newTitle = '';
      this.newDescription = '';
      this.showAddForm = false;
      this.cdr.detectChanges();
    },
    error: (err: any) => {
      let messages = '';

      if (err.status === 400) {
        if (err.error) {
          
          if (typeof err.error === 'object') {
            
            messages = Object.values(err.error)
              .flatMap((x: any) => Array.isArray(x) ? x : [x])
              .map((x: any) => typeof x === 'string' ? x : JSON.stringify(x))
              .join('\n');
          } else {
            
            messages = String(err.error);
          }
        } else {
          messages = 'Erro de validação desconhecido.';
        }

        alert('Erro ao criar todo:\n' + messages);
      } else {
        console.error(err);
        alert('Erro inesperado ao criar todo');
      }
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
    console.log('ID recebido:', id);
    console.log('Tipo do ID:', typeof id);

    if (!id || id === undefined) {
      console.error('ID está undefined ou inválido!');
      return;
    }

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
