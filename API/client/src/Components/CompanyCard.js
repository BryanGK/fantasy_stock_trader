import React from 'react'
import { Card, ListGroup } from 'react-bootstrap';
import NewsHeadline from '../Components/NewsHeadline';
import '../Styles/CompanyCard.css';

function CompanyCard({ companyData, companyLogo, companyNews }) {
    if (!companyData)
        return null;

    return (
        <div>
            <Card>
                <Card.Header className="company-info">Company Information</Card.Header>
                <Card.Body>
                    <Card.Title className="company-title"><Card.Img className="company-logo" src={companyLogo.url} />{companyData.companyName} | {companyData.symbol}</Card.Title>
                    <Card.Text>{companyData.description}</Card.Text>
                </Card.Body>
                <Card.Header className="latest-news">Latest News</Card.Header>
                <ListGroup className="list-group-flush">
                    <NewsHeadline
                        companyNews={companyNews}
                    />
                </ListGroup>
            </Card>
        </div>
    )
}

export default CompanyCard