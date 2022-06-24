var $: any;
module ProprietarioModule {
    export class CEPDto {
        cep: string;
        state: string;
        city: string;
        neighborhood: string;
        street: string;
    }

    export class ProprietarioComponent {
        getCep(cep: string) {
            fetch(`https://brasilapi.com.br/api/cep/v1/${cep}`).then(res => res.json()).then(res => {
                var response: CEPDto = res;
                if (response != null) {
                    let endereco = `${res.street}, ${res.neighborhood}, ${res.city}-${res.state}`;
                    $('#Endereco').val(endereco);
                }
            });
        }

    }
}