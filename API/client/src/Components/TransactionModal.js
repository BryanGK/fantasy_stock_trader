import React from 'react';
import { Modal, Button, Form, Row, Col } from 'react-bootstrap';
import '../Styles/TransactionModal.css';

function TransactionModal({ handleModalClose, stockQuote, handleQuantity, holdings, transaction, quantity, wallet, buy }) {

    const formatter = new Intl.NumberFormat('en-us', {
        style: 'currency',
        currency: 'USD',
    })

    const maxQuantity = () => {
        for (let i = 0; i < holdings.length; i++) {
            if (holdings[i].stock === stockQuote.symbol) {
                return holdings[i].quantity;
            }
        }
    }

    if (!stockQuote)
        return null;

    return (
        <div>
            <Form className="buy-stock-form">
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        {stockQuote.companyName}
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
                        <Col sm={4} className="current-price">
                            <Form.Control
                                id="current-price"
                                placeholder={`${formatter.format(stockQuote.latestPrice)}`}
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
                            How Many: {quantity}
                        </Form.Label>
                        {buy ?
                            <Col sm={4} className="quantity">
                                <Form.Control
                                    onChange={handleQuantity}
                                    id="quantity"
                                    type="range"
                                    max={Math.floor(wallet.cash / stockQuote.latestPrice)}
                                >
                                </Form.Control>
                            </Col>
                            :
                            <Col sm={4} className="quantity">
                                <Form.Control
                                    onChange={handleQuantity}
                                    id="quantity"
                                    placeholder="0"
                                    type="range"
                                    max={maxQuantity()}
                                >
                                </Form.Control>
                            </Col>
                        }
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Form.Label
                            htmlFor="total-price"
                            column sm={4}
                        >
                            Total Price:
                        </Form.Label>
                        <Col sm={4} className="total-price">
                            <Form.Control
                                id="total-price"
                                placeholder={`${formatter.format(stockQuote.latestPrice * quantity)}`}
                                disabled
                            >
                            </Form.Control>
                        </Col>
                    </Form.Group>
                    {buy ?
                        <Form.Group as={Row}>
                            <Form.Label
                                htmlFor="funds"
                                column sm={4}
                            >
                                Funds:
                        </Form.Label>
                            <Col sm={4} className="funds">
                                <Form.Control
                                    id="funds"
                                    placeholder={`${formatter.format(wallet.cash - stockQuote.latestPrice * quantity)}`}
                                >
                                </Form.Control>
                            </Col>
                        </Form.Group>
                        :
                        <Form.Group as={Row}>
                            <Form.Label
                                htmlFor="funds"
                                column sm={4}
                            >
                                Cash:
                        </Form.Label>
                            <Col sm={4} className="funds">
                                <Form.Control
                                    id="funds"
                                    placeholder={`${formatter.format(wallet.cash + stockQuote.latestPrice * quantity)}`}
                                >
                                </Form.Control>
                            </Col>
                        </Form.Group>
                    }

                </Modal.Body>
                <Modal.Footer>
                    {buy ?
                        <Button
                            variant="primary"
                            onClick={() => {
                                transaction();
                                handleModalClose();
                            }}
                        >
                            Buy Stock
                        </Button>
                        :
                        <Button
                            variant="danger"
                            onClick={() => {
                                transaction();
                                handleModalClose();
                            }}
                        >
                            Sell Stock
                        </Button>
                    }
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

export default TransactionModal;