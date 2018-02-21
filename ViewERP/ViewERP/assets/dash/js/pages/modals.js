//------------- modals.js -------------//
var Modals = function () {

    return {

        bootboxModal : function () {

            //Alert modal
            $('#alert-modal').click(function() {
                box = bootbox.dialog({
                    message: "This is custom alert",
                    title: "Alert!!!",
                    buttons: {
                        success: {
                          label: "Ok i got it",
                          className: "btn-primary btn-alt",
                          callback: function() {
                            //callback result
                          }
                        }
                    }
                }); 
                $('body').adminPlugin('centerModal');
                box.modal('show');
            });

            //Confirm modal
            $('#confirm-modal').click(function() {
                box = bootbox.confirm({
                    message: "Confirm results:",
                    title: "Are you sure ?",
                    callback: function(result) {
                        //callback result
                        alert(result);
                    }
                });
                $('body').adminPlugin('centerModal');
                box.modal('show');
            });

            //rompt modal
            $("#btnPagar").click(function () {
                debugger;
                box = bootbox.prompt({
                    title: "Ingrese un nombre a la semana a pagar (ejemplo:Nomina 12)",
                    callback: function(result) {
                        
                        $.ajax({
                            type: "POST",
                            url: NominaUrls.urlSetComisiones,
                            data: JSON.stringify({ nombreSemana: result }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                                if (data == 1)
                                {
                                    alert("Los folios fueron marcados como pagados");
                                }else
                                {
                                    alert("Hubo un error, por favor intente mas tarde!");
                                }
                                
                            },
                            error: function (err) {
                                alert("Error al setear la nómina");
                            }
                        });
                        //alert(result);
                    }
                });
                $('body').adminPlugin('centerModal');
                box.modal('show');
            });
        },

        // Ajax Modal
        ajaxModal : function () {
            $('#remote-modal').click(function(){
                $('#ajax-modal').modal({
                    show:true,
                    remote: 'ajax/remoteModal.html'
                });
            });        
        },

        // Video Modal
        videoModal : function () {
            function autoPlayYouTubeModal(){
                var trigger = $("body").find('[data-toggle="modal"]');
                trigger.click(function() {
                    var theModal = $(this).data( "target" ),
                    videoSRC = $(this).attr( "data-theVideo" ), 
                    videoSRCauto = videoSRC+"?autoplay=1" ;
                    $(theModal+' iframe').attr('src', videoSRCauto);
                    $(theModal+' button.close').click(function () {
                        $(theModal+' iframe').attr('src', videoSRC);
                    });   
                });
            }
            autoPlayYouTubeModal();  
        },
    }

}();

$(document).ready(function() {    
    Modals.bootboxModal(); //Activate bootbox modals
    Modals.ajaxModal(); //Activate ajaxModal
    Modals.videoModal(); //Activate videoModal
}); 