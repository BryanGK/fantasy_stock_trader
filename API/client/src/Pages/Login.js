import React, { useState } from 'react';
import { Link, useHistory, Redirect, withRouter } from 'react-router-dom';
import { Form, Button, Card, Modal } from 'react-bootstrap';
import CreateAccountModal from '../Components/CreateAccountModal';
import { useLogin, useLoginUpdate } from '../Context/AuthContext';
import '../Styles/Login.css';
import axios from 'axios';



function Login() {
    const isAuth = useLogin();
    const history = useHistory();
    const userLogin = useLoginUpdate();

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [displayModal, setDisplayModal] = useState(false);

    const handleModalShow = () => setDisplayModal(true);

    const handleModalClose = () => setDisplayModal(false);

    const handleUsername = e => setUsername(e.target.value)

    const handlePassword = e => setPassword(e.target.value)

    const postLogin = () => {
        axios.post('/api/auth', {
            username: username,
            password: password
        })
            .then(response => {
                checkReturnData(response.data)
            })
            .catch(err => {
                console.log(err);
            })
    }

    const checkReturnData = (data) => {
        if (data.username !== null) {
            localStorage.setItem('userData', JSON.stringify(data));
            userLogin(true);
            history.push("/home");
        }
    }

    if (isAuth) {
        return <Redirect to="/home" />
    }

    return (
        <div>
            <h1 className="login-header">Login</h1>
            <div className="container login-form-container">
                <Card className="login-form-card">
                    <Card.Body>
                        <Form className="login-form">
                            <Form.Group controlId="formBasicEmail">
                                <Form.Label>Username</Form.Label>
                                <Form.Control
                                    onChange={handleUsername}
                                    value={username}
                                    type="text"
                                    placeholder="Enter Username" />
                            </Form.Group>
                            <Form.Group controlId="formBasicPassword">
                                <Form.Label>Password</Form.Label>
                                <Form.Control
                                    onChange={handlePassword}
                                    value={password}
                                    type="password"
                                    placeholder="Password" />
                            </Form.Group>
                            <Link to="/home">
                                <Button
                                    onClick={postLogin}
                                    variant="primary"
                                    type="submit">
                                    Login
                                </Button>
                            </Link>
                            <Button
                                variant="secondary"
                                type="button"
                                onClick={handleModalShow}>
                                Sign Up
                                </Button>
                        </Form>
                    </Card.Body>
                </Card>
                <Modal
                    show={displayModal}
                    onHide={handleModalClose}
                    centered>
                    <CreateAccountModal
                        handleModalClose={handleModalClose} />
                </Modal>
            </div>
        </div>
    )
}

export default withRouter(Login);