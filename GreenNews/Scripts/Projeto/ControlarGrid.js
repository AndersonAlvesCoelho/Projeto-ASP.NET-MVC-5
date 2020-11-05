
function configurarControles() {

    var traducao = {
        infos: "Exibir {{ctx.start}} até {{ctx.end}} de {{ctx.total}} registros",
        loading: "Carregando...",
        noResults: "Não há dados para exibir",
        refresh: "Atualizar",
        search: "Pesquisar"
    };

    var grid = $("#gridDados").bootgrid(
        {
            ajax: true,
            url: urlListar,
            labels: traducao,
            searchSettings: {
                characters: 4
            },
            formatters: {
                "acoes": function (column, row) {
                    return "<a href='#' class='btn btn-info' data-acao='Details' data-row-id='" + row.Id + "'> " +
                        " <span class='glyphicon glyphicon-list'></span> " +
                        "</a > " +
                        "<a href='#' class='btn btn-warning' data-acao='Edit' data-row-id='" + row.Id + "'> " +
                        " <span class='glyphicon glyphicon-edit'></span> " +
                        "</a > " +
                        "<a href='#' class='btn btn-danger' data-acao='Delete' data-row-id='" + row.Id + "'> " +
                        " <span class='glyphicon glyphicon-trash'></span> " +
                        "</a > ";
                }
            }

        });

    // configurar o click das option, abrindo a modal
    grid.on("loaded.rs.jquery.bootgrid", function () {
        grid.find("a.btn").each(function (index, elemento) {
            var botaoAcao = $(elemento);
            var acao = botaoAcao.data("acao");
            var idEntidade = botaoAcao.data("row-id");

            botaoAcao.on("click", function () {
                abrirModal(acao, idEntidade)
            });
        });
    });

    // ativar a modal
    $("a.btn").click(function () {
        var acao = $(this).data("action");
        abrirModal(acao);
    })
}

function abrirModal(acao, parametro) {
    var url = "/{ctrl}/{acao}/{parametro}";

    url = url.replace("{ctrl}", controller);
    url = url.replace("{acao}", acao);

    if (parametro != null) {
        url = url.replace("{parametro}", parametro);
    } else {
        url = url.replace("{parametro}", "");
    }

    $("#conteudoModal").load(url, function () {
        $("#minhaModal").modal('show');
    });
}