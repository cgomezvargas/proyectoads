<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarUsuarios.aspx.cs" Inherits="Web.Usuarios.EditarUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro</title>

    <style type="text/css">
        html {
	font-size: 16px;
    font-family: 'Lato', sans-serif;
}

body {
    background-image: linear-gradient(130deg, rgba(0, 0, 0, 0.5) 0%, rgba(0, 0, 0, 0.5) 200%), url("../Content/Images/fondo.jpg");
    background-size: cover;
}

.container {
	max-width: 650px;
	height: auto;
	background:rgb(0,0,0,0.7);
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

.form__reg {
	padding: 0 3rem;

}

.form__reg input{
	width: 25%;
}



.input, .btn__submit, .btn__reset{
	background-color: #EFEFEF;
	padding: .5rem;
	margin: .7rem .3rem;
	border: none;
	border-bottom: solid #C8C8C8 .2rem;
	transition: all .5s;
}

.input:focus {
	border-bottom: solid #F39B53 .2rem;
}

.btn__submit, .btn__reset {
	width: 40%;
	padding: .6rem;
	border-bottom: none;
	background-color: #0696d0;
	color: white;
}

.btn__reset {
	background-color: #b80f22;
}

.solicitud{
    text-align: center;
    margin: 12px auto;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
            <div class="container">
		<div class="form__top">
            <h2 class="solicitud">SOLICITUDES S.A</h2>
			<h2>REGISTRO <span> DE USUARIOS</span></h2>
		</div>		
		<form class="form__reg" action="">

			<asp:TextBox class="input"  ID="TextBox_ID" runat="server" Width="316px"></asp:TextBox>
            <asp:TextBox class="input"  ID="TextBox2" runat="server"></asp:TextBox>
            <asp:TextBox class="input" ID="TextBox3" runat="server"></asp:TextBox>
            <asp:TextBox class="input"  ID="TextBox4" runat="server"></asp:TextBox>
            <asp:TextBox class="input"  ID="TextBox5"   runat="server"></asp:TextBox>


            <asp:Button class="btn__submit" ID="Button1" runat="server" Text="REGISTRAR" />
          
            <asp:Button class="btn__reset" ID="Button2" runat="server" Text="SALIR" />

		</form>
	</div>
    </form>
</body>
</html>
