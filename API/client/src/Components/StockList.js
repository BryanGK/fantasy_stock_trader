import React from 'react';
import { Table, Button } from 'react-bootstrap';

function StockList({ holdings, sellModal }) {

    const formatter = new Intl.NumberFormat('en-us', {
        style: 'currency',
        currency: 'USD',
    })

    const tableRows = () => {
        if (!holdings)
            return null;

        return holdings.map(holding => {
            if (holding.quantity <= 0)
                return null;
            return (
                <tr key={Math.random()}>
                    <td>{holding.stock}</td>
                    <td>{formatter.format(holding.totalPrice)}</td>
                    <td>{holding.quantity}</td>
                    <td>{formatter.format(holding.latestPrice)}</td>
                    <td><Button
                        variant="danger"
                        onClick={() => {
                            sellModal(holding.stock);
                        }}
                    >Sell</Button></td>
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
                        <th>Latest Price</th>
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