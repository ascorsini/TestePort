@ModelType TestePortifolio.ASC.API.Empresa
@Code
    ViewData("Title") = "Details"
End Code

<h2>Detalhe Empresa</h2>

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
            @Html.DisplayNameFor(Function(model) model.CNPJ)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CNPJ)
        </dd>

    </dl>
</div>

<br />
<h4>Associados da Empresa</h4>
<br />

<table class="table">
    <tr>
        <th>
            @Html.DisplayName("Name")
        </th>
        <th>
            @Html.DisplayName("CPF")
        </th>
    </tr>

    @If Model.AssociadoList IsNot Nothing Then
        @For Each InnerItem In Model.AssociadoList
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) InnerItem.Name)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) InnerItem.CPF)
                </td>
            </tr>
        Next
    End If

</table>

<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
