// search.js
function SearchResults() {
    const searchQuery = "@ViewBag.SearchQuery";

    // Function to fetch search results from the backend API using Axios
    const fetchSearchResults = async () => {
        try {
            const productPromise = axios.get(`/api/Search/products?query=${encodeURIComponent(searchQuery)}`);
            const customerPromise = axios.get(`/api/Search/customers?query=${encodeURIComponent(searchQuery)}`);
            const supplierPromise = axios.get(`/api/Search/suppliers?query=${encodeURIComponent(searchQuery)}`);

            // Wait for all three promises to resolve using Promise.all
            const [productResponse, customerResponse, supplierResponse] = await Promise.all([
                productPromise,
                customerPromise,
                supplierPromise
            ]);

            console.log('Product Data:', productResponse.data);
            console.log('Customer Data:', customerResponse.data);
            console.log('Supplier Data:', supplierResponse.data);

            // Assuming the responses have the search results in the "data" property
            const productResults = productResponse.data;
            const customerResults = customerResponse.data;
            const supplierResults = supplierResponse.data;

            return { productResults, customerResults, supplierResults };
        } catch (error) {
            console.error('Error fetching search results:', error);
            return {
                productResults: [],
                customerResults: [],
                supplierResults: []
            };
        }
    };

    const [searchResults, setSearchResults] = React.useState({
        productResults: [],
        customerResults: [],
        supplierResults: []
    });

    React.useEffect(() => {
        // Fetch the search results when the component mounts
        fetchSearchResults().then((results) => setSearchResults(results));
    }, []);

    return (
        <div>
            <h2>Showing results for: {searchQuery}</h2>

            <div>
                <h3>Products</h3>
                <ul>
                    {searchResults.productResults.map((result) => (
                        <li key={result.id}>{result.title}</li>
                    ))}
                </ul>
            </div>

            <div>
                <h3>Customers</h3>
                <ul>
                    {searchResults.customerResults.map((result) => (
                        <li key={result.id}>{result.name}</li>
                    ))}
                </ul>
            </div>

            <div>
                <h3>Suppliers</h3>
                <ul>
                    {searchResults.supplierResults.map((result) => (
                        <li key={result.id}>{result.name}</li>
                    ))}
                </ul>
            </div>
        </div>
    );
}

ReactDOM.render(<SearchResults />, document.getElementById('searchResults'));
