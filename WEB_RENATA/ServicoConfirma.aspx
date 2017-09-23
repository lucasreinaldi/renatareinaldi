<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ServicoConfirma.aspx.cs" Inherits="WEB_RENATA.ServicoConfirma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">

    <section class="main-section" id="Portfolio">
	<div class="container gerSquare">
    	<h2>Gerenciador de Notícias</h2>
    	 


        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnAgendar" CssClass="divServicos">

                    <asp:Label ID="lblID" runat="server" Font-Bold="true"></asp:Label>  
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="true"></asp:Label>  
                    <br />
                     
                    <asp:Label ID="lblServico" runat="server" Font-Bold="true"></asp:Label>  
                     

                    <asp:TextBox ID="txtComentario" runat="server" CssClass="form-control input-text" placeholder="comentário (opcional)"
                        MaxLength="1500" TextMode="MultiLine"></asp:TextBox>                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar algo" CssClass="RequiredField" ControlToValidate="txtComentario" ValidationGroup="validation"></asp:RequiredFieldValidator>

                    <asp:TextBox ID="txtData" runat="server" CssClass="form-control input-text" placeholder="comentário (opcional)"
                        MaxLength="1500" TextMode="MultiLine"></asp:TextBox>                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar algo" CssClass="RequiredField" ControlToValidate="txtData" ValidationGroup="validation"></asp:RequiredFieldValidator>

                    <input type="text" style="width: 100px;"  name="Date" id="lol" class="hasDatepicker"/>


                     <br />
            <br />

                    
            
                <asp:LinkButton ID="btnAgendar" runat="server" CssClass="btn btn-info"
                        CausesValidation="true" ValidationGroup="validation" OnClick="btnAgendar_Click" >Agendar</asp:LinkButton>
                </asp:Panel>
       
         
        
	</div>
        
      </section>

</asp:Content>
