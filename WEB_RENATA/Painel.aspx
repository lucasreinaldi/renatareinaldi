<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Painel.aspx.cs" Inherits="WEB_RENATA.Painel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">

    <div id="divResultado" runat="server">
        <div id="divLabel" runat="server">
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </div>
    </div>
    <section > 
	<div class="container gerSquare">
    	<h2>Atendimentos</h2>
    	 
         <div id="divCentral">
         
        <table id="divTabela">
            <asp:Repeater ID="rptAtendimento" runat="server">
                <HeaderTemplate>
                    <div id="topoLista">
                        <tr runat="server">
                            <th style="width: 3%; text-align: center;">Serviço
                            </th>
                            <th style="width: 5%; text-align: center;">Data
                            </th>                           
                            <th style="width: 15%; text-align: center;">Comentário
                            </th>
                            <th style="width: 15%; text-align: center;">Resposta
                            </th>
                            <th style="width: 7%; text-align: center;">Estado
                            </th> 
                            <th runat="server" style="width: 3%; text-align: center;">Pagar
                            </th>                             
                             
                        </tr>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="linhaA" runat="server">
                        <td align="center">
                            <%#Eval("servico") %>
                        </td>
                        <td align="center">
                            <%#Eval("dataAtend") %>
                        </td>
                        
                        <td align="center">
                            <%#Eval("comentario") %>
                        </td>
                        <td align="center">
                            <%#Eval("resposta") %>
                        </td>
                        <td align="center">
                            <%#Eval("estado")%>
                        </td>
                         <td runat="server" align="center">
                           <a id="lols" runat="server" href="Admin/GERhome.aspx">ADM</a>
                        </td>

                        
                         
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
        
	</div>
    <div class="container fadeInUp delay-04s tabelaServicos">
            
        <asp:HiddenField ID="hidID" runat="server" />
      
         
    </div>

        <div class="container gerSquare">
    	<h2>Compras</h2>
    	 
         <div id="divCentral">
         
        <table id="divTabela">
            <asp:Repeater ID="rptVenda" runat="server">
                <HeaderTemplate>
                    <div id="topoLista">
                        <tr runat="server">
                            <th style="width: 3%; text-align: center;">Data
                            </th>
                            <th style="width: 5%; text-align: center;">Valor Total
                            </th>                              
                        </tr>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="linhaA" runat="server">
                        <td align="center">
                            <%#Eval("data") %>
                        </td>
                        <td align="center">
                            <%#Eval("total") %>
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
               








</section>



</asp:Content>
