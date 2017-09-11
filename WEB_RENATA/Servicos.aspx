<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Servicos.aspx.cs" Inherits="WEB_RENATA.Servicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">


    <section class="main-section alabaster">

        

        
	<div class="container">
        <asp:Repeater ID="rptServicos" runat="server">
            <ItemTemplate>
    	<div class="row marginbottom" >
			<figure class="col-lg-3 col-lg-offset-8  col-sm-4 wow fadeInLeft ">
            	
                <img src="<%#Eval("imagem")%>" class="imgMenor"/>
            </figure>
        	<div class="col-sm col-lg-7 col-sm-8 featured-work">
            	<h2><%#Eval("nome") %></h2>
            	<P class="padding-b"><%#Eval("descricao") %></P>
                <p>Valor: <%#Eval("valor") %> R$</p>
            	 
                 <p><a class="btn btn-secondary" href="#" role="button">Contratar »</a></p>
            </div>
        </div>
            </ItemTemplate>
            </asp:Repeater>
	</div>

         
         


</section> 



</asp:Content>
