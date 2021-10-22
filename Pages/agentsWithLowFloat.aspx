<%@ Page EnableEventValidation="false" Title="UTL | Pending Requests" Language="C#" MasterPageFile="~/Shared/master.Master" AutoEventWireup="true" CodeBehind="agentsWithLowFloat.aspx.cs" Inherits="UTLAgent.Pages.agentsWithLowFloat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
      <div class="row mb-2">
          <div class="col-sm-6">
             <span class="m-0 nunito-font text-success">
                <i class="fa fa-user-friends pr-2"></i>Agents running out of float</span>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Registered Agents</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MultiViewAgentsWithLowFloat" runat="server">

                                    <asp:View ID="View1" runat="server">
                                          <asp:Label ID="ErrorTxt" runat="server" Text="" CssClass="text-danger"></asp:Label>
                                        <div class="row mb-3 nunito-font">
                                            <div class="col-lg-4">
                                                <label for="Account" class="nunito-font ml-2">Account</label>
                                                <asp:TextBox ID="AccountNo" runat="server" CssClass="form-control ml-2 nunito-font" placeholder="Enter agent's account number"></asp:TextBox>
                                            </div>

                                             <div class="col-lg-4 mb-2">
                                                <label for="Amount" class="nunito-font pl-2">Amount</label>
                                                <asp:TextBox ID="minimumCredit" runat="server" CssClass="form-control nunito-font" placeholder="Enter minimum credit"></asp:TextBox>
                                            </div>

                                              <div class="col-lg-4 mb-2 pt-2">
                                                  <asp:Label Text="" ID="null" runat="server" CssClass="mt-3"></asp:Label>
                                                <asp:Button ID="GetAgentswithSetMin" runat="server" CssClass="btn btn-primary mt-4" Text="Generate Report" OnClick="GetAgentswithSetMin_Click"></asp:Button>
                                            </div>
                                        </div>

                                         <div class="row">

                                               <h6>
                                                   <asp:Label ID="InfoTxt" runat="server" CssClass="text-info ml-4 nunito-font"></asp:Label>
                                               </h6>
                                                <div class="col-lg-9">
                                                   
                                                 <asp:GridView ID="AgentsRunningOutofFloatGridView" runat="server"  BackColor="White" Width="1050px"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                                        HorizontalAlign="Center" AutoGenerateColumns="False" >
                                                        <FooterStyle BackColor="White" ForeColor="#006400" />
                                                        <HeaderStyle CssClass="main-color-bg nunito-font" Font-Bold="True" ForeColor="Black"
                                                            HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#006400" Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                        <SortedDescendingCellStyle BackColor="#006400" />
                                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                        <Columns>
                                                            <asp:BoundField DataField="id" HeaderText="AgentID" />
                                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                                            <asp:BoundField DataField="telNo" HeaderText="Contact" />
                                                            <asp:BoundField DataField="accountNo" HeaderText="A/C NO" />
                                                            <asp:BoundField DataField="accountBalance" DataFormatString="{0:N0}" HeaderText="A/C Balance" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    </div>
                                                 </div>
                                     </asp:View>
                             </asp:MultiView>

   <script type="text/javascript">
       $(document).ready(function () {
           $.noConflict();
           var table = $('[id*=AgentsRunningOutofFloatGridView]').prepend($("<thead></thead>").append($(this).find("tr:first")));
           var title = "List of registered agents in the system";
           designTable(table, title);

       });
   </script>
    

</asp:Content>

