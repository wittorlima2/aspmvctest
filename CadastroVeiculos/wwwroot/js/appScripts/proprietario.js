var $;
var ProprietarioModule;
(function (ProprietarioModule) {
    var CEPDto = /** @class */ (function () {
        function CEPDto() {
        }
        return CEPDto;
    }());
    ProprietarioModule.CEPDto = CEPDto;
    var ProprietarioComponent = /** @class */ (function () {
        function ProprietarioComponent() {
        }
        ProprietarioComponent.prototype.getCep = function (cep) {
            fetch("https://brasilapi.com.br/api/cep/v1/".concat(cep)).then(function (res) { return res.json(); }).then(function (res) {
                var response = res;
                if (response != null) {
                    var endereco = "".concat(res.street, ", ").concat(res.neighborhood, ", ").concat(res.city, "-").concat(res.state);
                    $('#Endereco').val(endereco);
                }
            });
        };
        return ProprietarioComponent;
    }());
    ProprietarioModule.ProprietarioComponent = ProprietarioComponent;
})(ProprietarioModule || (ProprietarioModule = {}));
//# sourceMappingURL=proprietario.js.map