import React from 'react';
import { Modal, Button, Form } from 'react-bootstrap';

function BuyStockModal({ handleModalClose, stockQuote }) {
    if (!stockQuote)
        return null;

    return (
        <div>
            <Form>
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        Buy Stock
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <h4>Buy {stockQuote.companyName} Stock</h4>
                    <p>Filler text</p>
                </Modal.Body>
                <Modal.Footer>
                    <Button onClick={handleModalClose}>Close</Button>
                </Modal.Footer>
            </Form>
        </div>
    )
}

export default BuyStockModal;