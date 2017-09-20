<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdmHome.Master" AutoEventWireup="true" CodeBehind="GERnoticiasDados.aspx.cs" Inherits="WEB_RENATA.Admin.GERnoticiasDados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">

     <section class="main-section" id="Portfolio">
	<div class="container gerSquare">
    	<h2>Gerenciador de Notícias</h2>
    	 


        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSalvar" CssClass="divServicos">

                    <asp:Label ID="lblID" runat="server" Font-Bold="true"></asp:Label>  
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="true"></asp:Label>  
                    <br />
                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control input-text" placeholder="título"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validador1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar algo" CssClass="RequiredField" ControlToValidate="txtTitulo" ValidationGroup="validation"></asp:RequiredFieldValidator>
                    

                    <asp:TextBox ID="txtDescricaoBreve" runat="server" CssClass="form-control input-text" placeholder="descrição breve"
                        MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar uma descrição" CssClass="RequiredField" ControlToValidate="txtDescricaoBreve" ValidationGroup="validation"></asp:RequiredFieldValidator>
            
                    <asp:TextBox ID="txtConteudo" runat="server" CssClass="form-control input-text" placeholder="corpo da notícia"
                        MaxLength="1500" TextMode="MultiLine"></asp:TextBox>                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar algo" CssClass="RequiredField" ControlToValidate="txtConteudo" ValidationGroup="validation"></asp:RequiredFieldValidator>

                     
                    <asp:FileUpload class="margintop marginbottom" ID="fup" Width="70%" ToolTip="Selecione a imagem" runat="server" />
            
                <asp:LinkButton ID="btnSalvar" runat="server" CssClass="btn btn-info"
                        CausesValidation="true" ValidationGroup="validation" OnClick="btnSalvar_Click">Salvar</asp:LinkButton>
                </asp:Panel>
       
         
        
	</div>
      </section>

</asp:Content>
