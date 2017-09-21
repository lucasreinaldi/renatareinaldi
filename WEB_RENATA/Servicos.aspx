<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="Servicos.aspx.cs" Inherits="WEB_RENATA.Servicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div id="divResultado" runat="server">
        <div id="divLabel" runat="server">
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </div>
    </div>
    <section class="main-section alabaster">

        

        
	<div class="container">
        <asp:Repeater ID="rptServicos" runat="server">
            <ItemTemplate>
    	<div class="row marginbottom" >
			<figure class="col-lg-3 col-lg-offset-2 col-md-4 col-md-offset-1 col-sm-6 col-xs-offset-2 col-xs-8 wow fadeInLeft ">
            	
                <img src="<%#Eval("imagem")%>" class="imgMenor"/>
            </figure>
        	<div class="col-lg-3 col-lg-pull-2 col-md-4 col-md-pull-2 col-sm-3 col-sm-offset-3 col-xs-offset-3 col-xs-8 featured-work">
            	<h2><%#Eval("nome") %></h2>
            	<P class="padding-b"><%#Eval("descricao") %></P>
                <p>Valor: <%#Eval("valor") %> R$</p>
            	 
                 <p><a class="btn btn-secondary" href="ServicoConfirma.aspx?id=0" role="button">Contratar »</a></p>
            </div>
        </div>
            </ItemTemplate>
            </asp:Repeater>
	</div>

         
         


</section>
</asp:Content>
