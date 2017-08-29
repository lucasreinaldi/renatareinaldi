<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEB_RENATA.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/style-responsive.css">
    <link rel="stylesheet" href="css/animate.min.css">
    <link rel="stylesheet" href="css/vertical-rhythm.min.css">
    <link rel="stylesheet" href="css/owl.carousel.css">
    <link rel="stylesheet" href="css/magnific-popup.css">
    <link href="CSS/Login.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        
        <div id="body">
            <div class="col-md-6 col-md-offset-3">

                <h1 class="hs-line-11 font-alt mb-20 lighter">Login</h1>

                <form class="form contact-form" id="contact_form">
                    <div class="clearfix">

                        <div>

                            <!-- Name -->


                            <!-- Email -->
                            <div class="form-group">
                                <input type="email" name="email" id="email" class="input-md round form-control" placeholder="Email" pattern=".{5,100}" required>
                            </div>
                            <div class="form-group">
                                <input type="password" name="name" id="name" class="input-md round form-control" placeholder="Senha" pattern=".{3,100}" required>
                            </div>

                        </div>


                    </div>

                    <div class="clearfix">

                        <div class="cf-left-col">

                            <!-- Inform Tip -->
                            <div class="form-tip pt-20">
                                 
                            </div>

                        </div>

                        <div class="cf-right-col">

                            <!-- Send Button -->
                            <div class="align-right pt-10">
                                <button class="submit_btn btn btn-mod btn-medium btn-round" id="cadastro_btn">Cadastrar</button>
                                <button class="submit_btn btn btn-mod btn-medium btn-round" id="submit_btn">Logar</button>
                                <div class="hs-line-4 font-alt">
                                    <a>Esqueceu a senha?</a>
                                </div>
                            </div>
                            <div class="align-right pt-10">
                        </div>

                        </div>

                    </div>



                    <div id="result"></div>
                </form>

            </div>
        </div>
    </form>
</body>
</html>
