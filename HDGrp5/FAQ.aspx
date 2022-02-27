<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="HDGrp5.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
  <div class="panel-group border border-primary rounded" id="accordion">
  <div class="border border-bottom panel panel-default p-1">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
        How long is the processing time for tickets?</a>
        
      </h4>
    </div>
    <div id="collapse1" class="panel-collapse collapse in">
      <div class="panel-body">We give our best to give a solution within the next 24 hours.</div>
      
    </div>
  </div>
      <div class="panel panel-default p-1">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">
        How long is the delivery time?</a>
       
      </h4>
    </div>
    <div id="collapse2" class="panel-collapse collapse">
      <div class="panel-body">Within Germany up to three days. In Europe up to 5-7 days. The time to countries outside Europe varies. Please contact us for an estimation time.</div>
      
    </div>
  </div>
      <div class="border border-bottom panel panel-default p-1">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">Is there any sort of warranty on your products?
        </a>
        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3"></a>
      
      </h4>
    </div>
    <div id="collapse3" class="panel-collapse collapse in">
      <div class="panel-body">Yes! We are convinced that our products are one of the best you can get on the medical market. So on top of the legal warranty we will give additional 10 years warranty.</div>
      
    </div>
  </div>
      <div class="border border-bottom panel panel-default p-1">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">I have a problem with your product. How do i get support and help?
        </a>
        <a data-toggle="collapse" data-parent="#accordion" href="#collapse4"></a>
        
      </h4>
    </div>
    <div id="collapse4" class="panel-collapse collapse in">
      <div class="panel-body">First of all we are sorry if you have a problem with one of our products. The fastest way to get help is to contact your personal customer's contact person named in the contract. If there is no contact available you can create a ticket describing your exact issue.</div>
      
    </div>
  </div>
      <div class="border border-bottom panel panel-default p-1">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapse5">
        Do you offer direct support or support via remote?</a>
        
      </h4>
    </div>
    <div id="collapse5" class="panel-collapse collapse in">
      <div class="panel-body">For the best flexibility we offer both remote support and on site service depending on the issue and your personal preferences. The remote service is priced after expenditure of time. For the on site service there is an additional pricing for the route.</div>
      <div class="panel-body">Wir sind bemüht alle eingehenden Tickets in 24-48h zu beantworten.</div>
    </div>
  </div>
      <div class="border border-bottom panel panel-default p-1">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a data-toggle="collapse" data-parent="#accordion" href="#collapse6">
        Can i contact you in any other way?</a>
       
      </h4>
    </div>
    <div id="collapse6" class="panel-collapse collapse in">
      <div class="panel-body">Yes. We are available via phone. The phone number of our general support hotline is: <strong>+49 123456789</strong></div>
    
    </div>
  </div>
      </div>
        </div>
    </asp:Content>