# MV-to-do-list, por Wesllen Santos

## 1. O que é:

O Mv-to-do-list é um app de lista de tarefas, conhecidas como To-dos. É um app local com API executando em https://localhost:7168 e frontend Angular em https://localhost:4200

## 2. Funcionalidades:

- Listagem de tarefas (GET de tarefas e tarefa por ID)

- Cadastro de nova tarefa (POST de tarefa)

- Alteração do status da tarefa (PUT de tarefa por ID)

- Exclusão de tarefa (DELETE de tarefa por ID)

## 3. Tecnologias utilizadas:
- .NET 8
- ASP.NET Web API + Entity Framework
- Angular 21.1.2
- SQL Server


## 4. Como rodar o app:

* Antes de tudo, é preciso clonar o repositório:


```console
git clone <https://github.com/WesllenWorld/MV-to-do-list>
cd MV-to-do-list
```

### API Backend:

1. Entrar na pasta do backend

```console
cd backend
```

2. Baixar todos os pacotes NuGet:

```console
dotnet restore
```

3. Aplicar migrations para o banco:

```console
dotnet ef database update
```

4. Executar a API no diretório MV-to-do-list:

```console
cd MV-to-do-list
dotnet run
```

### Frontend:

1. No diretório do frontend, baixar os pacotes necessários:

```console
cd todolist
npm install
```

2. Rodar o servidor

```console
ng serve
```

(ou ng serve --open, para abrir automaticamente no navegador)
