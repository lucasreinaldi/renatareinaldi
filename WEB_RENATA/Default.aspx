<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WEB_RENATA.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div class="container-fluid carrosel">
        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                <br />
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                    </ol>
                    <!-- Wrapper for slides -->
                    <div class="carousel-inner">
                        <div class="item active">
                            <img src="img/home/Car1.jpg" alt=" ">
                        </div>
                        <div class="item">
                            <img src="img/home/Car2.jpg" alt=" ">
                        </div>
                        <div class="item">
                            <img src="img/home/Car3.jpg" alt=" ">
                        </div>
                    </div>
                    <!-- Left and right controls -->
                    <a class="left carousel-control" href="#myCarousel" data-slide="prev"><span class="glyphicon glyphicon-chevron-left">
                    </span><span class="sr-only">Previous</span> </a><a class="right carousel-control"
                        href="#myCarousel" data-slide="next"><span class="glyphicon glyphicon-chevron-right">
                        </span><span class="sr-only">Next</span> </a>
                </div>
            </div>
        </div>
    </div>
    <section class="main-section floral"  > 
	<div class="container">
<div class="row">
    	<h2>Clientes satisfeitos</h2>
    	<h6>Animais também sorriem!</h6>
       
        
	
    <div class="portfolioContainer wow fadeInUp delay-04s">
            	<div class="padding-a col-lg-4 col-lg-offset-0 col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2 col-xs-10 col-xs-offset-1" >
                	<img src="img/home/Cliente1.jpg" />
                 
                </div>
              <div class="padding-a col-lg-4 col-lg-offset-0 col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2 col-xs-10 col-xs-offset-1" >
                	<img src="img/home/Cliente2.jpg" />
                	  
                </div>
                <div class="padding-a col-lg-4 col-lg-offset-0 col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2 col-xs-10 col-xs-offset-1" >
                	<img src="img/home/Cliente3.jpg" />
                </div>
                
    </div>
    </div>
        </div>
</section>
    <section class="main-section" id="novidades">
	<div class="container">
         
    	<h2>Novidades</h2>
    	        
        <div id="noticias" >
            <asp:Repeater ID="rptNoticias" runat="server"> 
                <ItemTemplate>
                    
            <div class="col-lg-4 col-lg-offset-0 col-md-10 col-md-offset-1 col-sm-10 col-sm-offset-1 col-xs-10 col-xs-offset-1 marginbottom">
                <div class="divNoticiasHome">
              <h3><%#Eval("titulo") %></h3>
              <p><%#Eval("descricao") %> </p>
              <p><a class="btn btn-primary" href="NoticiasArtigo.aspx?id=<%#Eval("id") %>" role="button">Ler tudo »</a></p>
            </div>
                        </div>
                     </ItemTemplate>
           </asp:Repeater>
            
         
    </div>
	</div>
    
         

</section>
    <section class="main-section floral" id="emails" style="padding-top: 10px; padding-bottom: 10px; "> 
	<div class="container gerNewsletter">
    	<h2>Newsletter</h2>
    	 


        <asp:Panel ID="panelNewsletter" runat="server" DefaultButton="btnNewsletter" CssClass="divNewsletter">
                    <asp:TextBox ID="txtNewsletter" runat="server" CssClass="form-control input-text" placeholder="newsletter"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validador1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar um email" CssClass="RequiredField" ControlToValidate="txtNewsletter" ValidationGroup="valNewsletter"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="validador2" Font-Size="Smaller"
                        runat="server" ErrorMessage="o e-mail precisa ser válido" CssClass="RegularExpression"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtNewsletter" ValidationGroup="valNewsletter"></asp:RegularExpressionValidator>
                  
                        <asp:LinkButton ID="btnNewsletter" runat="server" CssClass="btn btn-primary"
                        CausesValidation="true" ValidationGroup="valNewsletter" OnClick="btnNewsletter_Click"  
                         >Assinar</asp:LinkButton>
                </asp:Panel>
       
         
        
	</div>
        </section>
</asp:Content>
