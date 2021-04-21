import React, { useState } from 'react';
import SummaryChart from '../Components/SummaryChart';
import { Button, FormControl, InputGroup } from 'react-bootstrap';
import axios from 'axios';
import '../Styles/Home.css';
import CompanyCard from '../Components/CompanyCard';

function Home() {
    const [search, setSearch] = useState('');
    const [companyData, setCompanyData] = useState();
    const [companyLogo, setCompanyLogo] = useState('');
    const [companyNews, setComanyNews] = useState([]);
    const [stockQuote, setStockQuote] = useState();

    const handleChange = e => setSearch(e.target.value);

    const handleSearch = e => {
        getCompanyData(search);
    }

    const getCompanyData = async () => {
        axios.get(`/api/stocks/news/${search}`)
            .then(response => {
                console.log(response.data);
                setComanyNews(response.data);
            })
            .catch(error => {
                console.log(error);
            })
        axios.get(`api/stocks/logo/${search}`)
            .then(response => {
                console.log(response.data);
                setCompanyLogo(response.data);
            })
            .catch(error => {
                console.log(error);
            })
        axios.get(`api/stocks/company/${search}`)
            .then(response => {
                console.log(response.data);
                setCompanyData(response.data);
            })
            .catch(error => {
                console.log(error);
            })
    }

    return (
        <div className="home">
            <h1 className="home-header">Home</h1>
            <div className="container chart-container">
                <SummaryChart />
            </div>
            <div className="stock-search-container">
                <div className="row search-stock">
                    <InputGroup>
                        <FormControl
                            type="text"
                            placeholder="Search Stocks"
                            value={search}
                            onChange={handleChange}
                            onKeyPress={e => {
                                if (e.key === "Enter") {
                                    handleSearch();
                                }
                            }}
                        />
                        <InputGroup.Append>
                            <Button
                                type="submit"
                                onClick={handleSearch}>
                                Search
                    </Button>
                        </InputGroup.Append>
                    </InputGroup>
                </div>
            </div>
            <div className="container company-card-container">
                <CompanyCard
                    companyData={companyData}
                    companyLogo={companyLogo}
                    companyNews={companyNews}
                />
            </div>
        </div>
    )
}

export default Home;