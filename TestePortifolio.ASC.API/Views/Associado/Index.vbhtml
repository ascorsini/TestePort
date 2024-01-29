@ModelType IEnumerable(Of TestePortifolio.ASC.API.Associado)
@Code
    ViewData("Title") = "List"
End Code

<h2>Lista de Associados</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CPF)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DataNascimento)
        </th>
        <th></th>
    </tr>
    @If Model IsNot Nothing Then
        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Name)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.CPF)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.DataNascimento)
                </td>
                <td>
                    @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                    @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
                    @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
                </td>
            </tr>
        Next
    End If

</table>
