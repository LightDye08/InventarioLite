import csv
import requests
import os
import sys
from tkinter import Tk, filedialog

API_URL = "http://localhost:5000/api/productos"

def seleccionar_archivo():
    """Abre un diálogo para seleccionar un archivo CSV."""
    root = Tk()
    root.withdraw()
    archivo = filedialog.askopenfilename(
        title="Selecciona el archivo CSV",
        filetypes=[("Archivos CSV", "*.csv"), ("Todos los archivos", "*.*")]
    )
    root.destroy()
    return archivo

def importar_csv_a_api(csv_path):
    if not os.path.isfile(csv_path):
        print(f"Error: El archivo '{csv_path}' no existe.")
        return

    exitosos = 0
    fallidos = 0

    with open(csv_path, newline='', encoding='utf-8') as csvfile:
        lector = csv.DictReader(csvfile)
        # Normalizar nombres de columnas
        lector.fieldnames = [nombre.strip().lower() for nombre in lector.fieldnames]

        col_nombre = next((col for col in lector.fieldnames if 'nombre' in col), None)
        col_precio = next((col for col in lector.fieldnames if 'precio' in col), None)

        if not col_nombre or not col_precio:
            print("Error: No se encontraron las columnas 'nombre' y 'precio' en el CSV.")
            print("Columnas detectadas:", lector.fieldnames)
            return

        for fila in lector:
            nombre = fila.get(col_nombre, '').strip()
            precio_str = fila.get(col_precio, '').strip()

            if not nombre:
                print("Advertencia: Fila sin nombre, se omite.")
                fallidos += 1
                continue

            try:
                precio = float(precio_str) if precio_str else 0.0
            except ValueError:
                print(f"Advertencia: Precio inválido para '{nombre}' (valor: '{precio_str}'), se omite.")
                fallidos += 1
                continue

            data = {"nombre": nombre, "precio": precio}

            try:
                response = requests.post(API_URL, json=data)
                if response.status_code == 201:
                    print(f"Producto registrado: {nombre}")
                    exitosos += 1
                else:
                    print(f"Error al registrar {nombre}: {response.status_code} {response.text}")
                    fallidos += 1
            except requests.exceptions.RequestException as e:
                print(f"Error de conexión al enviar {nombre}: {e}")
                fallidos += 1

    print(f"\n--- Resumen ---")
    print(f"Registros exitosos: {exitosos}")
    print(f"Registros fallidos: {fallidos}")

if __name__ == "__main__":
    ruta_csv = seleccionar_archivo()
    if not ruta_csv:
        print("No se seleccionó ningún archivo. Saliendo.")
        sys.exit(1)
    importar_csv_a_api(ruta_csv)
