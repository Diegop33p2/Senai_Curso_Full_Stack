//efeito de esconder formulário de cadastro

$(document).ready(function(){
    
     $("#botao-cadastrar").click(function(){  //equivalente a: document.getElementById("botao_cadastrar").click
        $("#form-cadastrar").slideToggle("slow");
        $("#section-login").slideToggle("slow");//slideTogle esconde e amostra elemento. show/hide
        $("#botao-cadastrar").hide();
     });

})