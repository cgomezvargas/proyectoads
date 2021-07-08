<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
	<style type="text/css">
		.background {
			margin: 0;
			padding: 0;
			background-image: linear-gradient(130deg, rgba(0, 0, 0, 0.5) 0%, rgba(0, 0, 0, 0.5) 200%), url("../Content/Images/fondo.jpg");
			background-size: cover;
			font-family: sans-serif;
			height: 100vh;
		}

		.login-box {
			width: 330px;
			height: 580px;
			background: rgb(0,0,0,0.7);
			color: #fff;
			top: 50%;
			left: 50%;
			position: absolute;
			transform: translate(-50%, -50%);
			box-sizing: border-box;
			padding: 70px 30px;
		}

			.login-box .avatar {
				width: 110px;
				height: 110px;
				border-radius: 50%;
				position: absolute;
				top: -50px;
				left: calc(50% - 50px);
			}

			.login-box h1 {
				margin: 0;
				padding: 0 0 20px;
				text-align: center;
				font-size: 22px;
			}

			.login-box label {
				margin: 0;
				padding: 0;
				font-weight: bold;
				display: block;
			}

			.login-box input {
				width: 100%;
				margin-bottom: 20px;
			}

				.login-box input[type="text"], .login-box input[type="password"] {
					border: none;
					border-bottom: 1px solid #fff;
					background: transparent;
					outline: none;
					height: 40px;
					color: #fff;
					font-size: 16px;
				}

				.login-box input[type="submit"] {
					border: none;
					outline: none;
					height: 40px;
					background: #b80f22;
					color: #fff;
					font-size: 18px;
					border-radius: 20px;
				}

					.login-box input[type="submit"]:hover {
						cursor: pointer;
						background: #ffc107;
						color: #000;
					}

			.login-box a {
				position: relative;
				margin: 0 35%;
				font-size: 13px;
				line-height: 20px;
				color: darkgrey;
			}

				.login-box a:hover {
					color: #fff;
				}

		.select {
			margin: 15px 40px;
			width: 180px;
			height: 25px;
			background: #b80f22;
			color: white;
		}

		h2 {
			text-align: center;
			font-size: 35px;
		}
	</style>
</head>
<body class="background">
	<form id="login" runat="server">
		<div class="login-box">
			<h2>Solicitudes S.A</h2>
			<img src="../Content/Images/uaca.png" class="avatar" alt="Avatar Image">
			<h1>Inicie session</h1>
			<form>
				
				<asp:DropDownList ID="ddlRoles" runat="server"></asp:DropDownList>
				<label for="username">Usuario</label>
				<asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
				<label for="password">Contraseña</label>
				<asp:TextBox ID="txtContrasenna" runat="server" TextMode="Password"></asp:TextBox>

				<asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
				<%--TODO: AGREGAR PANTALLA DE REGISTRARSE
					<a href="./RegistroCliente.html" class="registrar">Registrarse</a>--%>
			</form>
		</div>
	</form>
</body>
</html>
