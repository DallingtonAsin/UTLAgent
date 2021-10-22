<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/master.Master" AutoEventWireup="true" CodeBehind="Logs.aspx.cs" Inherits="UTLAgent.Pages.transactionalLogs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:MultiView ID="MultiViewLogs" runat="server">
                                    <asp:View ID="WLedgerView" runat="server">
                                         <div class="row pt-4">
                                            <div class="col-lg-3">
                                                  
                                                   <asp:Label ID="MsgFailureTxt" runat="server" CssClass="text-danger nunito-font  b--100" Text=""></asp:Label>
                                                
   <asp:DropDownList ID="LogType" runat="server" CssClass="form-control nunito-font">
    <asp:ListItem Enabled="true" Text="Select log category" Value="-1"></asp:ListItem>
    <asp:ListItem Text="Error logs" Value="error"></asp:ListItem>
    <asp:ListItem Text="Request logs" Value="request"></asp:ListItem>
    <asp:ListItem Text="Transactional logs" Value="success"></asp:ListItem>
</asp:DropDownList>
                                               </div>
                                                  <div class="col-lg-6 pt-1">
                                                <asp:Button ID="ViewCustomLogs" runat="server" CssClass="btn btn-sm nunito-font  text-white overview-item--c2" Text="View Logs" OnClick="ViewCustomLogs_Click"  />
                                             
                                            </div>
                                        </div>

                                         <div class="row">
                                                <div class="col-lg-9">
                                                     <asp:Label ID="MsgWarningTxt" runat="server" CssClass="text-warning nunito-font pl-2  b--100" Text=""></asp:Label>
                                                 <asp:GridView ID="LogsGridView" runat="server"  CssClass="nunito-font" BackColor="White" Width="1050px"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                                        HorizontalAlign="Center" AutoGenerateColumns="False" >
                                                        <FooterStyle BackColor="White" ForeColor="#006400" />
                                                        <HeaderStyle CssClass="main-color-bg nunito-font" Font-Bold="True" ForeColor="White"
                                                            HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#006400" Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                        <SortedDescendingCellStyle BackColor="#006400" />
                                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                        <Columns>
                                                             <asp:BoundField DataField="date" HeaderText="Date" />
                                                            <asp:BoundField DataField="log_details" HeaderText="Log Details" />
                                                            <asp:BoundField DataField="doneBy" HeaderText="User" />
                                                           
                                                        </Columns>
                                                    </asp:GridView>
                                                    </div>
                                                 </div>
                                        <div class="row">
                                           <div class="col-lg-10 pt-2">
                                               <asp:Label ID="MsgSuccessTxt" runat="server" CssClass="text-success font-weight-bold b--100" Text=""></asp:Label>
           
                                           </div>
                                        </div>
                                     </asp:View>
         </asp:MultiView>
  
<script type="text/javascript">
    $(document).ready(function () {
        var table = $('[id*=LogsGridView]').prepend($("<thead></thead>").append($(this).find("tr:first")));
        var title = "List of logs in the system";
        designTable(table, title);

    });
</script>
    
</asp:Content>
