<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="Admin_AdminHome" Title="Admin Home" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align="center" style="width: 100%; height: 465px">
    <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/rss.jpg" style="width: 100%; height: 600px"/>--%>
    <cc1:accordion runat="server" ID="Accordion1" HeaderCssClass="HeaderCSS" HeaderSelectedCssClass="HeaderSelectedCSS"
            ContentCssClass="ContentCss" Width="1000px" Height="100%" BorderStyle="Solid"
            BackColor="#d8e4f8" BorderColor="#d8e4f8" Style="color: #000099; background-color: #d8e4f8;"
            RequireOpenedPane="false">
            <Panes>                
                <cc1:AccordionPane runat="server" ID="AccordionPane1">
                    <Header>
                        <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Personal Details</a>
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                           sjfldkgjkf
                           dgfdhgh
                           <br /> 
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane2">
                    <Header>
                       <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Upload Photo
                        </a>
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                             sjfldkgjkf
                           dgfdhgh
                           <br /> 
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane3">
                    <Header>
                        <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Communication Detail
                            <asp:Label ID="Label2" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label>
                        </a>
                        <hr />
                    </Header>
                    <Content>
                         <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                             sjfldkgjkf
                           dgfdhgh
                           <br /> 
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane4">
                    <Header>
                       <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Qualification Details</a>
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                             sjfldkgjkf
                           dgfdhgh
                           <br /> 
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane7">
                    <Header>
                        <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Meeting Details</a>                      
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                              sjfldkgjkf
                           dgfdhgh
                           <br /> 
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane8">
                    <Header>
                        <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Sangh Pariwar Details</a>                      
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                              sjfldkgjkf
                           dgfdhgh
                           <br /> 
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane6">
                    <Header>
                        <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Extra Activity</a>
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                              sjfldkgjkf
                           dgfdhgh
                           <br /> 
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane5">
                    <Header>
                        <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Employment Details</a>
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                             sjfldkgjkf
                           dgfdhgh
                           <br />  
                        </div>
                    </Content>
                </cc1:AccordionPane>  
            </Panes>          
</cc1:accordion>
</div>
</asp:Content>

