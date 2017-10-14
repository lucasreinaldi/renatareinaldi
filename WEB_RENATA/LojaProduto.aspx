<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="LojaProduto.aspx.cs" Inherits="WEB_RENATA.LojaProduto" %>
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
        
    	<div class="row">
			<figure class="col-lg-offset-1 col-lg-3 col-sm-4 wow fadeInLeft">
            	<img runat="server" id="imagem" src="#" alt="">
            </figure>
        	<div class="col-lg-6 col-sm-8 featured-work">
            	<h2 id="nome" runat="server"></h2>
            	<p id="descricao" runat="server" class="padding-b">  </p>
            	<p id="preco" runat="server" class="padding-b">  </p> 
                <p id="estoque" runat="server" class="padding-b">  </p>
                 
                 <asp:Panel ID="Panel1" runat="server" DefaultButton="btnAdicionar" CssClass="divServicos">

                     
                     
                     
                     <asp:TextBox ID="txtEstoque" runat="server" CssClass="form-control input-text" placeholder="estoque"
                        MaxLength="10"></asp:TextBox>                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar algo" CssClass="RequiredField" ControlToValidate="txtEstoque" ValidationGroup="validation"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ValidationExpression="^\d+$" ID="RegularExpressionValidator1" Font-Size="Smaller" 
                        ErrorMessage="você precisa digitar um número" CssClass="RequiredField" ControlToValidate="txtEstoque" ValidationGroup="validation"></asp:RegularExpressionValidator>

                     
                   


                     <br />
            <br />

                    
            
                <asp:LinkButton ID="btnAdicionar" runat="server" CssClass="btn btn-info"
                        CausesValidation="true" ValidationGroup="validation" OnClick="btnAdicionar_Click" >Adicionar ao carrinho</asp:LinkButton>
                </asp:Panel>
                
            </div>
        </div>
                    
	</div>
</section>


</asp:Content>
