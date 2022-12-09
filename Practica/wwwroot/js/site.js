

$(function () {
    url = "https://localhost:7096/Home";

    $("#n-guardar").click(function () {
        onClickNuevo();
    });

});

async function onClickNuevo() {
    debugger
    console.log("Hola")
    $("#btn-aplicar-firma1").trigger("click");
    var fff = getFirma1();

    const data = {
        //Aquí eran tus demas campos, pero en el de la firma:
        firma: fff

    };
    await nuevo(data)
}

async function nuevo(data) {
    debugger
    console.log(data)
    $("#spinner").show();
    $("#n-guardar").prop('disabled', true);
    const path = url + '/nuevo';
    await fetch(path, {
        method: 'POST',
        body: JSON.stringify(data),
        headers: {
            'Content-type': 'application/json; charset=UTF-8',
        },
    })
        .then((response) => response.json())
        .then((res) => {
            $("#spinner").hide();
            if (res) {
                console.log(res);
                //$("#n-guardar").prop('disabled', false);
                //$('#modalRegistroSucces').modal('show');
                ////$("#titleMessage").text('Registro exitoso');
                ////$('#msgRegister').text('Solicitud registrada exitosamente con Folio: ');

            } else {
                console.log("Error")
            }
        })
        .catch(error => console.error('Unable to add item.', error));
}
