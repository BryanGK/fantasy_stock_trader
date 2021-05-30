import React from 'react';
import { Table } from 'react-bootstrap';
import '../Styles/Report.css';

function Report() {
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

                    </tbody>
                </Table>
            </div>
        </div>
    )
}

export default Report;