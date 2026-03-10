const API = "http://localhost:5000/api/productos";

async function cargarProductos() {

    const res = await fetch(API);
    const productos = await res.json();

    const tabla = document.getElementById("tablaProductos");
    tabla.innerHTML = "";

    productos.forEach(p => {

        tabla.innerHTML += `
        <tr>
            <td>${p.id}</td>
            <td>${p.nombre}</td>
            <td>${p.precio}</td>
            <td>
                <button onclick="editar(${p.id}, '${p.nombre}', ${p.precio})">Editar</button>
                <button onclick="eliminar(${p.id})">Eliminar</button>
            </td>
        </tr>
        `;
    });
}

document.getElementById("productoForm").addEventListener("submit", async (e)=>{

    e.preventDefault();

    const id = document.getElementById("productoId").value;
    const nombre = document.getElementById("nombre").value;
    const precio = document.getElementById("precio").value;

    if(precio <= 0){
        alert("El precio debe ser mayor a 0");
        return;
    }

    const producto = {nombre, precio};

    if(id){

        await fetch(`${API}/${id}`,{
            method:"PUT",
            headers:{"Content-Type":"application/json"},
            body:JSON.stringify({...producto,id:parseInt(id)})
        });

    }else{

        await fetch(API,{
            method:"POST",
            headers:{"Content-Type":"application/json"},
            body:JSON.stringify(producto)
        });

    }

    document.getElementById("productoForm").reset();
    cargarProductos();
});

function editar(id,nombre,precio){

    document.getElementById("productoId").value=id;
    document.getElementById("nombre").value=nombre;
    document.getElementById("precio").value=precio;
}

async function eliminar(id){

    await fetch(`${API}/${id}`,{
        method:"DELETE"
    });

    cargarProductos();
}

cargarProductos();
