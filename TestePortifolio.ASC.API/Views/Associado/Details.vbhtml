@ModelType TestePortifolio.ASC.API.Associado
@Code
    ViewData("Title") = "Details"
End Code

<h2>Detalhe do Associado</h2>

<div>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CPF)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CPF)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DataNascimento)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DataNascimento)
        </dd>

    </dl>
</div>

<br />
<h4>Empresas do Associado</h4>
<br />

<table class="table">
    <tr>
        <th>
            @Html.DisplayName("Name")
        </th>
        <th>
            @Html.DisplayName("CNPJ")
        </th>
    </tr>
        @If Model.EmpresaList IsNot Nothing Then
            @For Each InnerItem In Model.EmpresaList
                @<tr>
                    <td>
                        @Html.DisplayFor(Function(modelItem) InnerItem.Name)
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) InnerItem.CNPJ)
                    </td>
                </tr>
            Next
        End If
</table>

<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
