<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Requisicion.aspx.cs" Inherits="Web.Requisicion_Cliente.Requisicion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Requisiciones S.A</title>

    <style type="text/css">
        html {
            font-size: 16px;
            font-family: 'KLato', sans-serif;
        }

        body {
            background: url(../Content/Images/fondo.jpg) no-repeat center top;
            background-size: cover;
        }


        .container {
            max-width: 650px;
            height: auto;
            background: rgb(0,0,0,0.7);
            margin: 5% auto;
            padding-bottom: 1rem;
        }

        .form__top {
            width: 100%;
            text-align: center;
            padding: 2rem 0 1rem;
            border-top: solid .4rem #2e2d2d;
            margin-bottom: 1rem;
        }

            .form__top h2 {
                font-weight: bold;
                color: #c5c5c5;
                font-size: 18px;
            }

        h2 span {
            color: #c5c5c5
        }

        #form1 {
            padding: 0 3rem;
            display: flex;
            flex-wrap: wrap;
            flex-direction: column;
        }

        .input, .btn__submit, .btn__reset {
            background-color: #EFEFEF;
            padding: .5rem;
            margin: .7rem .3rem;
            width: 25%;
            border: none;
            border-bottom: solid #C8C8C8 .2rem;
            transition: all .5s;
        }

            .input:focus {
                border-bottom: solid #F39B53 .2rem;
            }

        .btn__submit, .btn__reset {
            width: 27.5%;
            padding: .6rem;
            border-bottom: none;
            background-color: #0696d0;
            color: white;
        }

        .btn__reset {
            background-color: #b80f22;
        }

        .solicitud {
            text-align: center;
            margin: 12px auto;
        }

        .auto-style1 {
            display: flex;
            flex-wrap: wrap;
            flex-direction: column;
            height: 218px;
        }
    </style>

</head>

<body>



            <div class="container">
        <div class="form__top">
            <h2 class="solicitud">SOLICITUDES S.A</h2>
            <h2>Ingrese los datos de su solictud</h2>
        </div>

    <form id="form1" runat="server">

        <asp:TextBox class="input" ID="id_Cliente" runat="server" ToolTip="Ingrese su ID" ></asp:TextBox>

        <asp:TextBox class="input" ID="monto_Valor" runat="server" ToolTip="Ingrese Monto" ></asp:TextBox>
  
        <asp:Button class="btn__submit" ID="Button_Crear" runat="server" Text="Crear solicitud" value="CREAR SOLICTUD" />

        <asp:Button class="btn__reset" ID="Button_Salir" runat="server" Text="Salir" value="SALIR" />


        </form>
    </div>
 
    



</body>
</html>
