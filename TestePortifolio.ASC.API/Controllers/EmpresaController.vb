Imports System.Web.Mvc

Namespace Controllers
    Public Class EmpresaController
        Inherits Controller

        ' GET: Empresa
        Function Index() As ActionResult
            Dim sql As String = "SELECT * FROM TB_Empresa"
            Dim tabela As DataTable = BancoDeDados.GetDataTable(sql)
            Dim entityList As List(Of Empresa) = New List(Of Empresa)

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim i As Integer = 0
                    For i = 0 To tabela.Rows.Count - 1 Step 1
                        Dim entityAux As Empresa = New Empresa
                        entityAux.Id = tabela.Rows(i).ItemArray(0)
                        entityAux.Name = tabela.Rows(i).ItemArray(1)
                        entityAux.CNPJ = tabela.Rows(i).ItemArray(2)
                        entityList.Add(entityAux)
                    Next
                End If
            End If

            Return View(entityList)
        End Function

        ' GET: Empresa/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Dim sql As String = "SELECT * FROM TB_Empresa WHERE Id = " + id.ToString
            Dim tabela As DataTable = BancoDeDados.GetDataTable(sql)
            Dim Entity As Empresa = New Empresa

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim entityAux As Empresa = New Empresa
                    entityAux.Id = tabela.Rows(0).ItemArray(0)
                    entityAux.Name = tabela.Rows(0).ItemArray(1)
                    entityAux.CNPJ = tabela.Rows(0).ItemArray(2)
                    Entity = entityAux
                End If
            End If

            sql = "SELECT * FROM TB_Associado WHERE Id in (SELECT IdAssociado FROM TB_AssociadoEmpresa Where IdEmpresa = " + id.ToString + ")"
            tabela = BancoDeDados.GetDataTable(sql)
            Dim EntityList As List(Of Associado) = New List(Of Associado)

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim i As Integer = 0
                    For i = 0 To tabela.Rows.Count - 1 Step 1
                        Dim entityAux As Associado = New Associado
                        entityAux.Id = tabela.Rows(i).ItemArray(0)
                        entityAux.Name = tabela.Rows(i).ItemArray(1)
                        entityAux.CPF = tabela.Rows(i).ItemArray(2)
                        entityAux.DataNascimento = tabela.Rows(0).ItemArray(3)
                        EntityList.Add(entityAux)
                    Next

                    Entity.AssociadoList = EntityList
                End If
            End If

            Return View(Entity)
        End Function

        ' GET: Empresa/Create
        Function Create() As ActionResult
            Dim sql As String = "SELECT * FROM TB_Associado"
            Dim tabela As DataTable = BancoDeDados.GetDataTable(sql)
            Dim EntityList As List(Of Associado) = New List(Of Associado)
            Dim Entity As Empresa = New Empresa

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim i As Integer = 0
                    For i = 0 To tabela.Rows.Count - 1 Step 1
                        Dim entityAux As Associado = New Associado
                        entityAux.Id = tabela.Rows(i).ItemArray(0)
                        entityAux.Name = tabela.Rows(i).ItemArray(1)
                        entityAux.CPF = tabela.Rows(i).ItemArray(2)
                        entityAux.DataNascimento = tabela.Rows(0).ItemArray(3)
                        EntityList.Add(entityAux)
                    Next

                    Entity.AssociadoList = EntityList
                End If
            End If

            Return View(Entity)
        End Function

        ' POST: Empresa/Create
        <HttpPost()>
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                Dim sql As String = "SELECT * FROM TB_Empresa WHERE CNPJ = '" + collection("CNPJ") + "'"
                Dim tabela As DataTable = BancoDeDados.GetDataTable(sql)

                If tabela.Rows.Count = 0 Then
                    sql = "INSERT INTO TB_Empresa VALUES ("
                    sql += "'" + collection("Name") + "'"
                    sql += ",'" + collection("CNPJ") + "')"
                    BancoDeDados.ExecuteNonQuery(sql)
                End If

                Return RedirectToAction("Index")
            Catch ex As Exception
                Return View(ex.Message)
            End Try
        End Function

        ' GET: Empresa/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Dim sql As String = "SELECT * FROM TB_Empresa Where Id = " + id.ToString
            Dim tabela As DataTable = BancoDeDados.GetDataTable(sql)
            Dim entity As Empresa = New Empresa

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim entityAux As Empresa = New Empresa
                    entityAux.Id = tabela.Rows(0).ItemArray(0)
                    entityAux.Name = tabela.Rows(0).ItemArray(1)
                    entityAux.CNPJ = tabela.Rows(0).ItemArray(2)
                    entity = entityAux
                End If
            End If

            sql = "SELECT * FROM TB_Associado e LEFT JOIN TB_AssociadoEmpresa ae on e.Id = ae.IdAssociado"
            tabela = BancoDeDados.GetDataTable(sql)
            Dim EntityList As List(Of Associado) = New List(Of Associado)

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim i As Integer = 0
                    For i = 0 To tabela.Rows.Count - 1 Step 1
                        Dim entityAux As Associado = New Associado
                        entityAux.Id = tabela.Rows(i).ItemArray(0)
                        entityAux.Name = tabela.Rows(i).ItemArray(1)
                        entityAux.CPF = tabela.Rows(i).ItemArray(2)
                        entityAux.DataNascimento = tabela.Rows(0).ItemArray(3)

                        If tabela.Rows(i).ItemArray(4) IsNot DBNull.Value Then
                            If tabela.Rows(i).ItemArray(4) = id.ToString Then
                                entityAux.Selected = True
                            End If
                        End If

                        EntityList.Add(entityAux)
                    Next

                    entity.AssociadoList = EntityList
                End If
            End If

            Return View(entity)
        End Function

        ' POST: Empresa/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                Dim sql As String = "UPDATE TB_Empresa SET "
                sql += "Name = '" + collection("Name") + "'"
                sql += ", CNPJ = '" + collection("CNPJ") + "'"
                BancoDeDados.ExecuteNonQuery(sql)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Empresa/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Dim sql As String = "SELECT * FROM TB_Empresa Where Id = " + id.ToString
            Dim tabela As DataTable = BancoDeDados.GetDataTable(sql)
            Dim entity As Empresa = New Empresa

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim entityAux As Empresa = New Empresa
                    entityAux.Id = tabela.Rows(0).ItemArray(0)
                    entityAux.Name = tabela.Rows(0).ItemArray(1)
                    entityAux.CNPJ = tabela.Rows(0).ItemArray(2)
                    entity = entityAux
                End If
            End If

            Return View(entity)
        End Function

        ' POST: Empresa/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                Dim sql As String = "DELETE FROM TB_AssociadoEmpresa Where IdEmpresa = " + id.ToString
                BancoDeDados.ExecuteNonQuery(sql)

                sql = "DELETE FROM TB_Empresa Where Id = " + id.ToString
                BancoDeDados.ExecuteNonQuery(sql)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace