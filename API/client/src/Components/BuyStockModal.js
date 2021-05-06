import React from 'react';
import { Modal, Button, Form, Row, Col } from 'react-bootstrap';
import '../Styles/BuyStockModal.css';

function BuyStockModal({ handleModalClose, stockQuote }) {
    if (!stockQuote)
        return null;

    return (
        <div>
            <Form className="buy-stock-form">
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        Buy {stockQuote.companyName} Stock
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form.Group as={Row}>
                        <Form.Label
                            htmlFor="current-price"
                            column sm={4}
                        >
                            Current Price:
                        </Form.Label>
                        <Col sm={3} className="current-price">
                            <Form.Control
                                id="current-price"
                                placeholder={`$${stockQuote.latestPrice}`}
                                disabled
                            >
                            </Form.Control>
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label
                            htmlFor="quantity"
                            column sm={4}
                        >
                            How Many:
                        </Form.Label>
                        <Col sm={3} className="quantity">
                            <Form.Control
                                id="quantity"
                                placeholder="0"
                            >
                            </Form.Control>
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label
                            htmlFor="total-price"
                            column sm={4}
                        >
                            Total Price:
                        </Form.Label>
                        <Col sm={3} className="total-price">
                            <Form.Control
                                id="total-price"
                                placeholder={`${stockQuote.latestPrice}`}
                                disabled
                            >
                            </Form.Control>
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label
                            htmlFor="funds"
                            column sm={4}
                        >
                            Available Funds:
                        </Form.Label>
                        <Col sm={3} className="funds">
                            <Form.Control
                                id="funds"
                                placeholder="0"
                            >
                            </Form.Control>
                        </Col>
                    </Form.Group>
                </Modal.Body>
                <Modal.Footer>
                    <Button
                        variant="primary"
                    >
                        Buy Stock
                        </Button>
                    <Button
                        variant="secondary"
                        onClick={handleModalClose}
                    >
                        Close
                        </Button>
                </Modal.Footer>
            </Form>
        </div>
    )
}

export default BuyStockModal;