# TaskApi - ASP.NET Core Web API

Welcome to the TaskApi repository! This project demonstrates an ASP.NET Core Web API that manages user accounts and todos. It incorporates authentication, authorization, and uses Entity Framework Core for data management.

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

## Getting Started

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/yourusername/TaskApi.git
   cd TaskApi
   dotnet run
   
## API Endpoints
# AccountController:
POST /api/account/login: User login.

POST /api/account/register: User registration.

GET /api/account: Get current user's information.

# TodosController:
GET /api/todos: Get all todos.

GET /api/todos/{id}: Get a todo by ID.

POST /api/todos: Create a new todo.

PUT /api/todos/{id}: Update a todo.

DELETE /api/todos/{id}: Delete a todo.

## Unit Tests
This repository includes unit tests for the TodosController using xUnit and an in-memory database for testing purposes. Run the tests with:
``bash
dotnet test


