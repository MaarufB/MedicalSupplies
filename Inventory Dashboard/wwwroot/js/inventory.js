$(document).ready(function () {
    // Make an AJAX request to fetch the inventory data
    $.ajax({
        url: '/api/InventoryAPI',
        method: 'GET',
        success: function (data) {
            // Handle the successful response
            displayInventory(data);
        },
        error: function () {
            // Handle the error
            console.log('Error occurred while fetching inventory data.');
        }
    });

    function displayInventory(inventory) {
        // Clear the existing data in the div
        $('#inventory-list').empty();

        // Loop through the inventory items and create HTML elements to display them
        for (var i = 0; i < inventory.length; i++) {
            var item = inventory[i];

            // Create a div to display the inventory item
            var itemDiv = $('<div>');
            itemDiv.addClass('inventory-item');

            // Add the item details to the div
            itemDiv.append('<p>Product Name: ' + item.productName + '</p>');
            itemDiv.append('<p>Quantity in Stock: ' + item.quantityInStock + '</p>');
            // Add more details as needed

            // Add the item div to the main div
            $('#inventory-list').append(itemDiv);
        }
    }
});
