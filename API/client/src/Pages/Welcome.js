import React from 'react';
import { Link } from 'react-router-dom';
import { Button } from 'react-bootstrap';
import '../Styles/Welcome.css';

function Welcome() {
    return (
        <div>
            <h1 className="welcome-header">Welcome to Fantasy Stock Trader</h1>
            <Link to="/login">
                <Button variant="primary">
                    Start Trading
                </Button>
            </Link>
        </div>
    )
}

export default Welcome;