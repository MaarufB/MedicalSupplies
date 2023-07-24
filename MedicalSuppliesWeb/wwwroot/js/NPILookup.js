function searchAPI() {
    var searchTerm = $('#npi_org').val();
    var apiUrl = 'https://clinicaltables.nlm.nih.gov/api/npi_idv/v3/search';
    var queryString = '?terms=' + searchTerm + '&maxList=10';


    $.ajax({
        url: apiUrl + queryString,
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            if (response && response.length) {
                console.log(response);


                var tableHTML = '<table id="resultTable">';
                tableHTML += '<tr><th>Name</th><th>NPI</th><th>Type</th><th>Practice Address</th></tr>';

                for (var i = 0; i < response.length; i++) {
                    var rowData = response[3][i];

                    if (rowData && rowData.length >= 4) {
                        tableHTML += '<tr>';
                        tableHTML += '<td>' + rowData[0] + '</td>'; // Name
                        tableHTML += '<td>' + rowData[1] + '</td>'; // NPI
                        tableHTML += '<td>' + rowData[2] + '</td>'; // Type
                        tableHTML += '<td>' + rowData[3] + '</td>'; // Address
                        tableHTML += '</tr>';
                    } else {
                        console.log('Invalid row data at index ' + i + ':', rowData);
                    }
                }

                tableHTML += '</table>';


                tableHTML = '<div class="table-container">' + tableHTML + '</div>';
                $('#resultTable').html(tableHTML);
            } else {
                console.log('No results found in the API response.');
            }
        },
        error: function (error) {

            console.error(error);
        }
    });
}