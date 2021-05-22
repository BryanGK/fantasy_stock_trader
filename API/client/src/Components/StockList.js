import React from 'react';
import { Table, Button } from 'react-bootstrap';

function StockList({ holdings }) {

    const tableRows = () => {
        if (!holdings)
            return null;
        console.log(holdings)
        return holdings.map(stock => {
            return (
                <tr>
                    <td>{stock.stock}</td>
                    <td>${stock.totalPrice}</td>
                    <td>{stock.quantity}</td>
                    <td><Button variant="success">Sell</Button></td>
                </tr>
            )
        })
    }

    return (
        <div>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Stock</th>
                        <th>Value</th>
                        <th>Quantity</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {tableRows()}
                </tbody>
            </Table>
        </div>
    )
}

export default StockList