import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Form, Button, Card, Modal } from 'react-bootstrap';
import CreateAccountModal from '../Components/CreateAccountModal'
import '../Styles/Login.css';

function Login() {

    const [displayModal, setDisplayModal] = useState(false);

    const handleModalShow = () => setDisplayModal(true);
    const handleModalClose = () => setDisplayModal(false);

    return (
        <div>
            <h1 className="login-header">Login</h1>
            <div className="container login-form-container">
                <Card className="login-form-card">
                    <Card.Body>
                        <Form className="login-form">
                            <Form.Group controlId="formBasicEmail">
                                <Form.Label>Email address</Form.Label>
                                <Form.Control type="email" placeholder="Enter email" />
                            </Form.Group>
                            <Form.Group controlId="formBasicPassword">
                                <Form.Label>Password</Form.Label>
                                <Form.Control type="password" placeholder="Password" />
                            </Form.Group>
                            <Link to="/home">
                                <Button variant="primary" type="submit">
                                    Login
                                </Button>
                            </Link>
                            <Button
                                variant="secondary"
                                type="button"
                                onClick={handleModalShow}>
                                Sign Up
                                </Button>
                        </Form>
                    </Card.Body>
                </Card>
                <Modal
                    show={displayModal}
                    onHide={handleModalClose}
                    centered>
                    <CreateAccountModal
                        handleModalClose={handleModalClose} />
                </Modal>
            </div>
        </div>
    )
}

export default Login;