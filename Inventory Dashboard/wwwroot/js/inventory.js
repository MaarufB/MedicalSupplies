$(document).ready(function () {
    $.ajax({
        url: '/api/InventoryAPI',
        method: 'GET'
    })
        .done(function (data) {
            console.log(data);
            displayInventory(data);
        })
        .fail(function () {
            console.log('Error');
        });

    function displayInventory(inventory) {
        $('#inventory-list').empty();

        
        for (var i = 0; i < inventory.length; i++) {
            var item = inventory[i];

            
            var itemDiv = $('<div>');
            itemDiv.addClass('inventory-item');

            
            itemDiv.append('<span>Product: ' + item.product.productName + '</span>');
            itemDiv.append('<span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>');
            itemDiv.append('<span>Quantity: ' + item.quantityInStock + '</span>');
          

            
            $('#inventory-list').append(itemDiv);
        }
    }
});
