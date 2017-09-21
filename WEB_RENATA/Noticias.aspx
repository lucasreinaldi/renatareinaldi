<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="Noticias.aspx.cs" Inherits="WEB_RENATA.Noticias" %>

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
        <asp:Repeater ID="rptNoticias" runat="server">
            <ItemTemplate>
    	<div class="row marginbottom" >
			<figure class="col-lg-3 col-lg-offset-2 col-md-4 col-md-offset-1 col-sm-6 col-xs-offset-2 col-xs-8 wow fadeInLeft ">
            	
                <img src="<%#Eval("imagem")%>" class="imgMenor"/>
            </figure>
        	<div class="col-lg-3 col-lg-pull-2 col-md-4 col-md-pull-2 col-sm-3 col-sm-offset-3 col-xs-offset-3 col-xs-8 featured-work">
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

         
         <div id="divPaginacao" class="divPaginacao" runat="server" style="text-align: center;">
        <div style="padding: 5px 0 0 0;">
            <asp:LinkButton runat="server" ID="lbtAnterior" Text="Anterior" ToolTip="Ir para a página anteiror"
                CausesValidation="false" AccessKey="A" ForeColor="#000000" OnClick="lbtAnterior_Click"></asp:LinkButton>
            <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
            <asp:LinkButton runat="server" ID="lbtProximo" Text="Próximo" ToolTip="Ir para a próxima página"
                CausesValidation="false" AccessKey="P" ForeColor="#000000" OnClick="lbtProximo_Click"></asp:LinkButton>
        </div>
    </div> 	


</section>
</asp:Content>
