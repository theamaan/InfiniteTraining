using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace ProductSelectionApp
{
    public partial class ProductSelection : Page
    {
        // Dictionary to store product prices and images
        private readonly Dictionary<string, (string ImageUrl, decimal Price)> products = new Dictionary<string, (string ImageUrl, decimal Price)>
        {
            { "Laptop", ("~/images/laptop.jpg", 800m) },
            { "Smartphone", ("~/images/smartphone.jpg", 600m) },
            { "Tablet", ("~/images/tablet.jpg", 300m) },
            { "Smartwatch", ("~/images/smartwatch.jpg", 150m) }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the dropdown list
                ddlProducts.DataSource = products.Keys;
                ddlProducts.DataBind();
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display the selected product's image
            string selectedProduct = ddlProducts.SelectedValue;
            imgProduct.ImageUrl = products[selectedProduct].ImageUrl;
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            // Display the selected product's price
            string selectedProduct = ddlProducts.SelectedValue;
            lblPrice.Text = $"Price: ${products[selectedProduct].Price}";
        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            string validationResult = ValidateInputs();
            lblValidationResult.Text = validationResult;
        }

        private string ValidateInputs()
        {
            // Name and Family Name should not be the same
            if (txtName.Text == txtFamilyName.Text)
                return "Name and Family Name should not be the same.";

            // Address must be at least 2 characters long
            if (txtAddress.Text.Length < 2)
                return "Address must be at least 2 characters long.";

            // City must be at least 2 characters long
            if (txtCity.Text.Length < 2)
                return "City must be at least 2 characters long.";

            // Zip Code must be exactly 5 digits
            if (!Regex.IsMatch(txtZipCode.Text, @"^\d{5}$"))
                return "Zip Code must be exactly 5 digits.";

            // Phone number should be in the format XX-XXXXXXX or XXX-XXXXXXX
            if (!Regex.IsMatch(txtPhone.Text, @"^\d{2}-\d{7}$") && !Regex.IsMatch(txtPhone.Text, @"^\d{3}-\d{7}$"))
                return "Phone number must be in the format XX-XXXXXXX or XXX-XXXXXXX.";

            // Email should be a valid email format
            if (!Regex.IsMatch(txtEmail.Text, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
                return "Please enter a valid email address.";

            return "Validation passed!";
        }
    }
}
