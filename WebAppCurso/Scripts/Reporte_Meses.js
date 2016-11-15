$(document).ready(function () {
    document.getElementById("Reporte_MesesPdf").style.visibility = "hidden";
    $('#Reporte_Meses').click(function () {
        var Mes = document.getElementById("Mes").value;
        if (Mes == "Seleccione un Mes") {
            alert("Debe Seleccionar un Mes");
        }
        else {


            var data = "Mes=" + Mes;
            $.ajax({
                type: "GET",
                url: "/Reporte/Reportes_Meses",
                data: data,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    var tr;
                    var input;
                    var table
                    var input
                    table = $('<table  class="table table-bordered table-condensed table-hover table-striped"/> ');
                    table.append('<thead><tr><th>Usuario</th><th>PatrimonioFamiliar</th><th>Impuesto</th><th>Herederos</th><th>PatrimonioHeredar</th></tr></thead>');
                    var tbody = $('<tbody/>');
                    for (var i = 0; i < json.length; i++) {
                        tr = $('<tr/>');
                        tr.append("<td>" + json[i].Usuario + "</td>");
                        tr.append("<td>" + json[i].PatrimonioFamiliar + "</td>");
                        tr.append("<td>" + json[i].Impuesto + "</td>");
                        tr.append("<td>" + json[i].Herederos + "</td>");
                        tr.append("<td>" + json[i].PatrimonioHeredar + "</td>");
                        tbody.append(tr);
                        table.append(tbody);

                    }
                    
                    $('#Tabla').html(table);
                    
                }
                
            });
            document.getElementById("Reporte_MesesPdf").style.visibility = "visible";
        }
    });
});

