Globalize.culture('pt-BR');
$.validator.setDefaults({ onfocusout: false, ignore: "" });

$(function () {

    
    Globalize.culture('pt-BR');

    $.validator.methods.number = function (value, element) {
        if (this.optional(element) && (value === "" || value === "0"))
            return true;
        console.log(value);
        return !isNaN(Globalize.parseFloat(value));
    };

    jQuery.extend(jQuery.validator.methods, {
        range: function (value, element, param) {
            //Use the Globalization plugin to parse the value
            var val = Globalize.parseFloat(value);
            return this.optional(element) || (
                val >= param[0] && val <= param[1]);
        }
    });

});