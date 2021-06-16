import React, { useEffect, useState } from 'react';
import SummaryChart from '../Components/SummaryChart';
import CompanyStockQuote from '../Components/CompanyStockQuote';
import CompanyCard from '../Components/CompanyCard';
import UserWallet from '../Components/UserWallet';
import StockList from '../Components/StockList';
import { Button, Form, FormControl, InputGroup, Modal, Alert } from 'react-bootstrap';
import axios from 'axios';
import '../Styles/Home.css';
import TransactionModal from '../Components/TransactionModal';
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
    const [quantity, setQuantity] = useState(0);
    const [holdings, setHoldings] = useState();
    const [processedHoldings, setProcessedHoldings] = useState([]);
    const [wallet, setWallet] = useState();
    const [buy, setBuy] = useState(false);
    const [sell, setSell] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    const [displayError, setDisplayError] = useState(false);

    useEffect(() => {
        getHoldings();
    }, []);

    const getHoldings = () => {
        const user = JSON.parse(localStorage.getItem('userData'));
        axios.get(`api/holdings/get/holdings`, {
            headers: {
                userId: user.userId
            }
        })
            .then(response => {
                const processedHoldings = processHoldings(response.data.holdings);
                setProcessedHoldings(() => [['Stock', 'Value'], ...processedHoldings]);
                setHoldings(response.data.holdings)
                setWallet(
                    {
                        value: response.data.value,
                        cash: response.data.cash
                    })
            })
            .catch(error => {
                console.log(error);
            });
    }

    const processHoldings = (holdings) => {
        let temp = [];
        if (holdings == null)
            return temp;
        holdings.forEach(element => {
            temp.push([element.stock, element.totalPrice])
        })
        return temp;
    }


    const transaction = () => {
        let transactionType;
        if (buy)
            transactionType = 'buy';
        if (sell)
            transactionType = 'sell';

        axios.post(`/api/transaction/${transactionType}`, {
            userId: currentUser.userId,
            stock: stockQuote.symbol,
            price: stockQuote.latestPrice,
            quantity: quantity,
        })
            .then(response => {
                setWallet(response.data);
                getHoldings()
            })
            .catch(error => {
                console.log(error);
            })
    }

    const handleChange = e => setCompany(e.target.value);

    const handleModalShow = () => {
        setDisplayModal(true);
        setQuantity(0);
    }

    const sellModal = company => {
        setCompany(company);
        getCompanyQuote(company);
        handleModalShow();
    }

    const handleModalClose = () => setDisplayModal(false);

    const handleQuantity = e => setQuantity(e.target.value);

    const handleSearch = () => {
        setInitialState();
        setDisplayError(false);
        getCompanyQuote(company);
    }

    const setInitialState = () => {
        setStockQuote();
        setCompanyLogo('');
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

    const getCompanyInfo = () => {
        axios.get(`/api/stocks/news/${company}`)
            .then(response => {
                setCompanyNews(response.data);
            })
            .catch(error => {
                console.log(error);
            });
        axios.get(`api/stocks/company/${company}`)
            .then(response => {
                setCompanyInfo(response.data);
            })
            .catch(error => {
                console.log(error);
            });
    }

    const getCompanyQuote = company => {
        axios.get(`/api/stocks/quote/${company}`)
            .then(response => {
                setStockQuote(response.data);
            })
            .catch(error => {
                setErrorMessage(error.response.data);
                setDisplayError(true);
                console.log(error);
            });
        axios.get(`api/stocks/logo/${company}`)
            .then(response => {
                setCompanyLogo(response.data);
            })
            .catch(error => {
                console.log(error);
            });
    }

    return (
        <div className="home">
            <h1 className="home-header">Hello, {currentUser.username}</h1>
            <h3 className="home-header">Welcome to Fantasy Stock Trader</h3>
            <div className="container chart-container">
                <div className="row wallet-info">
                    <SummaryChart
                        processedHoldings={processedHoldings}
                    />
                    <UserWallet
                        wallet={wallet}
                    />
                </div>
            </div>

            <div className="container transactions">
                <div className="buy-sell col">
                    <Button
                        variant="info"
                        onClick={() => {
                            setBuy(prevState => !prevState)
                            setSell(false);
                            setStockQuote();
                            setCompanyInfo();
                            setCompanyLogo('');
                            setCompany('');
                        }}
                    >
                        Buy
                        </Button>
                    <Button
                        variant="info"
                        onClick={() => {
                            setSell(prevState => !prevState)
                            setBuy(false);
                        }}
                    >
                        Sell
                        </Button>
                </div>
                <div className="stock-list col-10">
                    {sell ?
                        <StockList
                            holdings={holdings}
                            sellModal={sellModal}
                        />
                        : null}
                </div>
                {buy ?
                    <div>
                        <div className="container search-bar">
                            <div className="search-stock col-6">
                                <InputGroup>
                                    <Form.Label>Search:</Form.Label>
                                    <FormControl
                                        type="text"
                                        placeholder="Stock Symbol"
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
                                {displayError ?
                                    <div className="search-alerts">
                                        <Alert variant="danger" onClose={() => setDisplayError(false)} dismissible>
                                            <p>{errorMessage}</p>
                                        </Alert>
                                    </div>
                                    : null}
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
                    </div>
                    : null}
            </div>
            <div className="constainer buy-stock-modal">
                <Modal
                    show={displayModal}
                    onHide={handleModalClose}
                    centered>
                    <TransactionModal
                        handleModalClose={handleModalClose}
                        handleQuantity={handleQuantity}
                        stockQuote={stockQuote}
                        quantity={quantity}
                        wallet={wallet}
                        holdings={holdings}
                        transaction={transaction}
                        buy={buy}
                    />
                </Modal>
            </div>
        </div>
    )
}

export default Home;