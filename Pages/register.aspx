<%@ Page Title="" Language="C#"  EnableEventValidation="false" MasterPageFile="~/Shared/master.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="UTLAgent.Pages.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <div class="row mb-2">
       
                       
          <div class="col-sm-6">
            <span class="m-0 text-success">
                <i class="fa fa-plus-circle pr-1"></i>Register UTL Agent</span>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Register Agent</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="container-fluid nunito-font">
        <div class="row">
          <!-- left column -->
          <div class="col-md-12">
            <!-- general form elements -->
            <div class="card card-secondary">
              <div class="card-header">
                <h3 class="card-title">Register Agent</h3>
              </div>
             

            
             
                <div class="card-body">
                    <asp:MultiView ID="MultiView" runat="server">
                    <asp:View runat="server">

                    <form>
                          <div class="form-group">
                                                <asp:Label ID="requestId" runat="server" Text="First Name"></asp:Label>
                                                <asp:TextBox ID="FirstNameTxt" runat="server" CssClass="form-control" placeholder="Enter agent first name"></asp:TextBox>
                                            </div>
                  <div class="form-group">
                    <asp:Label ID="LastName" runat="server" Text="Last Name"></asp:Label>
                    <asp:TextBox ID="LastNameTxt" runat="server" Text="" 
                   placeholder="Enter agent's last name"
                   CssClass="form-control nunito-font"></asp:TextBox>

                  </div>

                  <div class="form-group">
                    <asp:Label ID="TelephoneTxt" runat="server" Text="Telephone No"></asp:Label>
                    <asp:TextBox ID="TelNoTxt" runat="server" 
                   placeholder="Enter agent telephone number"
                   CssClass="form-control nunito-font"></asp:TextBox>
                  </div>
                        <div class="form-group">
                    <asp:Label ID="AccountBalance" runat="server" Text="Account Balance"></asp:Label>
                    <asp:TextBox ID="BalanceTxt" runat="server" 
                   placeholder="0"
                   CssClass="form-control nunito-font"></asp:TextBox>
                  </div>
              
                <!-- /.card-body -->
                        <div class="row">
                        <div class="col-lg-2">
                        <asp:Button ID="RegisterAgentBtn" runat="server" Text="Register Agent" OnClick="RegisterAgentBtn_Click"
                            CssClass="btn btn-success f-15" />     
                        </div>
                        <div class="col-lg-10">
                               <asp:Label ID="messageTxt" runat="server" CssClass="text-success"></asp:Label>
  <asp:Label ID="failureTxt" runat="server"  CssClass="text-danger nunito-font"></asp:Label>
                            </div>
                        </div>
                          </form>
                        </asp:View>
                        </asp:MultiView>
                    </div>
                  
            
            </div>
              </div>
            </div>
     </div>


     
</asp:Content>
