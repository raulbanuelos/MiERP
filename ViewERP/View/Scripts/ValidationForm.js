function ValidarAltaArticulo() {
    var _codigo = $("#txtCodigo").val();
    var _descripcionCorta = $("#txtDescripcionCorta").val();
    var _descripcionLarga = $("#txtDescripcionLarga").val();
    var _stockMinimo = $("#txtStockMinimo").val();
    var _stockMaximo = $("#txtStockMaximo").val();
    var _idCategoria = $("#cboCategorias").val();


    if (_idCategoria == "") {
        alert("Por favor seleccione una categoría.");
        return false;
    } else {
        if (_descripcionCorta == "") {
            alert("Por favor ingrese un valor para el campo descripción corta.");
            return false;
        } else {
            if (_descripcionLarga == "") {
                alert("Por favor ingrese un valor para el campo descripción larga.");
                return false;
            } else {
                if (_stockMinimo == "") {
                    alert("Por favor ingrese un valor para el campo stock mínimo.");
                    return false;
                }
                else {
                    if (_stockMaximo == "") {
                        alert("Por favor ingrese un valor para el campo stock máximo.");
                        return false;
                    } else {
                        if (_codigo == "") {
                            alert("No se puede guardar el articulo debido a que no se generó correctamente el código.");
                            return false;
                        } else {
                            return true;
                        }
                        
                    }
                }
            }
        }
    }
}

function ValidarAltaEntrada() {

    return true;
}

function ValidadAltaSalida() {
    return true;
}

function soloNumeros(e) {
    var key = window.Event ? e.which : e.keyCode
    return ((key >= 48 && key <= 57) || (key == 8))
}

function parseJsonDate(jsonDateString) {
    return new Date(parseInt(jsonDateString.replace('/Date(', '')));
}