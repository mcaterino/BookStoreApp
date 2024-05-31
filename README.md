# BookStoreApp

# BookStore.Api

BookStore.Api is a RESTful API built with ASP.NET Core. It provides a way to interact with a bookstore database, allowing you to manage books authors and publisher.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- .NET 8
- A SQL Server instance for the database

### Installation

1. Clone the repository

```sh
git clone https://github.com/yourusername/BookStore.Api.git
```

2. cd BookStore.Api

3. dotnet restore

4. Update the connection string in appsettings.json with your SQL Server instance details
5. Run the application : dotnet run

## Database Initialization

The application uses an `AppDbInitializer` to seed the database with initial data for authors, books, and publishers. This ensures that there is some data to work with when you first run the application.

When you run the application, the `AppDbInitializer` automatically checks if there is any data in the database. If the database is empty, the initializer adds some default authors, books, and publishers.

Please note that the `AppDbInitializer` is intended for development and testing purposes. In a production environment, you would likely use a different strategy for initializing the database and managing data.

Usage
The API has endpoints for managing books and authors. Here are some examples:

GET /api/books: Retrieves a list of all books
GET /api/books/{id}: Retrieves details of a specific book
POST /api/books: Creates a new book
PUT /api/books/{id}: Updates an existing book
DELETE /api/books/{id}: Deletes a book

Replace books with authors in the above endpoints to manage authors.
