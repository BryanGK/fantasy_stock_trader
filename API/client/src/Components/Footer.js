import React from 'react';
import { Navbar } from 'react-bootstrap';
import '../Styles/Footer.css';

function Footer() {
    return (
        <footer>
            <Navbar fixed="bottom">
                <Navbar.Brand>Footer</Navbar.Brand>
                <Navbar.Toggle />
                <Navbar.Collapse className="justify-content-end">
                    <Navbar.Text>
                        © Bryan Krauss 2021
                    </Navbar.Text>
                </Navbar.Collapse>
            </Navbar>
        </footer>
    )
}

export default Footer;