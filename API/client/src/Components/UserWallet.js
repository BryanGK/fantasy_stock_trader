import React from 'react';
import { Table } from 'react-bootstrap';
import '../Styles/UserWallet.css';

function UserWallet({ wallet }) {
    if (!wallet)
        return null;

    return (
        <div>
            <Table bordered>
                <tbody>
                    <tr>
                        <td>Current Holdings</td>
                        <td>${wallet.value}</td>
                    </tr>
                    <tr>
                        <td>Current Wallet</td>
                        <td>${wallet.cash}</td>
                    </tr>
                </tbody>
            </Table>
        </div>
    )
}

export default UserWallet;