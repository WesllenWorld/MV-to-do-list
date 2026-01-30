import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/header-component/header-component';
import { FooterComponent } from './components/footer-component/footer-component';
import { HttpClient } from '@angular/common/http';
import { SingleTodoComponent } from './components/single-todo-component/single-todo-component';
import { TodoListComponent } from './components/todo-list-component/todo-list-component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, FooterComponent, SingleTodoComponent, TodoListComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('todolist');
  titlemeu = 'Meu Todolist';
}
