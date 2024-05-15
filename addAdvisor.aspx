<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addAdvisor.aspx.cs" Inherits="AdvisorTable.addAdvisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function validateForm() {
            var x = document.forms["form1"]["txtAdvName"].value;
            if (x == "") {
                alert("Name must be filled out");
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return validateForm()">
        <h1>Add a Advisor</h1>
        <fieldset>
           
                
             <p><label for ="advisorName">Advisor Name:</label>
     <asp:TextBox runat="server" ID="txtAdvName"></asp:TextBox></p>
                  <p><label for ="officeNumber">Office Number:</label>
     <asp:TextBox runat="server" ID="txtOffNum"></asp:TextBox></p>
             <p><label for ="phoneNum">Phone Number:</label>
     <asp:TextBox runat="server" ID="txtPhoNum"></asp:TextBox></p>
            <asp:Button Text="Add Advisor" runat="server" ID="BtnSave" OnClick="BtnSave_Click" />
             <p></p>
        </fieldset>
        <div>
        </div>
    </form>
     <asp:Label runat="server" ID="lbl1"></asp:Label>
</body>
</html>
