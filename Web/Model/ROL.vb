'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class ROL
    Public Property ID As Integer
    Public Property NOMBRE As String
    Public Property CODIGO As String
    Public Property MONTO_MINIMO_APROBACION As Nullable(Of Decimal)
    Public Property MONTO_MAXIMO_APROBACION As Nullable(Of Decimal)

    Public Overridable Property USUARIOs As ICollection(Of USUARIO) = New HashSet(Of USUARIO)

End Class
