<%@ Page Title="" Language="C#" MasterPageFile="~/ADM/ADM.Master" AutoEventWireup="true" CodeBehind="ADMnewsletter.aspx.cs" Inherits="WEB_RENATA.ADM.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">

    
    <section class="main-section paddind" id="Portfolio"><!--main-section-start-->
	<div class="container">
    	<h2>Base de dados de e-mails</h2>
    	 
       
        
	</div>
    <div class="portfolioContainer wow fadeInUp delay-04s">
            
        <asp:HiddenField ID="hidID" runat="server" />
       <div id="divEmail">
        <h2 class="section-title font-alt mb-70 mb-sm-40">
            <br />
            Lista e-mails
        </h2>
        <table style="font-size: 10px;" cellpadding="3px" cellspacing="0px">
            <asp:Repeater ID="rptNewsletter" runat="server">
                <HeaderTemplate>
                    <div id="topoLista">
                        <tr>
                            <th style="width: 3%; text-align: center;">ID
                            </th>
                            <th style="width: 7%; text-align: center;">IP
                            </th>
                            <th style="width: 15%; text-align: center;">Data
                            </th>
                            <th style="width: 15%; text-align: center;">Email
                            </th>
                            <th style="width: 3%; text-align: center;">Deletar
                            </th>
                        </tr>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="linhaA">
                        <td align="center">
                            <%#Eval("id") %>
                        </td>
                        <td align="center">
                            <%#Eval("ip") %>
                        </td>
                        <td align="center">
                            <%#Eval("data") %>
                        </td>
                        <td align="center">
                            <%#Eval("email")%>
                        </td>
                        <td align="center" title="X[<%#Eval("id") %>]">
                            <asp:LinkButton ID="lbExcluirEmail" OnCommand="imbExcluirEmail_Click" CommandArgument='<%#Eval("ID")%>' runat="server" OnClientClick="return confirm('Tem certeza que deseja excluir?');"><i class="fa fa-trash"></i></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
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
               
        
        
        
         
    </div>
</section><!--main-section-end-->
    

</asp:Content>
