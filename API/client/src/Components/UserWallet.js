import React from 'react';
import { Table } from 'react-bootstrap';
import '../Styles/UserWallet.css';

function UserWallet({ wallet }) {

    const formatValues = value => {
        return parseFloat(value).toFixed(2);
    }

    if (!wallet)
        return null;

    return (
        <div>
            <Table bordered>
                <tbody>
                    <tr>
                        <td>Current Holdings</td>
                        <td>${formatValues(wallet.value)}</td>
                    </tr>
                    <tr>
                        <td>Current Wallet</td>
                        <td>${formatValues(wallet.cash)}</td>
                    </tr>
                </tbody>
            </Table>
        </div>
    )
}

export default UserWallet;