$(document).ready(()=> {

});

function sair(){ 
    const sair = confirm("Quer realmente encerrar a sessão?");
    if(sair === true){
        location.href = "../index.html";
    }   
}
function config(){
    location.href = "../Principal/Configuracao/configuracao.html";
}
function videoSourcePage(){
    location.href = "../Principal/videoSource.html";
}
function artigosSource(){
    location.href = "../Principal/artigoSource.html";
}
function profissionalSource(){
    location.href = "../Principal/profissionalSource.html";
}