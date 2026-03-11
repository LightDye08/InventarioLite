# InventarioLite

## Requisitos previos
- .NET 8 SDK y Runtime
- Python 3.8 o superior (para scripts y servidor simple del frontend)
- SQLite (no requiere instalación, se usa archivo .db)

## Instrucciones para ejecutar el backend

1. Ve a la carpeta `backend`:
   ```sh
   cd backend
   ```
2. Restaura los paquetes y aplica las migraciones:
   ```sh
   dotnet restore
   export PATH="$PATH:$HOME/.dotnet/tools"  # Si usas dotnet-ef
   dotnet ef migrations add InitialCreate #No es necesario pero puede ser util en ciertas versiones de Dotnet 8
   dotnet ef database update
   ```
3. Ejecuta el backend:
   ```sh
   dotnet run
   ```
   El backend estará disponible en `http://localhost:5000`.

## Cómo ejecutar el frontend

1. Ve a la carpeta `frontend`:
   ```sh
   cd frontend
   ```
2. Ejecuta el servidor simple con Python:
   ```sh
   python servidor_frontend.py
   ```
3. Abre tu navegador y accede a [http://localhost:8080](http://localhost:8080)

## Cómo ejecutar el script en Python

1. Ve a la carpeta `scripts`:
   ```sh
   cd scripts
   ```
2. Instala las dependencias si es necesario:
   ```sh
   pip install requests
   ```
3. Para exportar productos a JSON:
   ```sh
   python exportar_productos.py
   ```
4. Para importar productos desde un CSV (debes crear el script `importar_productos.py`):
   ```sh
   python importar_productos.py
   ```
   El CSV debe tener las columnas: `Nombre,Precio`.

## Estructura del proyecto
```
ProductosApp/
├── backend/         # API REST en .NET 8 (C#)
│   ├── Controllers/
│   ├── Data/
│   ├── DTOs/
│   ├── Models/
│   ├── Repositories/
│   ├── Services/
│   ├── appsettings.json
│   ├── Program.cs
│   └── ...
├── frontend/        # HTML, CSS y JS nativo
│   ├── index.html
│   ├── app.js
│   └── servidor_frontend.py
├── scripts/         # Scripts Python para importar/exportar productos
│   ├── exportar_productos.py
│   └── importar_productos.py (a crear)
└── README.md
```

- El backend expone la API REST y usa SQLite como base de datos.
- El frontend consume la API y permite gestionar productos.
- Los scripts Python permiten importar desde CSV y exportar a JSON.
