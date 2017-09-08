<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdmHome.Master" AutoEventWireup="true" CodeBehind="GERnewsletter.aspx.cs" Inherits="WEB_RENATA.Admin.GERnewsletter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
  
    
    
    <section class="main-section" id="Portfolio"> 
	<div class="container gerNewsletter">
    	<h2>Base de dados de e-mails</h2>
    	 


        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnNewsletter" CssClass="divNewsletter">
                    <asp:TextBox ID="txtNewsletter" runat="server" CssClass="form-control input-text" placeholder="newsletter"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validador1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar um email" CssClass="RequiredField" ControlToValidate="txtNewsletter" ValidationGroup="valNewsletter"></asp:RequiredFieldValidator>
            <br />
                    <asp:RegularExpressionValidator ID="validador2" Font-Size="Smaller"
                        runat="server" ErrorMessage="o e-mail precisa ser válido" CssClass="RegularExpression"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtNewsletter" ValidationGroup="valNewsletter"></asp:RegularExpressionValidator>
                  
                        <asp:LinkButton ID="btnNewsletter" runat="server" CssClass="btn btn-info"
                        CausesValidation="true" ValidationGroup="valNewsletter" OnClick="btnNewsletter_Click"
                         >Adicionar</asp:LinkButton>
                </asp:Panel>
       
         
        
	</div>
    <div class="container wow fadeInUp delay-04s tabela">
            
        <asp:HiddenField ID="hidID" runat="server" />
       <div >
         
        <table id="divTabela">
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
</section>
    

</asp:Content>

