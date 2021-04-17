import React from 'react';
import { Link } from 'react-router-dom';

function NavBar() {
    return (
        <div>
            <ul className="nav justify-content-end">
                <li className="nav-item">
                    <Link to="/home" className="nav-link">Home</Link>
                </li>
                <li className="nav-item">
                    <Link to="/report" className="nav-link">Report</Link>
                </li>
                <li className="nav-item">
                    <Link to="/" className="nav-link">Login</Link>
                </li>
            </ul>
        </div>
    )
}

export default NavBar