<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="NoticiasArtigo.aspx.cs" Inherits="WEB_RENATA.NoticiasArtigo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <section class="main-section alabaster">
	<div class="container">
        
    	<div class="row">
			<figure class="col-lg-offset-1 col-lg-3 col-sm-4 wow fadeInLeft">
            	<img runat="server" id="imagem" src="#" alt="">
            </figure>
        	<div class="col-lg-6 col-sm-8 featured-work">
            	<h2 id="titulo" runat="server"></h2>
            	<p id="corpo" runat="server" class="padding-b">  </p>
            	 
                 
                <div class="featured-box">
                	<div class="featured-box-col wow fadeInRight delay-06s">
                    	<i class="fa fa-dashboard"></i>
                    </div>	
                	<div class="featured-box-col2 wow fadeInRight delay-06s">
                        <h3>Publicado em: <p id="data" runat="server"></p> </h3>                        
                    </div>    
                </div>
                
            </div>
        </div>
                    
	</div>
</section>
</asp:Content>
