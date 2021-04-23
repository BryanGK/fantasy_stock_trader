import React from 'react'
import { Card, ListGroup } from 'react-bootstrap';
import NewsHeadline from '../Components/NewsHeadline';
import '../Styles/CompanyCard.css';

function CompanyCard({ companyInfo, companyLogo, companyNews }) {
    if (!companyInfo)
        return null;

    return (
        <div>
            <Card>
                <Card.Header className="company-info">Company Information</Card.Header>
                <Card.Body>
                    <Card.Title className="company-title"><Card.Img className="company-logo" src={companyLogo.url} />{companyInfo.companyName} | {companyInfo.symbol}</Card.Title>
                    <Card.Text>{companyInfo.description}</Card.Text>
                    <Card.Text><b>CEO:</b> {companyInfo.ceo}</Card.Text>
                    <Card.Text><b>Exchange:</b> {companyInfo.exchange}</Card.Text>
                    <Card.Text><b>Industry:</b> {companyInfo.industry}</Card.Text>
                    <Card.Text><a href={companyInfo.website} target="_blank" rel="noopener noreferrer">{companyInfo.companyName} Website</a></Card.Text>
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