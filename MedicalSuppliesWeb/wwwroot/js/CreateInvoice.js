
(function () {


    function handleSameAddressCheckbox() {

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

    }


    function handleAddProductButton() {

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
                                                <input type="text" class="form-control product-name" name="SupplierOrderItems[${productIndex}].ProductName" />
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label for="quantity">Quantity:</label>
                                                        <input type="text" class="form-control quantity" name="SupplierOrderItems[${productIndex}].Quantity" />
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label for="unitPrice">Unit Price:</label>
                                                        <input type="text" class="form-control unit-price" name="SupplierOrderItems[${productIndex}].UnitPrice" />
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label for="lineTotal">Line total:</label>
                                                        <input type="text" class="form-control line-total" name="SupplierOrderItems[${productIndex}].LineTotal" />
                                            </div>
                                        </div>
                                    </div>`;

            productContainer.appendChild(newProductField);
            productIndex++;
        });


    }

    function setInitialInvoiceDate() {

        var currentDate = new Date();


        var year = currentDate.getFullYear();
        var month = String(currentDate.getMonth() + 1).padStart(2, '0');
        var day = String(currentDate.getDate()).padStart(2, '0');
        var formattedDate = year + '-' + month + '-' + day;

        document.getElementById('invoiceDate').value = formattedDate;

    }

  
        function getSupplierOrderDetails() {
            var supplierOrderId = document.getElementById("orderNo").value;
            if (supplierOrderId) {
                fetch(`/Supplier/GetSupplierOrderDetails?supplierOrderId=${supplierOrderId}`)
                    .then(response => response.json())
                    .then(data => {
                        console.log("Response from server:", data);
                        if (data) {

                            console.log("Supplier ID:", data.supplierId);
                            console.log("Supplier Name:", data.supplierName);
                            console.log("Shipping Address:", data.shippingAddress);

                            
                            document.getElementById("supplierId").value = data.supplierId;
                            document.getElementById("supplierName").value = data.supplierName;
                            document.getElementById("shippingAddress").value = data.shippingAddress;


                            document.getElementById("invoiceTotal").value = data.supplierOrderTotal;
                            document.getElementById("taxAmount").value = data.taxAmount;
                            document.getElementById("taxRate").value = data.taxRate;

                            updateOrderItems(data.supplierOrderItems);


                        } else {

                            alert("SupplierOrder not found.");
                        }
                    })
                    .catch(error => {
                        console.error('Error:', error);
                        alert("An error occurred while fetching data.");
                    });
            }
        }


        function updateOrderItems(orderItems) {
           
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
                                        <label for="productName">Product:</label>
                                                <input type="text" class="form-control product-name" name="SupplierOrderItems[${index}].ProductName" value="${item.productName}" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label for="quantity">Quantity:</label>
                                                <input type="text" class="form-control quantity" name="SupplierOrderItems[${index}].Quantity" value="${item.quantity}" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label for="unitPrice">Unit Price:</label>
                                                <input type="text" class="form-control unit-price" name="SupplierOrderItems[${index}].UnitPrice" value="${item.unitPrice}" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label for="lineTotal">Line total:</label>
                                                <input type="text" class="form-control line-total" name="SupplierOrderItems[${index}].LineTotal" value="${item.lineTotal}" />
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


    handleSameAddressCheckbox();
    handleAddProductButton();
    setInitialInvoiceDate();


})();