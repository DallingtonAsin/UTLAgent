<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Shared/master.Master" AutoEventWireup="true" CodeBehind="creditHistory.aspx.cs" Inherits="UTLAgent.Pages.creditHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <div class="row ml-2">
          <div class="col-sm-6">
            <h6 class="m-0 nunito-font text-success pl-2">
                <i class="fa fa-check-circle pr-1"></i>Approved Requests</h6>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Approved Credit Requests</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="ApprovedRequestsMultiView" runat="server">
        <asp:View ID="ApprovedRequestsView" runat="server">
                 
      <asp:GridView ID="ApprovedRequestsGridView" runat="server"  CssClass="nunito-font" BackColor="White" Width="1050px"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                                        HorizontalAlign="Center" AutoGenerateColumns="False" >
                                                        <FooterStyle BackColor="White" ForeColor="#006400" />
                                                        <HeaderStyle CssClass="main-color-bg nunito-font" Font-Bold="True" ForeColor="Black"
                                                            HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#006400" Font-Bold="True" ForeColor="#000000" />
                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                        <SortedDescendingCellStyle BackColor="#006400" />
                                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                        <Columns>
                                                             <asp:BoundField DataField="RequestId" HeaderText="RequestID" />
                                                            <asp:BoundField DataField="AccountNo" HeaderText="AccountNumber" />
                                                            <asp:BoundField DataField="RequestedAmount" DataFormatString="{0:N0}"  HeaderText="RequestedAmount" />
                                                            <asp:BoundField DataField="DateOfRequest" HeaderText="DateofRequest" />
                                                            <asp:BoundField DataField="approvedBy" HeaderText="ApprovedBy" />
                                                            <asp:BoundField DataField="DateOfApproval"   HeaderText="ApprovedOn" />
                                                           
                                                        </Columns>
                                                    </asp:GridView>
        </asp:View>
                             </asp:MultiView>
    <script type="text/javascript">
        $(document).ready(function () {
            $.noConflict();
            var table = $('[id*=ApprovedRequestsGridView]').prepend($("<thead></thead>").append($(this).find("tr:first")));
            var title = "Approved CREDIT REQUESTS";
            designTable(table, title);

        });
    </script>
</asp:Content>
