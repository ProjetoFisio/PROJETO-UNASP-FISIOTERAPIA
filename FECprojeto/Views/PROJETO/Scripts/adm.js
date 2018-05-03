$(document).ready(() => {
    const $btnFisio = $("#btnFisio");
    const $btnPaci = $("#btnPaci");

    $("#formFisioterapeuta").hide();
        $("#formPaciente").hide();

    $($btnFisio).click(() => {
        $("#formFisioterapeuta").slideDown();
        $("#formPaciente").slideUp();
    });
    $($btnPaci).click(() => {
        $("#formFisioterapeuta").slideUp();
        $("#formPaciente").slideDown();
    });
    
}); 

    function sair(){ 
        const sair = confirm("Quer realmente encerrar a sessão?");
        if(sair === true){
            location.href = "../index.html";
        }   
    }
    function cadastrarPage(){
        location.href = "../Administracao/adm.html";
    }
    function gerenciar(){
        location.href = "../Administracao/adm_gerencia.html";
    }
    function reportarPage(){
        location.href = "../Administracao/adm_report.html";
    }