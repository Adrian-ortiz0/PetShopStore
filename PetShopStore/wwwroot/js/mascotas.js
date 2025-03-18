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
    const formInstance = $("#formMascotaDueño").dxForm("instance");
    const formData = formInstance.option("formData");

    try {
        const response = await fetch("/Mascotas?handler=GuardarMascota", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(formData)
        });

        if (response.ok) {
            alert("Mascota guardada con éxito");
            location.reload();
        } else {
            const errorText = await response.text();
            alert(`Error al guardar la mascota: ${errorText}`);
        }
    } catch (error) {
        console.error("Error:", error);
        alert("Ocurrió un error inesperado");
    }
}