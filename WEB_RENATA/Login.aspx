<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEB_RENATA.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <link rel="icon" href="favicon.png" type="image/png">
    <link rel="shortcut icon" href="favicon.ico" type="img/x-icon">
    <link href='https://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet'
        type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,800italic,700italic,600italic,400italic,300italic,800,700,600'
        rel='stylesheet' type='text/css'>
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css">
    <link href="css/style.css" rel="stylesheet" type="text/css">
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css">
    <link href="css/responsive.css" rel="stylesheet" type="text/css">
    <link href="css/animate.css" rel="stylesheet" type="text/css">
    <link href="CSS/login.css" rel="stylesheet" />
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
    <div id="divResultado" class="formlinhamsg" runat="server">
        <div id="divLabel" runat="server">
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </div>
    </div>
    <section  > 
	 
        <asp:Label ID="lblID" runat="server" Font-Bold="true"></asp:Label>  
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="true"></asp:Label>  
                    <br />
    	 
    	 


        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnLogar" >
            <div class="loginmodal-container">

                <h1 class="marginbottom">Logue em sua conta</h1>


                    
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control input-text" placeholder="email"
                        MaxLength="80"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validador1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar algo" CssClass="RequiredField" ControlToValidate="txtNome" ValidationGroup="validation"></asp:RequiredFieldValidator>
                    

                   <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control input-text" placeholder="senha"
                        MaxLength="80"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar algo" CssClass="RequiredField" ControlToValidate="txtSenha" ValidationGroup="validation"></asp:RequiredFieldValidator>
                    
            <br />
                     
                <asp:LinkButton ID="btnLogar" runat="server" CssClass="login loginmodal-submit"
                        CausesValidation="true" ValidationGroup="validation" OnClick="btnLogar_Click">Logar</asp:LinkButton>
                <div class="login-help">
					<a href="Signup.aspx">registrar</a> 
				  </div>
                
            </div>
                </asp:Panel>


       
         
        
	 

         
					
				  
				
      </section>


    </form>
</body>
</html>
