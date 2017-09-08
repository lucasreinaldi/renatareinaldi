<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdmHome.Master" AutoEventWireup="true" CodeBehind="GERhome.aspx.cs" Inherits="WEB_RENATA.Admin.GERhome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">

    <div class="container">
    	<h2>Alterar banner</h2>
    	 
	</div>

     <div class="container">
      <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
        	<br />
        		<div class="carousel-inner" role="listbox">
        			<div class="carousel-item active">
        				<img id="carUm" runat="server" src="../img/home/Car1.jpg"/>
                                               
                            <asp:FileUpload ID="fupCarUm" Width="70%" ToolTip="Selecione a imagem" runat="server" />
                            <asp:LinkButton ID="btnAlterarCarUm" runat="server" CssClass="btn btn-info"
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
                                               
                            <asp:FileUpload ID="fupCarDois" Width="70%" ToolTip="Selecione a imagem" runat="server" />
                            <asp:LinkButton ID="btnAlterarCarDois" runat="server" CssClass="btn btn-info"
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
                                               
                            <asp:FileUpload ID="fupCarTres" Width="70%" ToolTip="Selecione a imagem" runat="server" />
                            <asp:LinkButton ID="btnAlterarCarTres" runat="server" CssClass="btn btn-info"
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
            	<div class="Portfolio-box">
                	 <img src="../img/home/Cliente1.jpg" alt=""> 
                    
                	 
                     
                </div>
        <asp:FileUpload ID="fupCliUm" Width="70%" ToolTip="Selecione a imagem" runat="server" />
                            <asp:LinkButton ID="btnCliUm" runat="server" CssClass="btn btn-info"
                                 OnClick="btnCliUm_Click"                         
                         >Alterar</asp:LinkButton>

               <div class="Portfolio-box printdesign">
                	 <img src="../img/home/Cliente2.jpg" alt=""> 
                   
                	 
                     
                </div>
        <asp:FileUpload ID="fupCliDois" Width="70%" ToolTip="Selecione a imagem" runat="server" />
                            <asp:LinkButton ID="btnCliDois" runat="server" CssClass="btn btn-info"
                                 OnClick="btnCliDois_Click"                         
                         >Alterar</asp:LinkButton>
        <div class="Portfolio-box printdesign">
                	 <img src="../img/home/Cliente3.jpg" alt=""> 
            
                	 
                     
                </div>
        <asp:FileUpload ID="fupCliTres" Width="70%" ToolTip="Selecione a imagem" runat="server" />
                            <asp:LinkButton ID="btnCliTres" runat="server" CssClass="btn btn-info"
                                 OnClick="btnCliTres_Click"                         
                         >Alterar</asp:LinkButton>
                
    </div>
</section>




</asp:Content>
