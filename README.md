# Project Name

## Overview

This project is developed using .NET Core 8 and utilizes MSSQL and RabbitMQ.

## Requirements

- .NET Core 8 SDK: [Download](https://dotnet.microsoft.com/download/dotnet-core/8)
- MSSQL Server
- RabbitMQ Server
- Code editor (e.g., Visual Studio Code, Visual Studio, JetBrains Rider)

## Installation

1. Clone the project repository:

    ```bash
    git clone https://github.com/username/project.git
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

1. Build the project:

    ```bash
    dotnet build
    ```

2. Run the project:

    ```bash
    dotnet run --project ProjectName.csproj
    ```

## Tests

To run the tests associated with the project, execute the following command:

```bash
dotnet test
