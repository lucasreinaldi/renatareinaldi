<%@ Page Title="Serviços" Language="C#" MasterPageFile="~/Admin/AdmHome.Master" AutoEventWireup="true" CodeBehind="GERservicos.aspx.cs" Inherits="WEB_RENATA.Admin.GERservicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">

    <section class="main-section paddind" id="Portfolio"><!--main-section-start-->
	<div class="container">
    	<h2>Gerenciador de Serviços</h2>
    	 


        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnAdicionar">
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control input-text" placeholder="nome do serviço"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="validador1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar um email" CssClass="RequiredField" ControlToValidate="txtNome" ValidationGroup="valServicos"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="validador2" Font-Size="Smaller"
                        runat="server" ErrorMessage="o e-mail precisa ser válido" CssClass="RegularExpression"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtNome" ValidationGroup="valServicos"></asp:RegularExpressionValidator>
                    

                    <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control input-text" placeholder="descrição do serviço"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar uma descrição" CssClass="RequiredField" ControlToValidate="txtDescricao" ValidationGroup="valServicos"></asp:RequiredFieldValidator>
            
                    <asp:TextBox ID="txtValor" runat="server" CssClass="form-control input-text" placeholder="valor do serviço"
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Font-Size="Smaller" runat="server"
                        ErrorMessage="você precisa digitar um valor" CssClass="RequiredField" ControlToValidate="txtValor" ValidationGroup="valServicos"></asp:RequiredFieldValidator>

                    <asp:FileUpload ID="exampleInputFile" Width="70%" ToolTip="Selecione a imagem" runat="server" />
            
                <asp:LinkButton ID="btnAdicionar" runat="server" CssClass="btn btn-info"
                        CausesValidation="true" ValidationGroup="valServicos" OnClick="btnAdicionar_Click">Adicionar</asp:LinkButton>
                </asp:Panel>
       
         
        
	</div>
    <div class="portfolioContainer wow fadeInUp delay-04s">
            
        <asp:HiddenField ID="hidID" runat="server" />
       <div id="divServicos">
         
        <table style="font-size: 10px;" cellpadding="3px" cellspacing="0px">
            <asp:Repeater ID="rptServicos" runat="server">
                <HeaderTemplate>
                    <div id="topoLista">
                        <tr>
                            <th style="width: 3%; text-align: center;">ID
                            </th>
                            <th style="width: 7%; text-align: center;">Nome
                            </th>
                            <th style="width: 15%; text-align: center;">Descrição
                            </th>
                            <th style="width: 10%; text-align: center;">Valor
                            </th>
                            <th style="width: 10%; text-align: center;">Caminho
                            </th>
                            <th style="width: 3%; text-align: center;">Alterar
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
                            <%#Eval("nome") %>
                        </td>
                        <td align="center">
                            <%#Eval("descricao") %>
                        </td>
                        <td align="center">
                            <%#Eval("valor")%>
                        </td>
                        <td align="center">
                            <%#Eval("caminho")%>
                        </td>
                        <td align="center" title="X[<%#Eval("id") %>]">
                            <asp:LinkButton ID="lblAlterar" CommandArgument='<%#Eval("ID")%>' runat="server" OnClientClick="return confirm('Tem certeza que deseja excluir?');"><i class="fa fa-trash"></i></asp:LinkButton>
                        </td>
                        <td align="center" title="X[<%#Eval("id") %>]">
                            <asp:LinkButton ID="lbExcluir" OnCommand="imbExcluirEmail_Click" CommandArgument='<%#Eval("ID")%>' runat="server" OnClientClick="return confirm('Tem certeza que deseja excluir?');"><i class="fa fa-trash"></i></asp:LinkButton>
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
