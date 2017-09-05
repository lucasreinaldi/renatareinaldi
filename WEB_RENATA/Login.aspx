<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEB_RENATA.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>

<link rel="icon" href="favicon.png" type="image/png">
<link rel="shortcut icon" href="favicon.ico" type="img/x-icon">

<link href='https://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>
<link href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,800italic,700italic,600italic,400italic,300italic,800,700,600' rel='stylesheet' type='text/css'>

<link href="css/bootstrap.css" rel="stylesheet" type="text/css">
<link href="css/style.css" rel="stylesheet" type="text/css">
<link href="css/font-awesome.css" rel="stylesheet" type="text/css">
<link href="css/responsive.css" rel="stylesheet" type="text/css">
<link href="css/animate.css" rel="stylesheet" type="text/css">
<link href="CSS/style2.css" rel="stylesheet" />
<!--[if IE]><style type="text/css">.pie {behavior:url(PIE.htc);}</style><![endif]-->

<script type="text/javascript" src="js/jquery.1.8.3.min.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<script type="text/javascript" src="js/jquery-scrolltofixed.js"></script>
<script type="text/javascript" src="js/jquery.easing.1.3.js"></script>
<script type="text/javascript" src="js/jquery.isotope.js"></script>
<script type="text/javascript" src="js/wow.js"></script>
<script type="text/javascript" src="js/classie.js"></script>
<script src="contactform/contactform.js"></script>
</head>
<body>
    <form runat="server">





    <section runat="server" class="main-section paddind" id="Portfolio"><!--main-section-start-->
	<div class="container">
    	<h2>Login</h2>
    	 


        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnAdicionar">
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control input-text" placeholder="login"
                        MaxLength="50"></asp:TextBox>
                    
                    <asp:RegularExpressionValidator ID="validador2" Font-Size="Smaller"
                        runat="server" ErrorMessage="o e-mail precisa ser válido" CssClass="RegularExpression"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtNome" ValidationGroup="valServicos"></asp:RegularExpressionValidator>
                    

                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control input-text" placeholder="senha"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar uma descrição" CssClass="RequiredField" ControlToValidate="txtSenha" ValidationGroup="valServicos"></asp:RequiredFieldValidator>
            
                     
                <asp:LinkButton ID="btnAdicionar" runat="server" CssClass="btn btn-info"
                        CausesValidation="true" ValidationGroup="valServicos" >Logar</asp:LinkButton>

                <asp:LinkButton ID="btnCadastrar" runat="server" CssClass="btn btn-info"
                        CausesValidation="false">Cadastrar</asp:LinkButton>
                </asp:Panel>
       
         
        
	</div>
        </section>




        </form>

    </body>

</html>
