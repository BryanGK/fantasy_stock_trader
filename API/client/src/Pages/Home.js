import React from 'react';
import SummaryChart from '../Components/SummaryChart';
import StockSearch from '../Components/StockSearch';
import '../Styles/Home.css';

function Home() {
    const handleSearch = e => {
        e.preventDefault();
        console.log("search");
    }

    return (
        <div className="home">
            <h1 className="home-header">Home</h1>
            <div className="container chart-container">
                <SummaryChart />
            </div>
            <div className="stock-search-container">
                <StockSearch
                    handleSearch={handleSearch}
                />
            </div>
        </div>
    )
}

export default Home;