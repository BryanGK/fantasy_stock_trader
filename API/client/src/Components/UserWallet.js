import React from 'react';
import { Table } from 'react-bootstrap';
import '../Styles/UserWallet.css';

function UserWallet({ wallet }) {

    const formatter = new Intl.NumberFormat('en-us', {
        style: 'currency',
        currency: 'USD',
    })

    if (!wallet)
        return null;

    return (
        <div>
            <Table bordered>
                <tbody>
                    <tr>
                        <td>Current Holdings</td>
                        <td>{formatter.format(wallet.value)}</td>
                    </tr>
                    <tr>
                        <td>Current Wallet</td>
                        <td>{formatter.format(wallet.cash)}</td>
                    </tr>
                </tbody>
            </Table>
        </div>
    )
}

export default UserWallet;