<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdmHome.Master" AutoEventWireup="true"
    CodeBehind="GERprodutosDados.aspx.cs" Inherits="WEB_RENATA.Admin.GERprodutosDados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <section class="main-section" id="Portfolio">
	<div class="container gerSquare">
    	<h2>Gerenciador de Produtos</h2>
    	 

        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSalvar" CssClass="divServicos">

                    <asp:Label ID="lblID" runat="server" Font-Bold="true"></asp:Label>  
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="true"></asp:Label>  
                    <br />

                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control input-text" placeholder="nome"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validador1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar algo" CssClass="RequiredField" ControlToValidate="txtNome" ValidationGroup="validation"></asp:RequiredFieldValidator>
                    

                    <asp:TextBox ID="txtDescricao" TextMode="MultiLine" runat="server" CssClass="form-control input-text" placeholder="descrição"
                        MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar uma descrição" CssClass="RequiredField" ControlToValidate="txtDescricao" ValidationGroup="validation"></asp:RequiredFieldValidator>
            
                    <asp:TextBox ID="txtValor" runat="server" CssClass="form-control input-text" placeholder="valor"
                        MaxLength="1500"></asp:TextBox>                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar algo" CssClass="RequiredField" ControlToValidate="txtValor" ValidationGroup="validation"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ID="RequiredNumeric" Font-Size="Smaller" 
                        ErrorMessage="você precisa digitar um número" CssClass="RequiredField" ControlToValidate="txtValor" ValidationGroup="validation"></asp:RegularExpressionValidator>

                    <asp:TextBox ID="txtEstoque" runat="server" CssClass="form-control input-text" placeholder="estoque"
                        MaxLength="1500"></asp:TextBox>                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar algo" CssClass="RequiredField" ControlToValidate="txtEstoque" ValidationGroup="validation"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ValidationExpression="^\d+$" ID="RegularExpressionValidator1" Font-Size="Smaller" 
                        ErrorMessage="você precisa digitar um número" CssClass="RequiredField" ControlToValidate="txtEstoque" ValidationGroup="validation"></asp:RegularExpressionValidator>

                     
                    <asp:FileUpload class="margintop marginbottom" ID="fup" Width="70%" ToolTip="Selecione a imagem" runat="server" />
            
                <asp:LinkButton ID="btnSalvar" runat="server" CssClass="btn btn-info"
                        CausesValidation="true" ValidationGroup="validation" OnClick="btnSalvar_Click">Salvar</asp:LinkButton>
                </asp:Panel>
       
         
        
	</div>
      </section>
</asp:Content>
