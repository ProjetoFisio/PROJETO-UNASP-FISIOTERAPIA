$(document).ready(()=> {

});

function sair(){ 
    const sair = confirm("Quer realmente encerrar a sessão?");
    if(sair === true){
        location.href = "../index.html";
    }   
}
function config(){
    location.href = "/Inicio/Config";
}