<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdmHome.Master" AutoEventWireup="true"
    CodeBehind="GERusuarios.aspx.cs" Inherits="WEB_RENATA.Admin.GERusuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <div id="divResultado" runat="server">
        <div id="divLabel" runat="server">
            <asp:Label ID="lblResultado" runat="server"></asp:Label>
        </div>
    </div>
    <section class="main-section" id="Portfolio"> 
	<div class="container gerServicos">
    	<h2>Usuários cadastrados</h2>
    	 

         
        
	</div>
    <div class="container fadeInUp delay-04s tabelaServicos">
            
        <asp:HiddenField ID="hidID" runat="server" />
       <div id="divCentral">
         
        <table id="divTabela">
            <asp:Repeater ID="rptLogs" runat="server">
                <HeaderTemplate>
                    <div id="topoLista">
                        <tr>
                            <th style="width: 3%; text-align: center;">ID
                            </th>
                            <th style="width: 4%; text-align: center;">Nome
                            </th>
                            <th style="width: 5%; text-align: center;">E-mail
                            </th>                            
                            
                            <th style="width: 5%; text-align: center;">Cidade
                            </th>
                            <th style="width: 5%; text-align: center;">Estado
                            </th>
                            <th style="width: 6%; text-align: center;">Rua
                            </th>                            
                            <th style="width: 3%; text-align: center;">CEP
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
                            <%#Eval("nome") %>
                        </td>
                        <td align="center">
                            <%#Eval("email") %>
                        </td>
                        
                        <td align="center">
                            <%#Eval("cidade")%>
                        </td>
                        <td align="center">
                            <%#Eval("estado")%>
                        </td> 
                        <td align="center">
                            <%#Eval("rua")%>
                        </td>
                        <td align="center">
                            <%#Eval("cep")%>
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
</asp:Content>
