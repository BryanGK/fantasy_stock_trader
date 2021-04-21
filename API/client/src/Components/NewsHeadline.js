import React from 'react';
import { Card, ListGroupItem } from 'react-bootstrap';
import '../Styles/NewsHeadline.css';

function NewsHeadline({ companyNews }) {

    return companyNews.map(item => {
        return (
            <div key={Math.random()} className="company-news">
                <ListGroupItem>
                    <Card.Title>{item.headline}</Card.Title>
                    <Card.Text>{item.summary}</Card.Text>
                    <Card.Link href={item.url} target="_blank" rel="noopener noreferrer">Read Full Article</Card.Link>
                </ListGroupItem>
            </div>
        )
    })
}

export default NewsHeadline;