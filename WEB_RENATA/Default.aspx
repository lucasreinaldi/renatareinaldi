<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WEB_RENATA.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div class="container">
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
                            <img src="img/home/Car1.jpg" alt="Los Angeles">
                        </div>
                        <div class="item">
                            <img src="img/home/Car1.jpg" alt="sos Angeles">
                        </div>
                        <div class="item">
                            <img src="img/home/Car1.jpg" alt="Los Angeles">
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
    <section class="main-section paddind" id="Portfolio"> 
	<div class="container">
    	<h2>Clientes satisfeitos</h2>
    	<h6>Animais também sorriem!</h6>
       
        
	</div>
    <div class="portfolioContainer wow fadeInUp delay-04s">
            	<div class=" Portfolio-box printdesign">
                	<img src="img/home/Cliente1.jpg" />
                 
                </div>
                <div class="Portfolio-box webdesign">
                	<img src="img/home/Cliente2.jpg" />
                	  
                </div>
                <div class=" Portfolio-box branding">
                	<img src="img/home/Cliente3.jpg" />
                </div>
                
    </div>
</section>
    <section class="main-section" id="">
	<div class="container">
    	<h2>Novidades</h2>
    	        
        <div id="noticias" class="row">
            <asp:Repeater ID="rptNoticias" runat="server"> 
                <ItemTemplate>
            <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12 marginbottom">
              <h3><%#Eval("titulo") %></h3>
              <p><%#Eval("descricao") %> </p>
              <p><a class="btn btn-secondary" href="#" role="button">ler tudo »</a></p>
            </div>
                     </ItemTemplate>
           </asp:Repeater>
            
          </div>

	</div>
    
         

</section>
    <section class="main-section" style="padding-top: 10px;"> 
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
                  
                        <asp:LinkButton ID="btnNewsletter" runat="server" CssClass="btn btn-info"
                        CausesValidation="true" ValidationGroup="valNewsletter" OnClick="btnNewsletter_Click"  
                         >Adicionar</asp:LinkButton>
                </asp:Panel>
       
         
        
	</div>
        </section>
</asp:Content>
