<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SummaryBD.aspx.cs" Inherits="RSVPsite.SummaryBD" %>
<%@ Import Namespace= "RSVPsite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Список участников</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Имя участника" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Email" HeaderText="E-mail" ReadOnly="True" SortExpression="Email" />
            <asp:BoundField DataField="Phone" HeaderText="Телефон" ReadOnly="True" SortExpression="Phone" />
            <asp:CheckBoxField DataField="WillAttend" HeaderText="Присутствие" ReadOnly="True" SortExpression="WillAttend" />
            <asp:BoundField DataField="Rdate" DataFormatString="{0:d}" HeaderText="Дата регистрации" ReadOnly="True" SortExpression="Rdate" />
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="RSVPsite.SampleContext" EntityTypeName="" Select="new (Name, Email, Phone, WillAttend, Rdate, Reports)" TableName="GuestResponses">
    </asp:LinqDataSource>
</asp:Content>
