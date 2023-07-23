# Inventory & User Roles Management : XYZ Medical Supplies



## Description

The Inventory Management and Ticketing System for XYZ Medical Supplies is a comprehensive web application designed to streamline the management of inventory, handle customer and supplier transactions, and facilitate efficient order processing and approval workflows for XYZ Medical Supplies.

## Features

### Customer Section:

- View and manage active customer purchase orders and invoices as tickets.
- Details included for each ticket:
  - Date of Creation
  - Created By
  - Purchase Order No / Invoice No
  - Customer Name
  - Customer ID
  - Status (Approved/Created/Pending)
  - Payment Status
  - Priority

### Supplier Section:

- View and manage supplier purchase orders and invoices as tickets.
- Details included for each ticket:
  - Date of Creation
  - Created By
  - Purchase Order No / Invoice No
  - Supplier Name
  - Supplier ID
  - Status (Approved/Created/Pending)
  - Payment Status
  - Priority

### Inventory Alerts:

- View a list of products approaching stock reorder level.
- Details included for each product:
  - Product Name
  - Product ID
  - Stock Remaining
  - Supplier Name
  - Supplier ID
  - Date Last Purchased

### Create New Purchase Order Button:

- Allows users to create new purchase orders and redirect to the purchase order creation page.

### Create New Invoice Button:

- Allows users to create new invoices and redirect to the invoice creation page.

### Home Button:

- Redirects to the Home Page.

### Logout Button:

- Allows users to log out of the application.

### Admin Home:

- Admin login redirects to this page.
- Ticketing system similar to the User Dashboard (UDB) page.
- Two options (buttons) for each ticket:
  - Review: Redirect to PO/Invoice details (Editable).
  - Approve: Redirect to a confirmation page.
- Confirmation page allows admins to approve tickets, updating the status on both Admin Home and UDB.

## Usage

1. Clone the repository to your local machine.
2. Configure the database connection in the application settings.
3. Run the application using Visual Studio or the .NET CLI.
4. Access the application in your web browser.

## Dependencies

- GoogleMaps.LocationServices (version 1.2.0.5)
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore (version 6.0.15)
- Microsoft.AspNetCore.Identity.EntityFrameworkCore (version 6.0.18)
- Microsoft.AspNetCore.Identity.UI (version 6.0.18)
- Microsoft.EntityFrameworkCore.SqlServer (version 6.0.18)
- Microsoft.EntityFrameworkCore.Tools (version 6.0.18)
- Microsoft.VisualStudio.Web.CodeGeneration.Design (version 6.0.14)
- Select.HtmlToPdf.NetCore (version 23.1.0)

## Contributing

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Commit your changes and push to your branch.
4. Submit a pull request to the main repository.

## License

This project is licensed under the [MIT License](LICENSE).

## Acknowledgements

Special thanks to the team at XYZ Medical Supplies for their valuable inputs and support during the development of this project.

## Contact

For any questions or inquiries, please contact [mail.arjunsagar@gmail.com](mailto:mail.arjunsagar@gmail.com).
