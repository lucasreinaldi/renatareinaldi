<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="WEB_RENATA.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CADASTRO</title>

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
    	<h2>Cadastro</h2>
    	 


        <asp:Panel ID="Panel1" runat="server" DefaultButton="LinkButton1">

                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control input-text" placeholder="nome"
                        MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar um nome" CssClass="RequiredField" ControlToValidate="txtNome" ValidationGroup="valCadastro"></asp:RequiredFieldValidator>
            

                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-text" placeholder="email"
                        MaxLength="100"></asp:TextBox>                    
                    <asp:RegularExpressionValidator ID="validador2" Font-Size="Smaller"
                        runat="server" ErrorMessage="o e-mail precisa ser válido" CssClass="RegularExpression"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ValidationGroup="valCadastro"></asp:RegularExpressionValidator>
                    

                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control input-text" placeholder="senha"
                        MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar uma descrição" CssClass="RequiredField" ControlToValidate="txtSenha" ValidationGroup="valCadastro"></asp:RequiredFieldValidator>
            

                <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control input-text" placeholder="cpf"
                        MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar uma descrição" CssClass="RequiredField" ControlToValidate="txtCpf" ValidationGroup="valCadastro"></asp:RequiredFieldValidator>
            

                <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control input-text" placeholder="endereco"
                        MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar um endereço" CssClass="RequiredField" ControlToValidate="txtEndereco" ValidationGroup="valCadastro"></asp:RequiredFieldValidator>
                


                <asp:TextBox ID="txtComplemento" runat="server" CssClass="form-control input-text" placeholder="complemento"
                        MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar um complemento" CssClass="RequiredField" ControlToValidate="txtComplemento" ValidationGroup="valCadastro"></asp:RequiredFieldValidator>
                
                <asp:TextBox ID="txtBairro" runat="server" CssClass="form-control input-text" placeholder="bairro"
                        MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar um bairro" CssClass="RequiredField" ControlToValidate="txtBairro" ValidationGroup="valCadastro"></asp:RequiredFieldValidator>
                

                <asp:TextBox ID="txtCidade" runat="server" CssClass="form-control input-text" placeholder="cidade"
                        MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar uma cidade" CssClass="RequiredField" ControlToValidate="txtCidade" ValidationGroup="valCadastro"></asp:RequiredFieldValidator>
                
                <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control input-text" placeholder="estado"
                        MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar um estado" CssClass="RequiredField" ControlToValidate="txtEstado" ValidationGroup="valCadastro"></asp:RequiredFieldValidator>
                
                <asp:TextBox ID="txtCep" runat="server" CssClass="form-control input-text" placeholder="CEP"
                        MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar uma CEP" CssClass="RequiredField" ControlToValidate="txtCep" ValidationGroup="valCadastro"></asp:RequiredFieldValidator>
                

                
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-info"
                        CausesValidation="true" ValidationGroup="valCadastro" OnClick="btnCadastrar_Click" >Cadastrar</asp:LinkButton>
                </asp:Panel>
       
         
        
	</div>
        </section>




        </form>

    </body>

</html>
