<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/master.Master" AutoEventWireup="true" CodeBehind="agents.aspx.cs" Inherits="UTLAgent.Pages.agents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">

      <div class="row mb-2">
          <div class="col-sm-6">
             <h6 class="m-0">
                <i class="fa fa-user-friends pr-2"></i>Registered Agents</h6>
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
    <asp:MultiView ID="MultiViewAgents" runat="server">

                                    <asp:View ID="View1" runat="server">


                                         <div class="row">

                                               
                                                <div class="col-lg-9">
                                                 <asp:GridView ID="AgentsGridView" runat="server"  CssClass="nunito-font" BackColor="White" Width="1050px"
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
           var table = $('[id*=AgentsGridView]').prepend($("<thead></thead>").append($(this).find("tr:first")));
           var title = "List of registered agents in the system";
           designTable(table, title);

       });
   </script>
    

</asp:Content>
