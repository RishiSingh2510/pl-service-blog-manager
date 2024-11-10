# Blog Manager Service

## Setup Instructions

1. **Clone the repository:**
    ```sh
    git clone https://github.com/RishiSingh2510/pl-service-blog-manager.git
    cd pl-service-blog-manager
    ```

2. **Install dependencies:**
    Ensure you have .NET 8 SDK installed. You can download it from the [official .NET website](https://dotnet.microsoft.com/download/dotnet/8.0).

3. **Restore NuGet packages:**
    ```sh
    dotnet restore
    ```

4. **Build the project:**
    ```sh
    dotnet build
    ```

## How to Run the Application

1. **Run the application:**
    ```sh
    dotnet run
    ```

2. **Access the API:**
    Open your browser or API client and navigate to `https://localhost:44382/` (or the URL specified in your launch settings).

## Design Decisions and Application Structure

### Design Decisions

- **Framework:** The project is built using .NET 8 to leverage the latest features and improvements in performance and security.
- **Architecture:** The application follows a clean architecture pattern to ensure separation of concerns and maintainability.
- **Dependency Injection:** Used extensively to manage dependencies and promote testability.
- **Entity Framework Core:** Chosen as the ORM for data access to simplify database interactions.

### Application Structure

- **Controllers:** Contains the API endpoints and handles HTTP requests.
- **Services:** Contains business logic and interacts with repositories.
- **Repositories:** Handles data access and database operations.
- **Models:** Defines the data structures used throughout the application.
- **Configurations:** Contains configuration settings and dependency injection setup.

For more details, visit the [repository](https://github.com/RishiSingh2510/pl-service-blog-manager).
