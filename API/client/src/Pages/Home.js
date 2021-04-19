import React from 'react';
import SummaryChart from '../Components/SummaryChart';
import '../Styles/Home.css';

function Home() {
    return (
        <div className="home">
            <h1 className="home-header">Home</h1>
            <div className="container chart-container">
                <SummaryChart />
            </div>
        </div>
    )
}

export default Home;