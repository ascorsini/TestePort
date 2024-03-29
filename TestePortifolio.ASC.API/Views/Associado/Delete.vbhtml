﻿@ModelType TestePortifolio.ASC.API.Associado
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Deletar Associado</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
