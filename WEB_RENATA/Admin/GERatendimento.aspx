﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdmHome.Master" AutoEventWireup="true" CodeBehind="GERatendimento.aspx.cs" Inherits="WEB_RENATA.Admin.GERatendimento" %>
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
    	<h2>Atendimentos Pendentes</h2>
    	 
        <a class="btn btn-primary marginbottom" href="GERatendimentoAprovado.aspx" >
                               Ver aprovados
                            </a>
        <br />
        <a class="btn btn-primary" href="GERatendimentoDesaprovado.aspx" >
                               Ver não aprovados
                            </a>
        
	</div>
    <div class="container fadeInUp delay-04s tabelaServicos">
            
        <asp:HiddenField ID="hidID" runat="server" />
       <div id="divCentral">
         
        <table id="divTabela">
            <asp:Repeater ID="rptAtendimento" runat="server">
                <HeaderTemplate>
                    <div id="topoLista">
                        <tr>
                            <th style="width: 5%; text-align: center;">Serviço
                            </th>
                            <th style="width: 4%; text-align: center;">Data
                            </th>
                            <th style="width: 4%; text-align: center;">Data Atend.
                            </th>
                            <th style="width: 3%; text-align: center;">Usuário
                            </th>
                            <th style="width: 10%; text-align: center;">Comentário
                            </th>
                            <th style="width: 10%; text-align: center;">Resposta
                            </th>
                            <th style="width: 5%; text-align: center;">Estado
                            </th>                            
                            <th style="width: 2%; text-align: center;">Aprovar/Desaprovar
                            </th>                             
                        </tr>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="linhaA">
                        <td align="center">
                            <%#Eval("servico") %>
                        </td>
                        <td align="center">
                            <%#Eval("data") %>
                        </td>
                        <td align="center">
                            <%#Eval("dataAtend") %>
                        </td>
                        <td align="center">
                            <%#Eval("usuario") %>
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
                         <td align="center" title="X[<%#Eval("id") %>]">                             
                            <a href="GERatendimentoDados.aspx?id=<%# Eval("id") %>" >
                                 <i class="fa fa-wrench"></i>
                            </a>
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
