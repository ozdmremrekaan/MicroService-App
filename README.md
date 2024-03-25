# Mango MicroService Project

## Overview

This MicroService project is developed using .NET Core 8 and utilizes MSSQL and RabbitMQ.

## Requirements

- .NET Core 8 SDK: [Download](https://dotnet.microsoft.com/download/dotnet-core/8)
- MSSQL Server
- RabbitMQ Server
- Code editor (e.g., Visual Studio Code, Visual Studio, JetBrains Rider)

## Installation

1. Clone the project repository:

    ```bash
    git clone https://github.com/username/MicroService-App.git
    ```

2. Navigate to the project directory:

    ```bash
    cd project
    ```

## Setup

### MSSQL

1. Ensure MSSQL Server is installed and running.

2. Configure the connection string in `appsettings.json` file to point to your MSSQL database.

### RabbitMQ

1. Ensure RabbitMQ Server is installed and running.

2. If necessary, update the RabbitMQ connection settings in `appsettings.json` file.

## Build and Run

Since this project follows a Microservices architecture, each microservice should be built and run separately. Follow these general steps to run each microservice:

1. Navigate to the directory of the microservice you want to run:
    ```bash
    cd microservice_directory
    ```

2. Build the microservice:
    ```bash
    dotnet build
    ```

3. Run the microservice:
    ```bash
    dotnet run --project MicroserviceName.csproj
    ```

Repeat these steps for each microservice in your project.
