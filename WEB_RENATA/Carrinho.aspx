<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Carrinho.aspx.cs" Inherits="WEB_RENATA.Carrinho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">

    <div id="divResultado" runat="server">
        <div id="divLabel" runat="server">
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </div>
    </div>



    <section class="margin-top">

        

        
	<div class="container">
        <asp:Repeater ID="rptLoja" runat="server">
            <ItemTemplate>
    	<div id="divCarrinho" class="row marginbottom" >
			<figure class="col-lg-2 col-lg-offset-3 col-md-4 col-md-offset-2 col-sm-offset-2 col-sm-8 col-xs-offset-2 col-xs-8 wow fadeInLeft ">
            	
                <img src="<%#Eval("imagem")%>" class="imgMenor"/>
            </figure>
        	<div class="col-lg-5 col-lg-pull-1 col-md-4 col-md-pull-1 col-sm-offset-2 col-sm-8 col-xs-offset-2 col-xs-8 featured-work">
            	<h2><%#Eval("nome") %></h2>
            	<div class="col-lg-6">
                    <P class="padding-b"><%#Eval("quantidade") %> item(s)</P>
            	</div>  
                <h4 class="padding-b sub"> <%#Eval("valor") %> R$</h4>
            	 
                
                
            </div>
        </div>
            </ItemTemplate>
            </asp:Repeater>
        <div class="col-lg-4 col-lg-offset-9 col-md-4 col-md-pull-1 col-sm-offset-2 col-sm-8 col-xs-offset-1 col-xs-10 featured-work">
        <h1 runat="server" id="total" class="padding-b"></h1>
            </div>
       

        <asp:LinkButton ID="btnEsvaziar" runat="server" CssClass="btn btn-danger right marginbottom"
                        CausesValidation="true" ValidationGroup="validation" OnClick="btnEsvaziar_Click" >Esvaziar carrinho</asp:LinkButton>
        <asp:LinkButton ID="btnFinalizar" runat="server" CssClass="btn btn-primary right marginbottom"
                        CausesValidation="true" ValidationGroup="validation" OnClick="btnFinalizar_Click" >Finalizar compra</asp:LinkButton>
	</div>

         
         
             


</section>












</asp:Content>
