function App() {
    return (
        <Router>
            <Switch>
                <Route exact path="/" component={SearchComponent} />
                <Route path="/search-results" component={SearchResultsComponent} />
            </Switch>
        </Router>
    );
}

ReactDOM.render(React.createElement(App), document.getElementById('reactContainer'));
