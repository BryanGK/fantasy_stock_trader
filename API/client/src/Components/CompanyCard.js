import React from 'react'
import { Card } from 'react-bootstrap';
import '../Styles/CompanyCard.css';

function CompanyCard({ companyData, companyLogo }) {
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
            </Card>
        </div>
    )
}

export default CompanyCard