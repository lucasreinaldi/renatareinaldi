<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Noticias.aspx.cs" Inherits="WEB_RENATA.Noticias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">

    <section class="main-section alabaster">

        

        
	<div class="container">
        <asp:Repeater ID="rptNoticias" runat="server">
            <ItemTemplate>
    	<div class="row marginbottom" >
			<figure class="col-lg-3 col-lg-offset-9 col-sm-4 wow fadeInLeft ">
            	
                <img src="<%#Eval("imagem")%>" class="imgMenor"/>
            </figure>
        	<div class="col-sm col-lg-7 col-sm-8 featured-work">
            	<h2><%#Eval("titulo") %></h2>
            	<P class="padding-b"><%#Eval("descricao") %></P>
                <p>Publicado em: <%#Eval("data") %></p>
            	 <br />
                 <p><a class="btn btn-secondary" href="NoticiasArtigo.aspx?id=<%#Eval("id") %>" role="button">Ler mais »</a></p>
                
            </div>
        </div>
            </ItemTemplate>
            </asp:Repeater>
	</div>

         
         


</section> 

</asp:Content>
