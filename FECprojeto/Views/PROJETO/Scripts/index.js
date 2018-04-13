$(document).ready(() => {
    const $sobreBtn = document.getElementById("sobreBtn");
    const $loginBtn = document.getElementById("loginBtn");
    $("#sobreContent").hide();
    $($sobreBtn).click(function() {
        $('.form').hide();
        $('#sobreContent').show();
    } );
    $($loginBtn).click(function() {
        $('.form').show();
        $('#sobreContent').hide();
    } );
});