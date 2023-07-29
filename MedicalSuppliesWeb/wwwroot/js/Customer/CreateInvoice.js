
    var shippingAddressTextarea = document.getElementById("shippingAddress");
    var billingAddressTextarea = document.getElementById("billingAddress");
    var sameAddressCheckbox = document.getElementById("sameAddressCheckbox");

    sameAddressCheckbox.addEventListener("change", function () {
        if (this.checked) {
            billingAddressTextarea.value = shippingAddressTextarea.value;
            billingAddressTextarea.disabled = true;
            billingAddressTextarea.classList.add("text-muted");
        } else {
            billingAddressTextarea.value = "";
            billingAddressTextarea.disabled = false;
            billingAddressTextarea.classList.remove("text-muted");
        }
    });



    var productContainer = document.getElementById("product-container");
    var addProductButton = document.getElementById("add-product");
    var productIndex = 1;

    addProductButton.addEventListener("click", function () {
        var newProductField = document.createElement("div");
        newProductField.classList.add("order-item");

        newProductField.innerHTML = `
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="productName">Product Name:</label>
                                    <input type="text" class="form-control product-name" name="CustomerOrderItems[${productIndex}].ProductName" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="quantity">Quantity:</label>
                                    <input type="text" class="form-control quantity" name="CustomerOrderItems[${productIndex}].Quantity" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="unitPrice">Unit Price:</label>
                                    <input type="text" class="form-control unit-price" name="CustomerOrderItems[${productIndex}].UnitPrice" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="lineTotal">Line total:</label>
                                    <input type="text" class="form-control line-total" name="CustomerOrderItems[${productIndex}].LineTotal" />
                                </div>
                            </div>
                        </div>`;

        productContainer.appendChild(newProductField);
        productIndex++;
    });

 
        function getCustomerOrderDetails() {
            var customerOrderId = document.getElementById("orderNo").value;
            if (customerOrderId) {
                fetch(`/Customer/GetCustomerOrderDetails?customerOrderId=${customerOrderId}`)
                    .then(response => response.json())
                    .then(data => {
                        console.log("Response from server:", data);
                        if (data) {

                            console.log("Customer ID:", data.customerId);
                            console.log("Customer Name:", data.customerName);
                            console.log("Shipping Address:", data.shippingAddress);


                            // Update the form fields with the retrieved data
                            document.getElementById("customerId").value = data.customerId;
                            document.getElementById("customerName").value = data.customerName;
                            document.getElementById("shippingAddress").value = data.shippingAddress;


                            document.getElementById("invoiceTotal").value = data.customerOrderTotal;
                            document.getElementById("taxAmount").value = data.taxAmount;
                            document.getElementById("taxRate").value = data.taxRate;

                            updateOrderItems(data.customerOrderItems);


                        } else {
                            
                            alert("CustomerOrder not found.");
                        }
                    })
                    .catch(error => {
                        console.error('Error:', error);
                        alert("An error occurred while fetching data.");
                    });
            }
        }



        function updateOrderItems(orderItems) {
            // Remove all existing order items
            var productContainer = document.getElementById("product-container");
            productContainer.innerHTML = "";
            var invoiceTotal = 0;
            
            orderItems.forEach((item, index) => {
                var newProductField = document.createElement("div");
                newProductField.classList.add("order-item");

                newProductField.innerHTML = `
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="productName">Product Name:</label>
                                <input type="text" class="form-control product-name" name="CustomerOrderItems[${index}].ProductName" value="${item.productName}" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="quantity">Quantity:</label>
                                <input type="text" class="form-control quantity" name="CustomerOrderItems[${index}].Quantity" value="${item.quantity}" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="unitPrice">Unit Price:</label>
                                <input type="text" class="form-control unit-price" name="CustomerOrderItems[${index}].UnitPrice" value="${item.unitPrice}" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="lineTotal">Line total:</label>
                                <input type="text" class="form-control line-total" name="CustomerOrderItems[${index}].LineTotal" value="${item.lineTotal}" />
                            </div>
                        </div>
                    </div>`;

                productContainer.appendChild(newProductField);            

            });
            
        }



        function calculateGrandTotal() {
           
            var invoiceTotal = parseFloat(document.getElementById("invoiceTotal").value);
            var taxAmount = parseFloat(document.getElementById("taxAmount").value);
            var discount = parseFloat(document.getElementById("discount").value);

           
            var grandTotal = invoiceTotal + taxAmount - discount;

            
            document.getElementById("grandTotal").value = grandTotal;
        }

       
        document.getElementById("discount").addEventListener("change", calculateGrandTotal);





    


