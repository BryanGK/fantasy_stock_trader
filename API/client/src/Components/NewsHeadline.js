import React from 'react';
import { ListGroupItem } from 'react-bootstrap';
import '../Styles/NewsHeadline.css';

function NewsHeadline({ companyNews }) {

    return companyNews.map(item => {
        return (
            <div className="company-news">
                <ListGroupItem key={Math.random()}>{item.headline}</ListGroupItem>
            </div>
        )
    })
}

export default NewsHeadline;