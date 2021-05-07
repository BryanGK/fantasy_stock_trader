import React from 'react';
import { Table } from 'react-bootstrap';
import '../Styles/UserWallet.css';

function UserWallet({ wallet }) {
    return (
        <div>
            <Table bordered>
                <tbody>
                    <tr>
                        <td>Current Holdings</td>
                        <td>${wallet.holdings}</td>
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