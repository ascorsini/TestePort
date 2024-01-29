Public Class Empresa
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private _cnpj As String
    Public Property CNPJ() As String
        Get
            Return _cnpj
        End Get
        Set(ByVal value As String)
            _cnpj = value
        End Set
    End Property
    Private _selected As Boolean
    Public Property Selected() As Boolean
        Get
            Return _selected
        End Get
        Set(ByVal value As Boolean)
            _selected = value
        End Set
    End Property
    Private _associadoList As List(Of Associado)
    Public Property AssociadoList() As List(Of Associado)
        Get
            Return _associadoList
        End Get
        Set(ByVal value As List(Of Associado))
            _associadoList = value
        End Set
    End Property
End Class
