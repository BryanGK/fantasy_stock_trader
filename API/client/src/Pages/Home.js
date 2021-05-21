import React, { useEffect, useState } from 'react';
import SummaryChart from '../Components/SummaryChart';
import CompanyStockQuote from '../Components/CompanyStockQuote';
import CompanyCard from '../Components/CompanyCard';
import UserWallet from '../Components/UserWallet';
import { Button, FormControl, InputGroup, Modal } from 'react-bootstrap';
import { withRouter } from 'react-router-dom';
import axios from 'axios';
import '../Styles/Home.css';
import BuyStockModal from '../Components/BuyStockModal';
import { useCurrentUser } from '../Context/AuthContext';

function Home() {

    const currentUser = useCurrentUser();
    const [displayModal, setDisplayModal] = useState(false);
    const [company, setCompany] = useState('');
    const [companyInfo, setCompanyInfo] = useState();
    const [companyLogo, setCompanyLogo] = useState('');
    const [companyNews, setCompanyNews] = useState([]);
    const [stockQuote, setStockQuote] = useState();
    const [displayCompanyInfo, setDisplayCompanyInfo] = useState(false);
    const [quantity, setQuantity] = useState();

    const [wallet, setWallet] = useState(
        {
        holdings: 0,
        cash: 100000
        }
    );

    const [stockHoldings, setStockHoldings] = useState([
        ['Stock', 'Value'],
        ['APPL', 200],
        ['V', 120],
        ['TSLA', 800],
        ['FB', 390],
        ['NFLX', 576],
        ['GME', 327],
        ['GOOG', 20],
    ]);

    const buyStock = () => {
        axios.post('/api/trans/buy', {
            userId: currentUser.userId,
            stock: stockQuote.symbol,
            price: stockQuote.latestPrice,
            quantity: quantity,
        })
            .then(response => {
                setWallet(response.data);
            })
            .catch(error => {
                console.log(error);
            })

    }

    // useEffect(() => {
    //     setStockHoldings(() => {

    //     })
    //     setWallet(() => {

    //     })
    // }, [])



    const handleChange = e => setCompany(e.target.value);

    const handleModalShow = () => setDisplayModal(true);

    const handleModalClose = () => setDisplayModal(false);

    const handleQuantity = e => setQuantity(e.target.value);

    const handleSearch = () => {
        setInitialState();
        getCompanyQuote(company);
    }

    const setInitialState = () => {
        setCompanyNews([]);
        setCompanyInfo();
        setDisplayCompanyInfo(false);
    }

    const toggleCompanyInfo = () => {
        setDisplayCompanyInfo(prevState => !prevState);
        if (!companyInfo) {
            getCompanyInfo();
        }
    }

    const getHoldings = () => {
        axios.get(`api/holdings/${currentUser.userId}`)
            .then(response => {
                console.log(response.data);
            })
            .catch(error => {
                console.log(error);
            })
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

    const getCompanyQuote = async () => {
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
                <div className="row wallet-info">
                    <SummaryChart
                        stockHoldings={stockHoldings}
                    />
                    <UserWallet
                        wallet={wallet}

                    />
                </div>
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
                    handleModalShow={handleModalShow}
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
            <div className="constainer buy-stock-modal">
                <Modal
                    show={displayModal}
                    onHide={handleModalClose}
                    centered>
                    <BuyStockModal
                        handleModalClose={handleModalClose}
                        handleQuantity={handleQuantity}
                        stockQuote={stockQuote}
                        buyStock={buyStock}
                    />
                </Modal>
            </div>
        </div>
    )
}

export default withRouter(Home);