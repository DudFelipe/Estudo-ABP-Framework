$(function () {

    $("#CategoriaFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    const getFilter = function () {
        const input = {};
        $("#CategoriaFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/CategoriaFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    const l = abp.localization.getResource('Estudo');

    const service = abpFramework.estudo.categorias.categoria;
    const createModal = new abp.ModalManager(abp.appPath + 'Categorias/CreateModal');
    const editModal = new abp.ModalManager(abp.appPath + 'Categorias/EditModal');

    const dataTable = $('#CategoriaTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
            }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCategoriaButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});