import React from 'react';
import { Modal, Button, Form, Col, Row, Alert } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

function CreateAccountModal({ handleModalClose, handleUsername, handlePassword, postCreateAccount, error, setError }) {
    return (
        <div>
            <Form>
                <Modal.Header closeButton>
                    <Modal.Title>Create New Account</Modal.Title>
                </Modal.Header>
                {error.displayModalError ?
                    <div className="login-alerts">
                        <Alert variant="danger" onClose={() => setError({ displayModalError: false })} dismissible>
                            <p>{error.message}</p>
                        </Alert>
                    </div>
                    : null}
                <Modal.Body>
                    <Form.Group as={Row} controlid="formUsername">
                        <Form.Label column sm={2}>
                            Username
                        </Form.Label>
                        <Col sm={10}>
                            <Form.Control
                                onChange={handleUsername}
                                type="text"
                                placeholder="Select a username" />
                        </Col>
                    </Form.Group>
                    {error.usernameLengthError ?
                        <p className="username-error">Username must be at least 4 characters long</p>
                        : null}
                    <Form.Group as={Row} controlid="formPassword">
                        <Form.Label column sm={2}>
                            Password
                        </Form.Label>
                        <Col sm={10}>
                            <Form.Control
                                onChange={handlePassword}
                                type="password"
                                placeholder="Password" />
                        </Col>
                    </Form.Group>
                    {error.passwordLengthError ?
                        <p className="password-error">Password must be at least 8 characters long</p>
                        : null}
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleModalClose}>
                        Close
                    </Button>
                    <LinkContainer to="/home">
                        <Button
                            type="submit"
                            variant="primary"
                            onClick={postCreateAccount}>
                            Create Account
                        </Button>
                    </LinkContainer>
                </Modal.Footer>
            </Form>
        </div>
    )
}

export default CreateAccountModal;