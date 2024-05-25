$(function () {

    $("#FornecedorFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    const getFilter = function () {
        const input = {};
        $("#FornecedorFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/FornecedorFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    const l = abp.localization.getResource('Estudo');

    const service = abpFramework.estudo.fornecedores.fornecedor;
    const createModal = new abp.ModalManager(abp.appPath + 'Fornecedores/CreateModal');
    const editModal = new abp.ModalManager(abp.appPath + 'Fornecedores/EditModal');

    const dataTable = $('#FornecedorTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: "Alterar",
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                },
                                render: function (data, type, row, meta) {
                                    console.log("data", data);
                                    console.log("type", type);
                                    console.log("row", row);
                                    console.log("meta", meta);
                                }
                            },
                            {
                                text: "Excluir",
                                confirmMessage: function (data) {
                                    return "Tem certeza de que deseja excluir?"
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: "Nome",
                data: "nome"
            },
            {
                title: "Descrição",
                data: "descricao"
            },
            {
                title: "CNPJ",
                data: "cnpj",
                render: function (data, type, row, meta) {
                    return FormataCnpj(data);
                }
            }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewFornecedorButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});

function FormataCnpj(v) {
    if (!v) return
    v = v.replace(/\D/g, "")                           //Remove tudo o que não é dígito
    v = v.replace(/^(\d{2})(\d)/, "$1.$2")             //Coloca ponto entre o segundo e o terceiro dígitos
    v = v.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3") //Coloca ponto entre o quinto e o sexto dígitos
    v = v.replace(/\.(\d{3})(\d)/, ".$1/$2")           //Coloca uma barra entre o oitavo e o nono dígitos
    v = v.replace(/(\d{4})(\d)/, "$1-$2")              //Coloca um hífen depois do bloco de quatro dígitos
    return v
}