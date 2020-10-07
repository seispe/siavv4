$(document).ready(main);

var contador = 1;

function main() {
    //Moscar o ocultar Menu Principal
    $('.bt-menu').click(function () {
        if (contador == 1) {
            $('nav').animate({
                left: '0'
            });
            contador = 0;
        } else {
            contador = 1;
            $('nav').animate({
                left: '-100%'
            });
        }
    });

    //Mostramos y ocultamos submenus
    $(".submenu").click(function () {
        //$('.children').toggle("slow");
        $('.children').slideToggle();
        //$(this).children(".children").slideToggle();
        //$(this).children('.children').toggle("slow");
    });

    //Mostramos y ocultamos sub submenus
    $('.submenu2').click(function () {
        $(this).children('.children2').slideToggle();
    });

    //Ocultar la alerta cada 4 segundos
    $('.mensaje').fadeOut(8000);
}