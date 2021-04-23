import React, { useState } from 'react';
import SummaryChart from '../Components/SummaryChart';
import CompanyStockQuote from '../Components/CompanyStockQuote';
import CompanyCard from '../Components/CompanyCard';
import { Button, FormControl, InputGroup } from 'react-bootstrap';
import axios from 'axios';
import '../Styles/Home.css';

function Home() {
    const [company, setCompany] = useState('');
    const [companyInfo, setCompanyInfo] = useState();
    const [companyLogo, setCompanyLogo] = useState('');
    const [companyNews, setCompanyNews] = useState([]);
    const [stockQuote, setStockQuote] = useState();
    const [displayCompanyInfo, setDisplayCompanyInfo] = useState(false);

    const handleChange = e => setCompany(e.target.value);

    const handleSearch = async () => {
        setInitialState();
        getCompanyData(company);
    }

    const toggleCompanyInfo = () => {
        setDisplayCompanyInfo(prevState => !prevState);
        if (!companyInfo) {
            getCompanyInfo();
        }
    }

    const getCompanyInfo = () => {
        axios.get(`/api/stocks/news/${company}`)
            .then(response => {
                console.log(response.data);
                setCompanyNews(response.data);
            })
            .catch(error => {
                console.log(error);
            });
        axios.get(`api/stocks/company/${company}`)
            .then(response => {
                console.log(response.data);
                setCompanyInfo(response.data);
            })
            .catch(error => {
                console.log(error);
            });
    }

    const setInitialState = () => {
        setCompanyNews([]);
        setCompanyInfo();
        setDisplayCompanyInfo(false);
    }

    const getCompanyData = async () => {
        axios.get(`/api/stocks/quote/${company}`)
            .then(response => {
                console.log(response.data);
                setStockQuote(response.data);
            })
            .catch(error => {
                console.log(error);
            });
        axios.get(`api/stocks/logo/${company}`)
            .then(response => {
                console.log(response.data);
                setCompanyLogo(response.data);
            })
            .catch(error => {
                console.log(error);
            });
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
            <div className="container company-stock-quote">
                <CompanyStockQuote
                    stockQuote={stockQuote}
                    companyLogo={companyLogo}
                    toggleCompanyInfo={toggleCompanyInfo}
                />
            </div>
            <div className="container company-card-container">
                {displayCompanyInfo ?
                    <CompanyCard
                    companyInfo={companyInfo}
                    companyLogo={companyLogo}
                    companyNews={companyNews}
                    />
                    : null}
            </div>
        </div>
    )
}

export default Home;