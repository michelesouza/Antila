//Mask de CNPJ 
$(".cnpj").inputmask("99.999.999/9999-99");
$(".inputCodigo").inputmask('999999', { numericInput: true, placeholder: '000000' });
$(".inputCodigo9").inputmask('999999999', { numericInput: true, placeholder: '000000000' });

//Mask de CEP 
$(".cep").inputmask("99999-999");

//Mask de Porcentagem 
$(".porcentagem").inputmask("99,99");

//Mask Telefone

$(".TelefoneCelular").inputmask("(99)99999-9999");
$(".TelefoneResidencial").inputmask("(99)9999-9999");
$(".TelefoneComercial").inputmask("(99)9999-9999");

// Mask Email

$(".email").inputmask(" {1,20} @ {1,20}. * {3}");

// Mask Data 

$(".data").inputmask(" 99/99/9999");

//Mask de Dinheiro
$(".money").maskMoney({
    prefix: "",
    decimal: ",",
    thousands: "."
});


//Script de Endereço
window.onload = function () {
    $("#voltar").attr("href", document.referrer);

    $("#selPais").change(function () {
        listaEstados($(this).val());
    });


    $("#selEstado").change(function () {
        listaCidade($(this).val());
    });


    $(".cep").inputmask("99999-999");
    $(".dataPicker").inputmask("99/99/9999");

};

function listaEstados(id) {

    $.getJSON('/Endereco/ListaEstados/' + id, listaEstadoCallBack);
}

function listaEstadoCallBack(json) {

    $("#selEstado :gt(0)").remove();
    $(json).each(function () {

        $("#selEstado").append("<option value='" + this.Id + "'>" + this.Nome + "</option>");
    });
}


//chamada ajax para a Action ListaCidade
//passando como parâmetro a Estado selecionado
function listaCidade(uf) {

    $.getJSON('/Endereco/ListaCidade/' + uf, listaCidadeCallBack);
}

//função que irá ser chamada quando terminar
//a chamada ajax
function listaCidadeCallBack(json) {
    //Limpar os itens que são maiores que 0
    //Ou seja: não retirar o primeiro item
    $("#selCidade :gt(0)").remove();
    $(json).each(function () {
        //adicionando as opções de acordo com o retorno
        $("#selCidade").append("<option value='" + this.Id + "'>" + this.Nome + "</option>");
    });
}

//
function onlynumber(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    //var regex = /^[0-9.,]+$/;
    var regex = /^[0-9.]+$/;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}
//
