import React from 'react';
import { Navbar, Nav } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import { useHistory } from 'react-router-dom';
import '../Styles/Navbar.css';

function NavBar() {
    const history = useHistory();

    return (
        <div>
            <Navbar className="navbar-link" bg="primary" variant="dark">
                <LinkContainer to="/">
                    <Navbar.Brand href="#home">Fantasy Stock Trader</Navbar.Brand>
                </LinkContainer>
                <Nav>
                    <Nav.Item>
                        <Nav.Link
                            onClick={() => history.push("/home")}>
                            Home
                                </Nav.Link>
                    </Nav.Item>
                    <Nav.Item>
                        <Nav.Link
                            onClick={() => history.push("/report")}>
                            Report
                                </Nav.Link>
                    </Nav.Item>
                </Nav>
            </Navbar>
        </div>
    )
}

export default NavBar