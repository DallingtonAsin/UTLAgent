<%@ Page   Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Shared/master.Master" AutoEventWireup="true" CodeBehind="credit.aspx.cs" Inherits="UTLAgent.Pages.credit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <div class="row mb-2">
          <div class="col-sm-6">
            <span class="m-0 text-success">
                <i class="fa fa-plus-circle pr-1"></i>Credit Agent Account</span>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Credit Agent</li>
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
                <h3 class="card-title">Credit Agent</h3>
              </div>
             

            
             
                <div class="card-body">
                    <asp:MultiView ID="MultiView" runat="server">
                    <asp:View runat="server">
                    <form>
                          <div class="form-group">
                                                <label for="requestId">Request ID</label>
                                                <asp:TextBox ID="requestIdTxt" runat="server" CssClass="form-control" placeholder="Enter Request ID"></asp:TextBox>
                                            </div>
                  <div class="form-group">
                    <label for="exampleInputEmail1">A/C No.</label>
                    <asp:TextBox ID="AccountNoTxt" runat="server" Text="" 
                   placeholder="Enter agent's account number"
                   CssClass="form-control nunito-font"></asp:TextBox>

                  </div>
                  <div class="form-group">
                    <label for="exampleInputPassword1">Credit</label>
                    <asp:TextBox ID="AmtTxt" runat="server" 
                   placeholder="Enter amount of money to be credit on agent's account"
                   CssClass="form-control nunito-font"></asp:TextBox>
                  </div>
              
                <!-- /.card-body -->
                        <div class="col-lg-9">
                        <asp:Button ID="creditmoneyBtn" runat="server" Text="Credit Agent" OnClick="creditmoneyBtn_Click"
                            CssClass="btn btn-success f-15" />
                       <asp:Label ID="messageTxt" runat="server" Text="" CssClass="text-success"></asp:Label>
                      <asp:Label ID="failureTxt" runat="server" Text="" CssClass="text-danger nunito-font"></asp:Label>
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
