@ModelType IEnumerable(Of TestePortifolio.ASC.API.Empresa)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Lista de Empresas</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CNPJ)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Name)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.CNPJ)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
            </td>
        </tr>
    Next

</table>
