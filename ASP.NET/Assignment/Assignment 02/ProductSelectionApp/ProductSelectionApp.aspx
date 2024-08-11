<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductSelection.aspx.cs" Inherits="ProductSelectionApp.ProductSelection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Selection</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h2>Select a Product</h2>
            
            <!-- Product Selection Dropdown -->
            <div class="mb-3">
                <label for="ProductDropdown" class="form-label">Choose a Product:</label>
                <asp:DropDownList ID="ddlProducts" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            
            <!-- Image Display -->
            <div class="mb-3">
                <asp:Image ID="imgProduct" runat="server" CssClass="img-thumbnail" Width="300px" />
            </div>
            
            <!-- Price Button -->
            <div class="mb-3">
                <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" CssClass="btn btn-primary" OnClick="btnGetPrice_Click" />
            </div>
            
            <!-- Price Label -->
            <div class="mb-3">
                <asp:Label ID="lblPrice" runat="server" CssClass="form-label" />
            </div>

            <!-- Validation Section -->
            <h3>Validation Section</h3>

            <div class="mb-3">
                <label for="Name" class="form-label">Name:</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="FamilyName" class="form-label">Family Name:</label>
                <asp:TextBox ID="txtFamilyName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Address" class="form-label">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="City" class="form-label">City:</label>
                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ZipCode" class="form-label">Zip Code:</label>
                <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Phone" class="form-label">Phone:</label>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Email" class="form-label">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnValidate" runat="server" Text="Validate" CssClass="btn btn-primary" OnClick="btnValidate_Click" />
            </div>

            <!-- Validation Result -->
            <div class="mb-3">
                <asp:Label ID="lblValidationResult" runat="server" CssClass="form-label" />
            </div>

        </div>
    </form>
</body>
</html>
