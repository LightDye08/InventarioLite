import csv
import requests

API_URL = "http://localhost:5000/api/productos"

def importar_csv_a_api(csv_path):
    with open(csv_path, newline='', encoding='utf-8') as csvfile:
        reader = csv.DictReader(csvfile)
        for row in reader:
            data = {
                "nombre": row.get("Nombre"),
                "precio": float(row.get("Precio", 0))
            }
            try:
                response = requests.post(API_URL, json=data)
                if response.status_code == 201:
                    print(f"Producto registrado: {data['nombre']}")
                else:
                    print(f"Error al registrar {data['nombre']}: {response.status_code} {response.text}")
            except requests.exceptions.RequestException as e:
                print(f"Error de conexión: {e}")

if __name__ == "__main__":
    importar_csv_a_api("productos.csv")