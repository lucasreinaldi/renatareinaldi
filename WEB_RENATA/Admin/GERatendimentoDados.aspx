<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdmHome.Master" AutoEventWireup="true" CodeBehind="GERatendimentoDados.aspx.cs" Inherits="WEB_RENATA.Admin.GERatendimentoDados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">

     <section class="main-section" id="Portfolio">
	<div class="container gerSquare">
    	<h2>Gerenciador de Atendimentos</h2>
    	 

        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnAprovar" CssClass="divServicos">

                      
                    

                    
                    <asp:TextBox ID="txtDescricao" TextMode="MultiLine" runat="server" CssClass="form-control input-text" placeholder="comentário adicional"
                        MaxLength="200"></asp:TextBox>
                     
            
            <br />
                <asp:LinkButton ID="btnAprovar" runat="server" CssClass="btn btn-info btn-block"
                        CausesValidation="true" ValidationGroup="validation" OnClick="btnAprovar_Click">Aprovar</asp:LinkButton>
            <br />
                <asp:LinkButton ID="btnDesaprovar" runat="server" CssClass="btn btn-info btn-block"
                        CausesValidation="true" ValidationGroup="validation" OnClick="btnDesaprovar_Click">Desaprovar</asp:LinkButton>

                </asp:Panel>
       <br />
         
        
	</div>
      </section>


</asp:Content>
