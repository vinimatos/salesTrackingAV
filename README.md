# Sales Tracking Application

This repository contains the code for a sales tracking application consisting of two main modules: the Frontend (web application) and the API (backend). Below are detailed instructions for setting up and running the application locally.

## Project Structure

- **Frontend:** Web application built with Angular  
  - **Path:** `/SalesTrackingWeb`

- **Backend (API):** Application built with .NET  
  - **Path:** `/SalesTracking`

## Prerequisites

Ensure you have the following prerequisites installed:

- [Node.js](https://nodejs.org/) to run the frontend (Angular)
- [Angular CLI](https://angular.io/cli) to manage and run the Angular application
- [.NET SDK](https://dotnet.microsoft.com/download) to run the API

## How to Run the Application

### 1. Running the Backend

1. Start the Docker containers:
    ```bash
    docker-compose up
    ```

2. Run the development server:
    ```bash
    dotnet run
    dotnet ef database update
    ```

3. Access the API in your browser or a tool like Postman.

### 2. Running the Frontend

1. Navigate to the frontend directory:
    ```bash
    cd SalesTrackingWeb
    ```

2. Install dependencies:
    ```bash
    npm install
    ```

3. Start the development server:
    ```bash
    ng serve
    ```

4. Access the application in your browser at `http://localhost:4200`.

---

## Notes

- **JWT Token:** The implementation of JWT token authentication has not been completed in this version. Future updates will address this feature.  
- **Unit Tests:** Some unit tests have been added to improve the reliability and maintainability of the codebase.
