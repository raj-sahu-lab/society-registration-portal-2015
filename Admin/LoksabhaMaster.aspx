<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="LoksabhaMaster.aspx.cs" Inherits="Admin_LoksabhaMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <table align="center">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px" 
                    Font-Underline="True" ForeColor="#003399" Text="LOKSABHA MASTER"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Sr No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtcomm_id" runat="server" ReadOnly="True" Width="170px"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td><asp:Label ID="Label3" runat="server" Text="Select Country"></asp:Label></td>
        <td>
        <asp:DropDownList ID="ddl_country" runat="server" Width="195px" AutoPostBack="True" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged">
                            <asp:ListItem>--Select Country--</asp:ListItem>
                            <asp:ListItem>India</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                            </asp:DropDownList>
        </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="State Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_state" runat="server" Width="195px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Loksabha Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtlabel_name" runat="server" Width="170px"></asp:TextBox>
            </td>
        </tr>
        <tr>
         <td>
                <asp:Label ID="Label4" runat="server" Text="Loksabha Code"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtcode" runat="server" Width="170px" MaxLength="3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lb_Message" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <table>
                    <tr>
                        <td>
                        <asp:Button ID="Button1" runat="server" BackColor="#FF6600" Font-Bold="True" 
                            ForeColor="White" Height="30px" Text="Save" Width="65px" 
                            onclick="Button1_Click" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" BackColor="#FF6600" Font-Bold="True" 
                            ForeColor="White" Height="30px" Text="Reset" Width="65px" 
                            onclick="Button2_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    DataKeyNames="Sr_No" DataSourceID="SqlDataSource1">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                            ShowSelectButton="True" />
                        <asp:BoundField DataField="Sr_No" HeaderText="Sr_No" ReadOnly="True" 
                            SortExpression="Sr_No" />
                        <asp:BoundField DataField="State_Name" HeaderText="State_Name" 
                            SortExpression="State_Name" />
                        <asp:BoundField DataField="Loksabha" HeaderText="Loksabha" 
                            SortExpression="Loksabha" />
                             <asp:BoundField DataField="Loksabha_Code" HeaderText="Loksabha_Code" 
                            SortExpression="Loksabha_Code" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BITRSS %>" 
                    DeleteCommand="DELETE FROM [LoksabhaMaster] WHERE [Sr_No] = @Sr_No" 
                    InsertCommand="INSERT INTO [LoksabhaMaster] ([Sr_No], [State_Name], [Loksabha], [Loksabha_Code]) VALUES (@Sr_No, @State_Name, @Loksabha, @Loksabha_Code)" 
                    SelectCommand="SELECT * FROM [LoksabhaMaster] ORDER BY [Sr_No], [State_Name], [Loksabha]" 
                    
                    UpdateCommand="UPDATE [LoksabhaMaster] SET [State_Name] = @State_Name, [Loksabha] = @Loksabha, [Loksabha_Code]= @Loksabha_Code WHERE [Sr_No] = @Sr_No">
                    <DeleteParameters>
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="State_Name" Type="String" />
                        <asp:Parameter Name="Loksabha" Type="String" />
                        <asp:Parameter Name="Loksabha_Code" Type="String" />
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                        <asp:Parameter Name="State_Name" Type="String" />
                        <asp:Parameter Name="Loksabha" Type="String" />
                        <asp:Parameter Name="Loksabha_Code" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

