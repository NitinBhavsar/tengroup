<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUpload.aspx.cs" Inherits="FileUpload" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
            background-color: #fff;
        }
        table th
        {
            background-color: #ff0097;
            color: #fff;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border: 1px solid #ccc;
        }
        table, table table td
        {
            border: 0px solid #ccc;
        }
        .button {
    background-color: #223c88; /* Blue */
    border: none;
    color: white;
    padding: 15px 32px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:FileUpload ID="FileUpload1"  runat="server" />
    <asp:Button ID="btnRead" CssClass="button" runat="server" Text="Import" OnClick="ReadCSV" />
    <hr />

        <hr />
        <br />
        <asp:Label ID="lblResult" runat="server" ></asp:Label>
        
<br />
        <asp:Label ID="lblResultdetails" runat="server" ></asp:Label>
        
<br />

    <asp:GridView ID="grdData" runat="server">
    </asp:GridView>
    </form>
</body>
</html>