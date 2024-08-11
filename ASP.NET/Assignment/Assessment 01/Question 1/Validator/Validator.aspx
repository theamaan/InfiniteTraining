<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Validator.Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validator Page</title>
    <!-- Adding Bootstrap for styling and modal functionality -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        function validateForm() {
            var name = document.getElementById('<%= txtName.ClientID %>').value;
            var familyName = document.getElementById('<%= txtFamilyName.ClientID %>').value;
            var address = document.getElementById('<%= txtAddress.ClientID %>').value;
            var city = document.getElementById('<%= txtCity.ClientID %>').value;
            var zipCode = document.getElementById('<%= txtZipCode.ClientID %>').value;
            var phone = document.getElementById('<%= txtPhone.ClientID %>').value;
            var email = document.getElementById('<%= txtEmail.ClientID %>').value;

            var phonePattern = /^\d{10}$/; // Pattern for a 10-digit phone number
            var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Simple email validation pattern

            if (name.length < 2) {
                alert('Name must be at least 2 characters long.');
                return false;
            }
            if (familyName.length < 2) {
                alert('Family Name must be at least 2 characters long.');
                return false;
            }
            if (address.length < 2) {
                alert('Address must be at least 2 characters long.');
                return false;
            }
            if (city.length < 2) {
                alert('City must be at least 2 characters long.');
                return false;
            }
            if (!phonePattern.test(phone)) {
                alert('Phone number must be 10 digits.');
                return false;
            }
            if (!emailPattern.test(email)) {
                alert('Please enter a valid email address.');
                return false;
            }

            return true; // Form is valid
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return validateForm()">
        <div class="container mt-5">
            <h2>Validator Form</h2>
            <div class="mb-3">
                <label for="Name" class="form-label">Name:</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="FamilyName" class="form-label">Family Name:</label>
                <asp:TextBox ID="txtFamilyName" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Address" class="form-label">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="City" class="form-label">City:</label>
                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ZipCode" class="form-label">Zip Code:</label>
                <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Phone" class="form-label">Phone:</label>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="Email" class="form-label">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <asp:Button ID="btnCheck" runat="server" Text="Check" CssClass="btn btn-primary" OnClick="btnCheck_Click" />
        </div>
        
        <!-- Bootstrap modal for displaying the validation results -->
        <div class="modal fade" id="resultModal" tabindex="-1" aria-labelledby="resultModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="resultModalLabel">Validation Results</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body" id="modalBody">
                        <!-- Validation results will be displayed here -->
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        
    </form>
</body>
</html>
