<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Proyecto_2016.FrontEnd.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <title>SoldariStock</title>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>
  <link href="../Content/style.css" rel="stylesheet" />
  <link rel="shortcut icon" type="image/x-icon" href="../images/favicon.ico"/>
  

</head>


<body>
     <form id="form1" runat="server">
     <div class="body"></div>
		<div class="grad"></div>
		<div class="header">
			<div>Soldari<span>Stock</span></div>
		</div>
		
		<div class="login">
				<input id="usuario" type="text" placeholder="Usuario" name="user"  runat="server" /><br/>
				<input id="contra" type="password" placeholder="Contraseña" name="password"  runat="server"/><br/>
				<input id="bt_inicioc" type="button" runat="server" onServerClick="bt_inicio_Click" value="Iniciar Sesión"  />
          
           

		</div>
  <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

     </form>

</body>

</html>
