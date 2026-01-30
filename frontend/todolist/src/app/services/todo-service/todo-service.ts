import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo } from '../../models/todo';
import { CreateTodo } from '../../models/create-todo';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  private apiUrl = 'https://localhost:7168/api/tarefas';

  constructor(private http: HttpClient) { }

  getAllTodos(): Observable<Todo[]> {
    //const url = $
    return this.http.get<Todo[]>(this.apiUrl);

  }

  getTodoById(id: number): Observable<Todo> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Todo>(url);

  }

  createTodo(todoDTO: any): Observable<CreateTodo> {
    return this.http.post<CreateTodo>(this.apiUrl, todoDTO);
  }

  updateTodoStatusById(id: number, UpdateTodo: any): void {
    const url = `${this.apiUrl}/${id}`;
    this.http.put(url, UpdateTodo);
  
  }

  //falta o delete
  deleteTodoById(id: number): void {
    const url = `${this.apiUrl}/${id}`;
    this.http.delete(url);
  }
}
