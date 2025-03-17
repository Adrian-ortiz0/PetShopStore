$(function () {
    $("#gridContainer").dxDataGrid({
        dataSource: "/Mascotas?handler=Mascotas",
        keyExpr: "id",
        columns: [
            { dataField: "id", caption: "ID", width: 50 },
            { dataField: "nombre", caption: "Nombre" },
            { dataField: "especie", caption: "Especie" },
            { dataField: "edad", caption: "Edad", dataType: "number" }
        ],
        showBorders: true,
        paging: { pageSize: 5 },
        filterRow: { visible: true },
        searchPanel: { visible: true }
    });
});

async function guardarMascota() {
    const mascota = {
        nombre: document.getElementById("nombre").value,
        especie: document.getElementById("especie").value,
        raza: document.getElementById("raza").value,
        fechaNacimiento: document.getElementById("fechaNacimiento").value,
        dueñoId: document.getElementById("dueñoId").value
    };

    try {
        const response = await fetch("/Mascotas?handler=GuardarMascota", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(mascota)
        });

        if (response.ok) {
            alert("Mascota guardada con éxito");
            location.reload();
        } else {
            alert("Error al guardar la mascota");
        }
    } catch (error) {
        console.error("Error:", error);
        alert("Ocurrió un error inesperado");
    }
}