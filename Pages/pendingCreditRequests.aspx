<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Shared/master.Master" AutoEventWireup="true" CodeBehind="pendingCreditRequests.aspx.cs" Inherits="UTLAgent.Pages.pendingCreditRequests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <div class="row ml-2">
          <div class="col-sm-6">
            <h6 class="m-0 nunito-font text-success">
                <i class="fa fa-question-circle pr-2"></i>Pending Requests</h6>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Pending Credit Requests</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
                    <asp:Label ID="failureTxt" runat="server" Text="" CssClass="text-danger nunito-font pl-4"></asp:Label>
                                        <div class="row mb-3 nunito-font ml-3">
                                             <div class="col-lg-3">
                                                <asp:Label ID="Label1" runat="server">RequestID</asp:Label>
                                                <asp:TextBox ID="requestIdTxt" runat="server" CssClass="form-control" placeholder="Enter Request ID"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-3">
                                                <asp:Label ID="LabelAccount" runat="server">Account</asp:Label>
                                                <asp:TextBox ID="AccountNoTxt" runat="server" CssClass="form-control" placeholder="Enter agent's account number"></asp:TextBox>
                                            </div>

                                             <div class="col-lg-3">
                                                <asp:Label ID="LabelAmt" runat="server">Amount</asp:Label>
                                                <asp:TextBox ID="AmtTxt" runat="server" CssClass="form-control" placeholder="Enter credit"></asp:TextBox>
                                            </div>

                                              <div class="col-lg-3 mt-4">
                                                <asp:Button ID="CreditBtn" runat="server" CssClass="btn btn-primary" Text="Credit Agent" OnClick="CreditBtn_Click" ></asp:Button>
                                            </div>
                                        </div>
      <asp:GridView ID="PendingRequestsGridView" AutoGenerateSelectButton="true" OnSelectedIndexChanged="PendingRequestsGridView_SelectedIndexChanged" runat="server" 
          CssClass="nunito-font" BackColor="White" Width="1050px"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                                        HorizontalAlign="Center" AutoGenerateColumns="False" >
                                                        <FooterStyle BackColor="White" ForeColor="#006400" />
                                                        <HeaderStyle CssClass="main-color-bg nunito-font" Font-Bold="True" ForeColor="Black"
                                                            HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#ADD8E6"  Font-Bold="True"  />
                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                        <SortedDescendingCellStyle BackColor="#006400" />
                                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                        <Columns>
                                                            
                                                             <asp:BoundField DataField="RequestId" HeaderText="RequestID" />
                                                            <asp:BoundField DataField="AccountNo" HeaderText="AccountNumber" />
                                                            <asp:BoundField DataField="RequestedAmount" DataFormatString="{0:N0}"  HeaderText="RequestedAmount" />
                                                            <asp:BoundField DataField="DateOfRequest" HeaderText="DateofRequest" />
                                                           
                                                        </Columns>
                                                    </asp:GridView>
       
    <script type="text/javascript">
        $(document).ready(function () {
             $.noConflict();
             var table = $('[id*=PendingRequestsGridView]').prepend($("<thead></thead>").append($(this).find("tr:first")));
             var title = "PENDING CREDIT REQUESTS";
             designTable(table, title);

         });
    </script>
</asp:Content>
