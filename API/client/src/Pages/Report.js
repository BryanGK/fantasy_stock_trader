import React, { useEffect, useState } from 'react';
import { Table } from 'react-bootstrap';
import axios from 'axios';
import '../Styles/Report.css';

function Report() {
    const [transactions, setTransactions] = useState();

    useEffect(() => {
        getTransactions();
    }, []);

    const getTransactions = () => {
        const user = JSON.parse(localStorage.getItem('userData'));
        axios.get('api/holdings/get/transactions', {
            headers: {
                userId: user.userId
            }
        })
            .then(response => {
                setTransactions(response.data);
            })
            .catch(error => {
                console.log(error);
            });
    }

    const displayTransactions = () => {
        if (!transactions)
            return null;
        return transactions.map(item => {
            return (
                <tr key={Math.random()}>
                    <td>{item.stock}</td>
                    <td>{item.price}</td>
                    <td>{item.quantity}</td>
                </tr>
            )
        })
    }

    return (
        <div>
            <h1 className="report-header">Report</h1>
            <div className="container transaction-list">
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>Company</th>
                            <th>Price</th>
                            <th>Quantity</th>
                        </tr>
                    </thead>
                    <tbody>
                        {displayTransactions()}
                    </tbody>
                </Table>
            </div>
        </div>
    )
}

export default Report;