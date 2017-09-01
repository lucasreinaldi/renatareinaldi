<%@ Page Title="" Language="C#" MasterPageFile="~/ADM/ADM.Master" AutoEventWireup="true" CodeBehind="ADMservicos.aspx.cs" Inherits="WEB_RENATA.ADM.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">


    <div class="container">
        <section class="main-section contact" id="contact">
	
        <div class="row">
        	 
        	<div class="col-lg-6 col-sm-5 wow fadeInUp delay-05s">
            	<div class="form">
                	
                    <div id="sendmessage">Your message has been sent. Thank you!</div>
                    <div id="errormessage"></div>
                    <form action="" method="post" role="form" class="contactForm">
                        <div class="form-group">
                            <input type="text" name="name" class="form-control input-text" id="nome" placeholder="Serviço" data-rule="minlen:4" data-msg="Please enter at least 4 chars" />
                            <div class="validation"></div>
                        </div>
                        <div class="form-group">
                            <input type="email" class="form-control input-text" name="valor" id="email" placeholder="Valor" data-rule="email" data-msg="Please enter a valid email" />
                            <div class="validation"></div>
                        </div>                         
                        <div class="form-group">
                            <textarea class="form-control input-text text-area" name="descricao" rows="5" data-rule="required" data-msg="Please write something for us" placeholder="Descrição"></textarea>
                            <div class="validation"></div>
                        </div>

                        <div class="form-group">
                            <textarea class="form-control input-text text-area" name="message" rows="5" data-rule="required" data-msg="Please write something for us" placeholder="upload"></textarea>
                            <div class="validation"></div>
                        </div>
                        
                        <div class="text-center"><button type="submit" class="input-btn">Adicionar</button></div>
                    </form>
                </div>	
            </div>
        </div>
</section>
    </div>



</asp:Content>
