<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdmHome.Master" AutoEventWireup="true" CodeBehind="GERservicosDados.aspx.cs" Inherits="WEB_RENATA.Admin.GERservicosDados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
  <section class="main-section" id="Portfolio">
	<div class="container gerSquare">
    	<h2>Gerenciador de Serviços</h2>
    	 


        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSalvar" CssClass="divServicos">

                    <asp:Label ID="lblID" runat="server" Font-Bold="true"></asp:Label>  
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="true"></asp:Label>  
                    <br />
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control input-text" placeholder="nome do serviço"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validador1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar algo" CssClass="RequiredField" ControlToValidate="txtNome" ValidationGroup="valServicos"></asp:RequiredFieldValidator>
                    

                    <asp:TextBox TextMode="MultiLine" ID="txtDescricao" runat="server" CssClass="form-control input-text" placeholder="descrição do serviço"
                        MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar uma descrição" CssClass="RequiredField" ControlToValidate="txtDescricao" ValidationGroup="valServicos"></asp:RequiredFieldValidator>
            
                    <asp:TextBox ID="txtValor" runat="server" CssClass="form-control input-text" placeholder="valor do serviço"
                        MaxLength="5"></asp:TextBox>
                    <asp:RegularExpressionValidator runat="server" ValidationExpression="^\d+$" ID="RequiredNumeric" Font-Size="Smaller" 
                        ErrorMessage="você precisa digitar um número" CssClass="RequiredField" ControlToValidate="txtValor" ValidationGroup="valServicos"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar algo" CssClass="RequiredField" ControlToValidate="txtValor" ValidationGroup="valServicos"></asp:RequiredFieldValidator>

                    <asp:FileUpload class="margintop marginbottom" ID="fup" Width="70%" ToolTip="Selecione a imagem" runat="server" />
            
                <asp:LinkButton ID="btnSalvar" runat="server" CssClass="btn btn-info"
                        CausesValidation="true" ValidationGroup="valServicos" OnClick="btnSalvar_Click">Adicionar</asp:LinkButton>
                </asp:Panel>
       
         
        
	</div>
      </section>

</asp:Content>
