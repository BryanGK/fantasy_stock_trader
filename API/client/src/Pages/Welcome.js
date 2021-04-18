import React from 'react';
import { Link } from 'react-router-dom';

function Welcome() {
    return (
        <div>
            <h1>Welcome</h1>
            <Link to="/login">
                <button type="button" className="btn btn-primary">
                    Start Trading
                </button>
            </Link>
        </div>
    )
}

export default Welcome;