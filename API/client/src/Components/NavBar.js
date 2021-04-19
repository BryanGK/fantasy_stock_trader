import React from 'react';
import { Navbar, Nav } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import '../Styles/Navbar.css';

function NavBar() {
    return (
        <div>
            <Navbar className="navbar-link" bg="primary" variant="dark">
                <LinkContainer to="/">
                    <Navbar.Brand href="#home">Fantasy Stock Trader</Navbar.Brand>
                </LinkContainer>
                <Nav>
                    <Nav.Item>
                        <LinkContainer to="/home">
                            <Nav.Link>Home</Nav.Link>
                        </LinkContainer>
                    </Nav.Item>
                    <Nav.Item>
                        <LinkContainer to="/report">
                            <Nav.Link>Report</Nav.Link>
                        </LinkContainer>
                    </Nav.Item>
                </Nav>
            </Navbar>
        </div>
    )
}

export default NavBar