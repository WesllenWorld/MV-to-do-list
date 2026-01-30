# MV-to-do-list, por Wesllen Santos

## 1. O que é:

O Mv-to-do-list é um app de lista de tarefas, conhecidas como To-dos. É um app local com API executando em https://localhost:7168 e frontend Angular em https://localhost:4200

## 2. Funcionalidades:

- Listagem de tarefas (GET de tarefas e tarefa por ID)

- Cadastro de nova tarefa (POST de tarefa)

- Alteração do status da tarefa (PUT de tarefa por ID)

- Exclusão de tarefa (DELETE de tarefa por ID)

## 3. Tecnologias utilizadas:
- .NET Framework 4.8.1
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
cd mv-todolist
```

2. Abra a solução .sln (recomendado: com o visual studio):

3. Execute pelo Visual Studio, clicando no ícone de execução

* Nota: o pacote Microsoft.CodeDom.Providers.DotNetCompilerPlatform depende de alguns arquivos do compilador Roslyn, e como ela não é versionada, nem sempre o NuGet fará sua restauração automaticamente, causando o erro de "não foi possível localizar parte do caminho ...\bin\roslyn\csc.exe". Neste caso, execute no powershell ou pm:

```console
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -reinstall
Update-Package -reinstall
```

Com isso, executar o projeto novamente será o suficiente para que ele rode com sucesso

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

Com a API e o Frontend Angular rodando simultaneamente, o MV-to-do-list estará pronto para ser utilizado.
