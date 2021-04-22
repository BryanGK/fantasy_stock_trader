import React, { useState } from 'react';
import SummaryChart from '../Components/SummaryChart';
import { Button, FormControl, InputGroup } from 'react-bootstrap';
import axios from 'axios';
import '../Styles/Home.css';
import CompanyCard from '../Components/CompanyCard';

function Home() {
    const [company, setCompany] = useState('');
    const [companyInfo, setCompanyInfo] = useState();
    const [companyLogo, setCompanyLogo] = useState('');
    const [companyNews, setCompanyNews] = useState([]);
    const [stockQuote, setStockQuote] = useState();

    const handleChange = e => setCompany(e.target.value);

    const handleSearch = async () => {
        getCompanyData(company);
    }

    const getCompanyData = async () => {
        axios.get(`/api/stocks/quote/${company}`)
            .then(response => {
                console.log(response.data);
                setStockQuote(response.data);
            })
        // axios.get(`/api/stocks/news/${company}`)
        //     .then(response => {
        //         console.log(response.data);
        //         setCompanyNews(response.data);
        //     })
        axios.get(`api/stocks/logo/${company}`)
            .then(response => {
                console.log(response.data);
                setCompanyLogo(response.data);
            })
        axios.get(`api/stocks/company/${company}`)
            .then(response => {
                console.log(response.data);
                setCompanyInfo(response.data);
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
                            value={company}
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
                    companyInfo={companyInfo}
                    companyLogo={companyLogo}
                    companyNews={companyNews}
                />
            </div>
        </div>
    )
}

export default Home;