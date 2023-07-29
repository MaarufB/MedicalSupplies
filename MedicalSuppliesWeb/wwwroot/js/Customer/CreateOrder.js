
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
        var productIndex = 0;

        function addProductField() {
             
            
            var newProductField = document.createElement("div");
            newProductField.classList.add("order-item");
            productIndex++;
            var currentIndex = productIndex;
            newProductField.innerHTML = `
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="productName">Product:</label>
                                                <input type="text" class="form-control product-name" name="CustomerOrderItems[${productIndex}].ProductName" oninput="getProductUnitPrice(this.value, ${productIndex})"/>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label for="quantity">Quantity:</label>
                                                <input type="text" class="form-control quantity" name="CustomerOrderItems[${productIndex}].Quantity" oninput="updateLineTotal(${productIndex})" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label for="unitPrice">Unit Price:</label>
                                                <input type="text" class="form-control unit-price" name="CustomerOrderItems[${productIndex}].UnitPrice" oninput="updateLineTotal(${productIndex})" />
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label for="lineTotal">Line total:</label>
                                        <input type="text" class="form-control line-total" name="CustomerOrderItems[${productIndex}].LineTotal" />
                                    </div>
                                </div>

                                
                                 <div class="col-md-1">
                                       <div class="form-group">
                                           <label>&nbsp;</label>
                                           <button type="button" class="btn btn-outline-danger btn-sm" onclick="deleteProductField(${productIndex})">Delete</button>
                                        </div>
                                 </div>



                            </div>`;

            productContainer.appendChild(newProductField);
            getProductUnitPrice("", currentIndex);
        }


        addProductButton.addEventListener("click", addProductField);


   


    
        
        var currentDate = new Date();

       
        var year = currentDate.getFullYear();
        var month = String(currentDate.getMonth() + 1).padStart(2, '0');
        var day = String(currentDate.getDate()).padStart(2, '0');
        var formattedDate = year + '-' + month + '-' + day;

       
        document.getElementById('orderDate').value = formattedDate;
   



   
        function getCustomerDetails(customerId) {

            fetch(`/Customer/GetCustomerDetails?customerId=${customerId}`)
                .then(response => response.json())
                .then(data => {
                    if (data) {

                        document.getElementById("customerName").value = data.firstName + " " + data.lastName;
                    } else {

                        document.getElementById("customerName").value = "";
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                });
        }
 


   


        let fetchCounter = 0;
        function getProductUnitPrice(productName, index) {
            const currentFetchCounter = ++fetchCounter; 

            fetch(`/Product/GetProductUnitPrice?productName=${productName}`)
                .then(response => response.json())
                .then(data => {
                    if (data && currentFetchCounter === fetchCounter) {
                        const unitPriceInput = document.getElementsByName(`CustomerOrderItems[${index}].UnitPrice`)[0];
                        const lineTotalInput = document.getElementsByName(`CustomerOrderItems[${index}].LineTotal`)[0];

                        unitPriceInput.value = data.unitPrice;
                        updateLineTotal(index);
                    } else if (currentFetchCounter === fetchCounter) {
                        const unitPriceInput = document.getElementsByName(`CustomerOrderItems[${index}].UnitPrice`)[0];
                        unitPriceInput.value = "";
                        updateLineTotal(index);
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                });
        }


        function updateLineTotal(index) {
            const quantity = parseFloat(document.getElementsByName(`CustomerOrderItems[${index}].Quantity`)[0].value);
            const unitPrice = parseFloat(document.getElementsByName(`CustomerOrderItems[${index}].UnitPrice`)[0].value);


            const lineTotal = isNaN(quantity) || isNaN(unitPrice) ? 0 : quantity * unitPrice;

            document.getElementsByName(`CustomerOrderItems[${index}].LineTotal`)[0].value = lineTotal.toFixed(2);
            updateOrderTotal();
        }


        function updateOrderTotal() {
            let orderTotal = 0;
            const lineTotalInputs = document.querySelectorAll(".line-total");
            lineTotalInputs.forEach(input => {
                orderTotal += parseFloat(input.value);
            });
            const taxRate = parseFloat(document.getElementById("taxRate").value);

            
            const taxAmount = orderTotal * (taxRate / 100);

            
            const grandTotal = orderTotal + taxAmount;

            
            document.getElementById("orderTotal").value = orderTotal.toFixed(2);
            document.getElementById("taxAmount").value = taxAmount.toFixed(2);
            document.getElementById("grandTotal").value = grandTotal.toFixed(2);
        }


        function deleteProductField(index) {
            var productField = document.querySelector(`[name="CustomerOrderItems[${index}].ProductName"]`).closest(".order-item");
            productField.remove();

            
            var remainingProductFields = document.querySelectorAll(".order-item");
           
            remainingProductFields.forEach((field, newIndex) => {
                var productNameInput = field.querySelector(".product-name");
                var quantityInput = field.querySelector(".quantity");
                var unitPriceInput = field.querySelector(".unit-price");
                var lineTotalInput = field.querySelector(".line-total");

                productNameInput.name = `CustomerOrderItems[${newIndex}].ProductName`;
                quantityInput.name = `CustomerOrderItems[${newIndex}].Quantity`;
                unitPriceInput.name = `CustomerOrderItems[${newIndex}].UnitPrice`;
                lineTotalInput.name = `CustomerOrderItems[${newIndex}].LineTotal`;

                var deleteButton = field.querySelector(".btn-outline-danger");
                deleteButton.setAttribute("onclick", `deleteProductField(${newIndex})`);
                
            });

            updateOrderTotal();
        }


    

