﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Partial Public Class ProyectoEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=ProyectoEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property ESTADOes() As DbSet(Of ESTADO)
    Public Overridable Property REQUISICIONs() As DbSet(Of REQUISICION)
    Public Overridable Property ROLs() As DbSet(Of ROL)
    Public Overridable Property USUARIOs() As DbSet(Of USUARIO)

End Class