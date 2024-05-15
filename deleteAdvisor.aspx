<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deleteAdvisor.aspx.cs" Inherits="AdvisorTable.deleteAdvisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>

        <asp:Button ID="btnDelete" runat="server" Text="Delete Advisor" OnClick="btnDelete_Click" />
        <asp:Button ID="btnLookup" runat="server" Text="Lookup Advisor" OnClick="btnLookup_Click" />

        <br /><br />
        <asp:Label ID="lbl1" runat="server" Text=""></asp:Label>

        <br /> <br /> <br />
           <fieldset>
      
                 <p style="display:none;"><label for ="advisorID">Advisor ID:</label>
<asp:TextBox runat="server" ID="txtAdvId"></asp:TextBox></p>  
        <p><label for ="advisorName">Advisor Name:</label>
<asp:TextBox runat="server" ID="txtAdvName"></asp:TextBox></p>
             <p><label for ="officeNumber">Office Number:</label>
<asp:TextBox runat="server" ID="txtOffNum"></asp:TextBox></p>
        <p><label for ="phoneNum">Phone Number:</label>
<asp:TextBox runat="server" ID="txtPhoNum"></asp:TextBox></p>
       <asp:Button Text="Update Advisor" runat="server" ID="BtnSave" OnClick="BtnUpdate_Click" />
        <p></p>
   </fieldset>
        <div>
        </div>
    </form>
</body>
</html>
