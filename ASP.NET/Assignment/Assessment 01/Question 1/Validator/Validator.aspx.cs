using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Validator
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            // Server-side validation
            string validationMessage = ValidateInputs();
            if (!string.IsNullOrEmpty(validationMessage))
            {
                // Show validation errors in the modal
                ShowModal(validationMessage);
                return;
            }

            // If validation passes, display the entered information
            string message = $"Name: {txtName.Text}<br/>" +
                             $"Family Name: {txtFamilyName.Text}<br/>" +
                             $"Address: {txtAddress.Text}<br/>" +
                             $"City: {txtCity.Text}<br/>" +
                             $"Zip Code: {txtZipCode.Text}<br/>" +
                             $"Phone: {txtPhone.Text}<br/>" +
                             $"Email: {txtEmail.Text}";

            ShowModal(message);
        }

        private string ValidateInputs()
        {
            if (txtName.Text.Length < 2)
                return "Name must be at least 2 characters long.";

            if (txtFamilyName.Text.Length < 2)
                return "Family Name must be at least 2 characters long.";

            if (txtAddress.Text.Length < 2)
                return "Address must be at least 2 characters long.";

            if (txtCity.Text.Length < 2)
                return "City must be at least 2 characters long.";

            if (!Regex.IsMatch(txtPhone.Text, @"^\d{10}$"))
                return "Phone number must be 10 digits.";

            if (!Regex.IsMatch(txtEmail.Text, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
                return "Please enter a valid email address.";

            return string.Empty; // No errors, validation passed
        }

        private void ShowModal(string message)
        {
            // Script to open a Bootstrap modal and display a message
            string script = $@"
                <script type='text/javascript'>
                    var myModal = new bootstrap.Modal(document.getElementById('resultModal'));
                    document.getElementById('modalBody').innerHTML = '{message}';
                    myModal.show();
                </script>";

            ClientScript.RegisterStartupScript(this.GetType(), "ModalScript", script, false);
        }
    }
}