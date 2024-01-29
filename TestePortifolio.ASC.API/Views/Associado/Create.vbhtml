@ModelType TestePortifolio.ASC.API.Associado
@Code
    ViewData("Title") = "Create"
End Code

<h2>Criar Associado</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Name, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.CPF, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.CPF, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.CPF, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.DataNascimento, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.DataNascimento, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.DataNascimento, "", New With {.class = "text-danger"})
        </div>
    </div>

    <br />
    <h4>Empresas do Associado</h4>
    <br />
    <div class="form-group">
        <table class="table">
            <tr>
                <th>
                    @Html.DisplayName("Name")
                </th>
                <th>
                    @Html.DisplayName("CNPJ")
                </th>
                <th>
                    @Html.DisplayName("Selected")
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
                        <td>
                            @Html.CheckBoxFor(Function(modelItem) InnerItem.Selected)
                        </td>
                    </tr>
                Next
            End If
        </table>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
</div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
