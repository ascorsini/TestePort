@ModelType TestePortifolio.ASC.API.Empresa
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Editar Empresa</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    @Html.HiddenFor(Function(model) model.Id)

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Name, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.CNPJ, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.CNPJ, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.CNPJ, "", New With {.class = "text-danger"})
        </div>
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
            <th>
                @Html.DisplayName("Selected")
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
                    <td>
                        @Html.CheckBoxFor(Function(modelItem) InnerItem.Selected)
                    </td>
                </tr>
            Next
        End If

    </table>

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="Save" class="btn btn-default" />
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
