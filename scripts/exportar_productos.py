import requests
import json

API_URL = "http://localhost:5000/api/productos"

def exportar_a_json(json_path):
    try:
        response = requests.get(API_URL)
        response.raise_for_status()
        productos = response.json()
        with open(json_path, "w", encoding="utf-8") as f:
            json.dump(productos, f, ensure_ascii=False, indent=2)
        print(f"Exportados {len(productos)} productos a {json_path}")
    except requests.exceptions.RequestException as e:
        print(f"Error de conexión: {e}")

if __name__ == "__main__":
    exportar_a_json("productos_exportados.json")