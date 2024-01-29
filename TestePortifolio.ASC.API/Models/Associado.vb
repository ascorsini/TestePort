Public Class Associado
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
    Private _cpf As String
    Public Property CPF() As String
        Get
            Return _cpf
        End Get
        Set(ByVal value As String)
            _cpf = value
        End Set
    End Property
    Private _dataNascimento As DateTime
    Public Property DataNascimento() As DateTime
        Get
            Return _dataNascimento
        End Get
        Set(ByVal value As DateTime)
            _dataNascimento = value
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
    Private _empresaList As List(Of Empresa)
    Public Property EmpresaList() As List(Of Empresa)
        Get
            Return _empresaList
        End Get
        Set(ByVal value As List(Of Empresa))
            _empresaList = value
        End Set
    End Property
End Class
