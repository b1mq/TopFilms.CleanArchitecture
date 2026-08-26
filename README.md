markdown_content = """# 🎬 TopFilms | Clean Architecture Movie Finder

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=for-the-badge&logo=asp.net&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/EF_Core-388E3C?style=for-the-badge&logo=c-sharp&logoColor=white)
![Bootstrap 5](https://img.shields.io/badge/Bootstrap_5-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean_Architecture-FF9900?style=for-the-badge)

A minimalist, scalable web application for finding and saving movies using the **OMDb API**. Built with C# and ASP.NET Core MVC, this project strictly adheres to the **Clean Architecture** principles introduced by Robert C. Martin (Uncle Bob).

## ✨ Features

- **OMDb API Integration**: Fetch real-time movie data (title, director, year, plot, poster, IMDb rating).
- **Local Persistence**: Save your favorite movies to a local SQL Server database.
- **Smart Validation**: Business logic prevents saving duplicate movies.
- **Modern UI**: A sleek, dark-themed, minimalist user interface built with Bootstrap 5 and Bootstrap Icons.
- **Robust Architecture**: Highly testable, maintainable, and decoupled codebase.

## 🏛 Architecture & Principles

This project is structured around **Clean Architecture**, ensuring that the core business logic (Domain) is completely isolated from external dependencies like databases, UI, or external APIs. 

### Layers
1. **Domain**: The core of the application. Contains the `Film` entity. It has zero dependencies on other layers or external libraries, maintaining pure business logic.
2. **Application**: The "orchestrator" layer. Contains interfaces (`IFilmRepository`, `IFinderService`, `IFilmManager`) and business use cases. It knows about the Domain but nothing about the Infrastructure or UI.
3. **Infrastructure**: The technical implementation layer. Contains Entity Framework Core configurations (`FilmContext`), SQL database repositories, and the external API HTTP client (`FinderService`).
4. **Web UI**: The presentation layer (ASP.NET Core MVC). Contains controllers and Razor views. It is extremely thin and delegates all business responsibilities to the Application layer.

### Applied Design Patterns
- **Repository Pattern**: Abstracts database operations, allowing the Application layer to work with data collections without knowing about SQL or EF Core.
- **Data Transfer Object (DTO)**: Used in the infrastructure layer (`OmdbMovieDto`) to map JSON responses seamlessly.
- **Anti-Corruption Layer (ACL)**: Protects the Domain by sanitizing, parsing, and mapping external OMDb API data before it reaches the core system.
- **Dependency Injection (DI)**: Follows the Inversion of Control principle to inject services and repositories loosely.
- **Typed HTTP Client**: Manages the lifecycle of external API requests safely and efficiently.

## 🚀 Getting Started

### Prerequisites
- .NET SDK (8.0 or newer)
- SQL Server LocalDB (or any SQL Server instance)
- Free OMDb API Key

### Installation

1. **Clone the repository**
   ```bash
   git clone [https://github.com/yourusername/TopFilms.git](https://github.com/yourusername/TopFilms.git)
   cd TopFilms
