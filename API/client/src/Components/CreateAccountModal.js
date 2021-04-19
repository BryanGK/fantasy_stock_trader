import React from 'react';
import { Modal, Button, Form, Col, Row } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

function CreateAccountModal({ handleModalClose }) {
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
                            <Form.Control type="text" placeholder="Select a username" />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row} controlid="formEmail">
                        <Form.Label column sm={2}>
                            Email
                        </Form.Label>
                        <Col sm={10}>
                            <Form.Control type="email" placeholder="Email" />
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row} controlid="formPassword">
                        <Form.Label column sm={2}>
                            Password
                        </Form.Label>
                        <Col sm={10}>
                            <Form.Control type="password" placeholder="Password" />
                        </Col>
                    </Form.Group>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleModalClose}>
                        Close
                </Button>
                    <LinkContainer to="/home">
                        <Button variant="primary" onClick={handleModalClose}>
                            Create Account
                    </Button>
                    </LinkContainer>
                </Modal.Footer>
            </Form>
        </div>
    )
}

export default CreateAccountModal;