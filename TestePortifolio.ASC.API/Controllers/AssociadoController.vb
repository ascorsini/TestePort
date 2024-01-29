Imports System.Reflection.Emit
Imports System.Web.Mvc

Namespace Controllers
    Public Class AssociadoController
        Inherits Controller

        ' GET: Associado
        Function Index() As ActionResult
            Dim sql As String = "SELECT * FROM TB_Associado"
            Dim tabela As DataTable = BancoDeDados.GetDataTable(sql)
            Dim EntityList As List(Of Associado) = New List(Of Associado)

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim i As Integer = 0
                    For i = 0 To tabela.Rows.Count - 1 Step 1
                        Dim entityAux As Associado = New Associado
                        entityAux.Id = tabela.Rows(i).ItemArray(0)
                        entityAux.Name = tabela.Rows(i).ItemArray(1)
                        entityAux.CPF = tabela.Rows(i).ItemArray(2)
                        entityAux.DataNascimento = tabela.Rows(i).ItemArray(3)
                        EntityList.Add(entityAux)
                    Next
                End If
            End If

            Return View(EntityList)
        End Function

        ' GET: Associado/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Dim sql As String = "SELECT * FROM TB_Associado WHERE Id = " + id.ToString
            Dim tabela As DataTable = BancoDeDados.GetDataTable(sql)
            Dim Entity As Associado = New Associado

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim entityAux As Associado = New Associado
                    entityAux.Id = tabela.Rows(0).ItemArray(0)
                    entityAux.Name = tabela.Rows(0).ItemArray(1)
                    entityAux.CPF = tabela.Rows(0).ItemArray(2)
                    entityAux.DataNascimento = tabela.Rows(0).ItemArray(3)
                    Entity = entityAux
                End If
            End If

            sql = "SELECT * FROM TB_Empresa WHERE Id in (SELECT IdEmpresa FROM TB_AssociadoEmpresa Where IdAssociado = " + id.ToString + ")"
            tabela = BancoDeDados.GetDataTable(sql)
            Dim EntityList As List(Of Empresa) = New List(Of Empresa)

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim i As Integer = 0
                    For i = 0 To tabela.Rows.Count - 1 Step 1
                        Dim entityAux As Empresa = New Empresa
                        entityAux.Id = tabela.Rows(i).ItemArray(0)
                        entityAux.Name = tabela.Rows(i).ItemArray(1)
                        entityAux.CNPJ = tabela.Rows(i).ItemArray(2)
                        EntityList.Add(entityAux)
                    Next

                    Entity.EmpresaList = EntityList
                End If
            End If

            Return View(Entity)
        End Function

        ' GET: Associado/Create
        Function Create() As ActionResult
            Dim sql As String = "SELECT * FROM TB_Empresa"
            Dim tabela As DataTable = BancoDeDados.GetDataTable(sql)
            Dim EntityList As List(Of Empresa) = New List(Of Empresa)
            Dim Entity As Associado = New Associado

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim i As Integer = 0
                    For i = 0 To tabela.Rows.Count - 1 Step 1
                        Dim entityAux As Empresa = New Empresa
                        entityAux.Id = tabela.Rows(i).ItemArray(0)
                        entityAux.Name = tabela.Rows(i).ItemArray(1)
                        entityAux.CNPJ = tabela.Rows(i).ItemArray(2)
                        EntityList.Add(entityAux)
                    Next

                    Entity.EmpresaList = EntityList
                End If
            End If

            Return View(Entity)
        End Function

        ' POST: Associado/Create
        <HttpPost()>
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                Dim sql As String = "SELECT * FROM TB_Associado WHERE CPF = '" + collection("CPF") + "'"
                Dim tabela As DataTable = BancoDeDados.GetDataTable(sql)

                If tabela.Rows.Count = 0 Then
                    sql = "INSERT INTO TB_Associado VALUES ("
                    sql += "'" + collection("Name") + "'"
                    sql += ",'" + collection("CPF") + "'"
                    sql += ",'" + Convert.ToDateTime(collection("DataNascimento")) + "')"
                    BancoDeDados.ExecuteNonQuery(sql)
                End If

                Return RedirectToAction("Index")
            Catch ex As Exception
                Return View(ex.Message)
            End Try
        End Function

        ' GET: Associado/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Dim sql As String = "SELECT * FROM TB_Associado Where Id = " + id.ToString
            Dim tabela As DataTable = BancoDeDados.GetDataTable(sql)
            Dim entity As Associado = New Associado

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim entityAux As Associado = New Associado
                    entityAux.Id = tabela.Rows(0).ItemArray(0)
                    entityAux.Name = tabela.Rows(0).ItemArray(1)
                    entityAux.CPF = tabela.Rows(0).ItemArray(2)
                    entityAux.DataNascimento = tabela.Rows(0).ItemArray(3)
                    entity = entityAux
                End If
            End If

            sql = "SELECT * FROM TB_Empresa e LEFT JOIN TB_AssociadoEmpresa ae on e.Id = ae.IdEmpresa"
            tabela = BancoDeDados.GetDataTable(sql)
            Dim EntityList As List(Of Empresa) = New List(Of Empresa)

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim i As Integer = 0
                    For i = 0 To tabela.Rows.Count - 1 Step 1
                        Dim entityAux As Empresa = New Empresa
                        entityAux.Id = tabela.Rows(i).ItemArray(0)
                        entityAux.Name = tabela.Rows(i).ItemArray(1)
                        entityAux.CNPJ = tabela.Rows(i).ItemArray(2)

                        If tabela.Rows(i).ItemArray(4) IsNot DBNull.Value Then
                            If tabela.Rows(i).ItemArray(4) = id.ToString Then
                                entityAux.Selected = True
                            End If
                        End If

                        EntityList.Add(entityAux)
                    Next

                    entity.EmpresaList = EntityList
                End If
            End If

            Return View(entity)
        End Function

        ' POST: Associado/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                Dim sql As String = "UPDATE TB_Associado SET "
                sql += "Name = '" + collection("Name") + "'"
                sql += ", CPF = '" + collection("CPF") + "'"
                sql += ", DataNascimento = '" + Convert.ToDateTime(collection("DataNascimento")) + "'"
                BancoDeDados.ExecuteNonQuery(sql)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Associado/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Dim sql As String = "SELECT * FROM TB_Associado Where Id = " + id.ToString
            Dim tabela As DataTable = BancoDeDados.GetDataTable(sql)
            Dim entity As Associado = New Associado

            If tabela IsNot Nothing Then
                If tabela.Rows.Count > 0 Then
                    Dim entityAux As Associado = New Associado
                    entityAux.Id = tabela.Rows(0).ItemArray(0)
                    entityAux.Name = tabela.Rows(0).ItemArray(1)
                    entityAux.CPF = tabela.Rows(0).ItemArray(2)
                    entityAux.DataNascimento = tabela.Rows(0).ItemArray(3)
                    entity = entityAux
                End If
            End If

            Return View(entity)
        End Function

        ' POST: Associado/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                Dim sql As String = "DELETE FROM TB_AssociadoEmpresa Where IdAssociado = " + id.ToString
                BancoDeDados.ExecuteNonQuery(sql)

                sql = "DELETE FROM TB_Associado Where Id = " + id.ToString
                BancoDeDados.ExecuteNonQuery(sql)
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace