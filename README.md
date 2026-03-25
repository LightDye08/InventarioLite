# InventarioLite (Inventory Lite)

## About the Project

**InventarioLite (Inventory Lite)** is a lightweight inventory management system designed to manage products in a simple and efficient way.

It follows a full-stack structure:

* A **.NET 8 REST API backend** that handles business logic and data persistence.
* A **minimal frontend** built with plain HTML, CSS, and JavaScript to interact with the API.
* **Python scripts** for importing and exporting product data.

This project is ideal for learning purposes, small-scale inventory systems, or as a base template for more advanced applications.

---

## Prerequisites

* .NET 8 SDK and Runtime
* Python 3.8 or higher (for scripts and frontend server)
* SQLite (no installation required, uses a `.db` file)

---

## Running the Backend

1. Navigate to the `backend` folder:

   ```sh
   cd backend
   ```

2. Restore packages and apply migrations:

   ```sh
   dotnet restore
   export PATH="$PATH:$HOME/.dotnet/tools"  # If using dotnet-ef
   dotnet ef migrations add InitialCreate # Not required, but useful in some .NET 8 setups
   dotnet add package Swashbuckle.AspNetCore # Optional, some installations may not include it
   dotnet ef database update
   ```

3. Run the backend:

   ```sh
   dotnet run
   ```

   The backend will be available at:
   `http://localhost:5000`

---

## Running the Frontend

1. Navigate to the `frontend` folder:

   ```sh
   cd frontend
   ```

2. Run the simple Python server:

   ```sh
   python servidor_frontend.py
   ```

3. Open your browser and go to:
   [http://localhost:8080](http://localhost:8080)

---

## Running Python Scripts

1. Navigate to the `scripts` folder:

   ```sh
   cd scripts
   ```

2. Install dependencies if needed:

   ```sh
   pip install requests
   ```

3. Export products to JSON:

   ```sh
   python exportar_productos.py
   ```

4. Import products from a CSV file (you need to create this script):

   ```sh
   python importar_productos.py
   ```

   The CSV file must include the following columns:
   `Nombre,Precio` (Name, Price)

---

## Project Structure

```
ProductosApp/
├── backend/         # .NET 8 REST API (C#)
│   ├── Controllers/
│   ├── Data/
│   ├── DTOs/
│   ├── Models/
│   ├── Repositories/
│   ├── Services/
│   ├── appsettings.json
│   ├── Program.cs
│   └── ...
├── frontend/        # Plain HTML, CSS, and JavaScript
│   ├── index.html
│   ├── app.js
│   └── servidor_frontend.py
├── scripts/         # Python scripts for import/export
│   ├── exportar_productos.py
│   └── importar_productos.py (to be created)
└── README.md
```

---

## Architecture Overview

* The **backend** exposes a REST API and uses SQLite as the database.
* The **frontend** consumes the API and allows product management.
* The **Python scripts** enable importing from CSV and exporting to JSON.

---

## Demo Video

[https://github.com/user-attachments/assets/b5a7c553-162e-4df3-8d1e-fbf9a2bc1613](https://github.com/user-attachments/assets/b5a7c553-162e-4df3-8d1e-fbf9a2bc1613)

---
