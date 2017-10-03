<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdmHome.Master" AutoEventWireup="true"
    CodeBehind="GERhome.aspx.cs" Inherits="WEB_RENATA.Admin.GERhome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <section  > 
	<div class="container gerServicos">
    	<h2 style="margin-top: 40px;" class="margin-top">Gerenciador da Home</h2>
        </div>

     <div class="container">
      <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
        	<br />
        		<div class="carousel-inner" role="listbox">
        			<div class="carousel-item active">
        				<img id="carUm" runat="server" src="../img/home/Car1.jpg"/>
                                               
                            <asp:FileUpload class="margintop marginbottom" ID="fupCarUm" Width="70%" ToolTip="Selecione a imagem" runat="server" />
                            <asp:LinkButton class="margintop" ID="btnAlterarCarUm" runat="server" CssClass="btn btn-primary"
                                  OnClick="btnCarUm_Click"                         
                         >Alterar</asp:LinkButton>
        			</div>
        	</div>
        </div>
      </div>
         <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
        	<br />
        		<div class="carousel-inner" role="listbox">
        			<div class="carousel-item active">
        				<img id="Img1" runat="server" src="../img/home/Car2.jpg"/>
                                               
                            <asp:FileUpload class="margintop marginbottom" ID="fupCarDois" Width="70%" ToolTip="Selecione a imagem" runat="server" />
                            <asp:LinkButton class="margintop" ID="btnAlterarCarDois" runat="server" CssClass="btn btn-primary"
                               OnClick="btnCarDois_Click"                         
                         >Alterar</asp:LinkButton>
        			</div>
        	</div>
        </div>
      </div>
         <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
        	<br />
        		<div class="carousel-inner" role="listbox">
        			<div class="carousel-item active">
        				<img id="Img2" runat="server" src="../img/home/Car3.jpg"/>
                                               
                            <asp:FileUpload class="margintop marginbottom" ID="fupCarTres" Width="70%" ToolTip="Selecione a imagem" runat="server" />
                            <asp:LinkButton class="margintop" ID="btnAlterarCarTres" runat="server" CssClass="btn btn-primary"
                                 OnClick="btnCarTres_Click"                         
                         >Alterar</asp:LinkButton>
        			</div>
        	</div>
        </div>
      </div>
       </div>

        <section class="main-section"> 
	<div class="container">
    	<h2>Clientes destaques</h2>
    	 
	</div>
    <div class="portfolioContainer wow fadeInUp delay-04s">
            	<div class="padding-a col-lg-6 col-lg-offset-3 col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2 col-xs-10 col-xs-offset-1" >
                	 <img runat="server" id="carrousel1"  > 
                    
                	 
                     
                </div>
        <div class="col-lg-6 col-lg-pull-2 col-md-6 col-md-pull-2 col-sm-6 col-sm-offset-3 col-xs-offset-3 col-xs-8 featured-work">
        <asp:FileUpload class="marginbottom" ID="fupCliUm" Width="70%" ToolTip="Selecione a imagem" runat="server" />
                            <asp:LinkButton ID="btnCliUm" runat="server" CssClass="btn btn-primary marginbottom"
                                 OnClick="btnCliUm_Click"                         
                         >Alterar</asp:LinkButton>

            </div>
         

          
               <div class="padding-a col-lg-6 col-lg-offset-3 col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2 col-xs-10 col-xs-offset-1" >
                	 <img src="../img/home/Cliente2.jpg" alt=""> 
                   
                	 
                     
                </div>
               <div class="col-lg-6 col-lg-pull-2 col-md-6 col-md-pull-2 col-sm-6 col-sm-offset-3 col-xs-offset-3 col-xs-8 featured-work">
        <asp:FileUpload class="marginbottom" ID="fupCliDois" Width="70%" ToolTip="Selecione a imagem" runat="server" />
                            <asp:LinkButton ID="btnCliDois" runat="server" CssClass="btn btn-primary marginbottom"
                                 OnClick="btnCliDois_Click"                         
                         >Alterar</asp:LinkButton>
                </div>
               

             
        <div class="padding-a col-lg-6 col-lg-offset-3 col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2 col-xs-10 col-xs-offset-1" >
                	 <img src="../img/home/Cliente3.jpg" alt=""> 
            
                	 
                     
                </div>
                 <div class="col-lg-6 col-lg-pull-2 col-md-6 col-md-pull-2 col-sm-6 col-sm-offset-3 col-xs-offset-3 col-xs-8 featured-work">
        <asp:FileUpload class="marginbottom" ID="fupCliTres" Width="70%" ToolTip="Selecione a imagem" runat="server" />
                            <asp:LinkButton ID="btnCliTres" runat="server" CssClass="btn btn-primary marginbottom"
                                 OnClick="btnCliTres_Click"                         
                         >Alterar</asp:LinkButton>

                </div>
    </div>
</section>

       </section>
</asp:Content>
