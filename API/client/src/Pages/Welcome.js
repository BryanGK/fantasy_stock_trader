import React from 'react';
import { Link } from 'react-router-dom';
import { Button } from 'react-bootstrap';

function Welcome() {
    return (
        <div>
            <h1>Welcome</h1>
            <Link to="/login">
                <Button variant="primary">
                    Start Trading
                </Button>
            </Link>
        </div>
    )
}

export default Welcome;