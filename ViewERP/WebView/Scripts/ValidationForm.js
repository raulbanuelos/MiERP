function ValidarAltaArticulo() {
    var _codigo = $("#txtCodigo").val();
    var _descripcionCorta = $("#txtDescripcionCorta").val();
    var _descripcionLarga = $("#txtDescripcionLarga").val();
    var _stockMinimo = $("#txtStockMinimo").val();
    var _stockMaximo = $("#txtStockMaximo").val();
    var _idCategoria = $("#cboCategorias").val();

    var _precioUnidad = $("#txtPrecioUnidad").val();
    var _precioMaster = $("#txtPrecioMaster").val();
    var _precioPromotor = $("#txtPrecioPromotor").val();
    var _precioGerente = $("#txtPrecioGerente").val();

    


    if (_idCategoria == "" || _idCategoria == 0) {
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
                            if (_precioUnidad == "") {
                                alert("Por favor ingrese un valor para el campo precio unidad.");
                                return false;
                            } else {
                                if (_precioMaster == "") {
                                    alert("Por favor ingrese un valor para el campo precio master.");
                                    return false;
                                } else {
                                    if (_precioPromotor == "") {
                                        alert("Por favor ingrese un valor para el campo precio promotor.");
                                        return false;
                                    } else {
                                        if (_precioGerente == "") {
                                            alert("Por favor ingrese un valor para el campo precio Gerente.");
                                            return false;
                                        } else {
                                            return true;
                                        }
                                    }
                                }
                            }
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

function filterFloat(evt, input) {
    // Backspace = 8, Enter = 13, ‘0′ = 48, ‘9′ = 57, ‘.’ = 46, ‘-’ = 43
    var key = window.Event ? evt.which : evt.keyCode;
    var chark = String.fromCharCode(key);
    var tempValue = input.value + chark;
    if (key >= 48 && key <= 57) {
        if (filter(tempValue) === false) {
            return false;
        } else {
            return true;
        }
    } else {
        if (key == 8 || key == 13 || key == 0) {
            return true;
        } else if (key == 46) {
            if (filter(tempValue) === false) {
                return false;
            } else {
                return true;
            }
        } else {
            return false;
        }
    }
}
function filter(__val__) {
    var preg = /^([0-9]+\.?[0-9]{0,2})$/;
    if (preg.test(__val__) === true) {
        return true;
    } else {
        return false;
    }

}

