import React from 'react';
import { Link } from 'react-router-dom';
import { Form, Button, Card } from 'react-bootstrap';

import '../Styles/Login.css';

function Login() {
    return (
        <div>
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
                            <Link to="/home">
                                <Button variant="secondary" type="submit">
                                    Sign Up
                                </Button>
                            </Link>
                        </Form>
                    </Card.Body>
                </Card>
            </div>
        </div>
    )
}

export default Login;