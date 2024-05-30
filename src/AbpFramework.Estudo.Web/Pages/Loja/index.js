$(function () {

    $("#ProdutoFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    const getFilter = function () {
        const input = {};
        $("#ProdutoFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/ProdutoFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    const l = abp.localization.getResource('Estudo');

    const service = abpFramework.estudo.produtos.produto;
    const createModal = new abp.ModalManager(abp.appPath + 'Produtos/CreateModal');
    const editModal = new abp.ModalManager(abp.appPath + 'Produtos/EditModal');
    const detailsModal = new abp.ModalManager(abp.appPath + 'Produtos/DetailsModal');

    const dataTable = $('#ProdutoTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                text: "Detalhes",
                                action: function (data) {
                                    detailsModal.open({ id: data.record.id });
                                },
                                render: function (data, type, row, meta) {
                                    console.log("data", data);
                                    console.log("type", type);
                                    console.log("row", row);
                                    console.log("meta", meta);
                                }
                            },
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
                title: "Preço",
                data: "preco",
                render: function (data, type, row) {
                    return new Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL' }).format(data);
                }
            },
            {
                title: "Categoria",
                data: "categoria",
                render: function (categoria, type, row, meta) {
                    return categoria.nome;
                }
            },
            {
                title: "Fornecedor",
                data: "fornecedor",
                render: function (fornecedor, type, row, meta) {
                    return fornecedor.nome;
                }
            }
            //{
            //    title: "Imagem",
            //    data: "imagem",
            //    render: function (imagem, type, row, meta) {
            //        return '<img src="' + imagem + '" style="width: 100px; height: 100px"/>';
            //    }
            //}
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewProdutoButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});