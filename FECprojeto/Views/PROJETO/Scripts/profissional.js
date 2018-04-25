$(document).ready(() => {
    const modal = document.getElementById("modal");

    $("#EnviarMensagem").on('click', () => {
        modal.style.display = "block";
    });
    $("#fechar").on('click', () => {
        modal.style.display = "none";
    });
});