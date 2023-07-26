//For some reason when i move the script to this separate javascript file it is not drawing the chart
//need to check this

// Get the model data from the data attribute
var inventoryData = JSON.parse(document.getElementById('inventoryData').dataset.model);
console.log("Inventory Data:", inventoryData);

var labels = inventoryData.map(item => item.ProductName);
console.log("Labels:", labels);

var quantities = inventoryData.map(item => item.QuantityInStock);
console.log("Quantities:", quantities);

var inventoryChart = new Chart(document.getElementById('inventoryChart'), {
    type: 'bar',
    data: {
        labels: labels,
        datasets: [{
            label: 'Inventory Count',
            data: quantities,
            backgroundColor: 'rgba(75, 192, 192, 0.2)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1
        }]
    },
    options: {
        responsive: true,
        maintainAspectRatio: true
    }
});

console.log("Chart created successfully!");
