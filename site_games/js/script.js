//efeito do botão voltar ao Topo
function topo(){
    window.scrollTo(
        {
            top:0 , //substitui o bottom e o right do id voltar-topo pelo left e right 0
            left:0 ,
            behavior: "smooth"
        }
    )
}
//Validação de Login
function login(){
    var logado = 0;
    var usuario = document.getElementById("usuario").value;
    var senha = document.getElementById("senha").value;

    if(usuario == "diegop33" && senha == "12345678"){
        window.location = "index.html";
        logado = 1;
    }
    if(logado ==0){
        alert("Login negado,Verifique o usúario e a senha e tente novamente.")
    }
}
//Ativar alert no botão cadastrar
function cadastro(){
    alert("Cadastrado com sucesso!")
    window.location.href = "index.html"
}