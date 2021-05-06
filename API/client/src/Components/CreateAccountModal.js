import React from 'react';
import { Modal, Button, Form, Col, Row } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

function CreateAccountModal({ handleModalClose, handleUsername, handlePassword, handleEmail, postCreateAccount }) {
    return (
        <div>
            <Form>
                <Modal.Header closeButton>
                    <Modal.Title>Create New Account</Modal.Title>
                </Modal.Header>
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
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleModalClose}>
                        Close
                </Button>
                    <LinkContainer to="/home">
                        <Button
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