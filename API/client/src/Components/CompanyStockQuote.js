import React from 'react';
import { Card, Button } from 'react-bootstrap';
import '../Styles/CompanyStockQuote.css';

function CompanyStockQuote({ stockQuote, companyLogo, toggleCompanyInfo, handleModalShow }) {
    if (!stockQuote)
        return null;

    return (
        <div>
            <Card className="stock-report">
                <Card.Header>Stock Report</Card.Header>
                <Card.Body>
                    <Card.Title><img className="quote-logo" src={companyLogo.url} alt="logo" />{stockQuote.companyName}</Card.Title>
                    <Card.Subtitle className="mb-2 text-muted">{stockQuote.symbol} | {stockQuote.primaryExchange}</Card.Subtitle>
                    <Card.Text><b>Latest Price:</b> {stockQuote.latestPrice} {stockQuote.change} {stockQuote.changePercent}</Card.Text>
                    <Card.Text><b>Previous Close:</b> {stockQuote.previousClose}</Card.Text>
                    <Card.Text><b>52 Week High:</b> {stockQuote.week52High} <b>52 Week Low:</b> {stockQuote.week52Low}</Card.Text>
                    <div className="button-container">
                        <Button
                            variant="primary"
                            onClick={handleModalShow}>
                            Buy Stock
                            </Button>
                        <Button
                            variant="secondary"
                            onClick={toggleCompanyInfo}>
                            Company Info</Button>

                    </div>
                </Card.Body>
            </Card>
        </div>
    )
}

export default CompanyStockQuote