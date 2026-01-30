import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo } from '../../models/todo';
import { CreateTodo } from '../../models/create-todo';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  //private apiUrl = 'https://localhost:7168/api/tarefas';
  private apiUrl = 'https://localhost:44303/api/tarefas';

  constructor(private http: HttpClient) { }

  getAllTodos(): Observable<Todo[]> {
    
    return this.http.get<Todo[]>(this.apiUrl);

  }

  getTodoById(id: number): Observable<Todo> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Todo>(url);

  }

  createTodo(todoDTO: CreateTodo): Observable<Todo> {
    return this.http.post<Todo>(`${this.apiUrl}`, todoDTO, {
      headers: { 'Content-Type': 'application/json' }
    });}

  updateTodoStatusById(id: number, UpdateTodo: any): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.put<void>(url, UpdateTodo);
  }

  
  deleteTodoById(id: number): Observable<void> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<void>(url);
  }
}
