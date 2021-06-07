import React, { useState } from 'react';
import { Link, useHistory, Redirect } from 'react-router-dom';
import { Form, Button, Card, Modal, Alert } from 'react-bootstrap';
import CreateAccountModal from '../Components/CreateAccountModal';
import { useLogin, useLoginUpdate, useUserUpdate } from '../Context/AuthContext';
import '../Styles/Login.css';
import axios from 'axios';

function Login() {
    const isAuth = useLogin();
    const history = useHistory();
    const userLogin = useLoginUpdate();
    const currentUser = useUserUpdate();

    const [displayError, setDisplayError] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [displayModal, setDisplayModal] = useState(false);

    const handleModalShow = () => setDisplayModal(true);

    const handleModalClose = () => setDisplayModal(false);

    const handleUsername = e => setUsername(e.target.value)

    const handlePassword = e => setPassword(e.target.value)

    const postLogin = (e) => {
        e.preventDefault();
        axios.post('/api/login', {
            username: username,
            password: password
        })
            .then(response => {
                checkReturnData(response.data);
            })
            .catch(err => {
                setErrorMessage(err.response.data);
                setDisplayError(true);
                console.log(err.response.data);
            })
    }

    const postCreateAccount = () => {
        axios.post('api/createuser', {
            username: username,
            password: password
        })
            .then(response => {
                checkReturnData(response.data);
            })
            .catch(err => {
                alert(err.response.data);
                console.log(err.response);
            })
    }

    const checkReturnData = (data) => {
        if (data.username !== null) {
            localStorage.setItem('userData', JSON.stringify(data));
            userLogin(true);
            history.push("/home");
        }
        return;
    }

    if (isAuth) {
        return <Redirect to="/home" />
    }

    return (
        <div>
            {displayError ?
                <div className="login-alerts">
                    <Alert variant="danger" onClose={() => setDisplayError(false)} dismissible>
                        <p>{errorMessage}</p>
                    </Alert>
                </div>
                : null}
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
                        postCreateAccount={postCreateAccount}
                        handleUsername={handleUsername}
                        handlePassword={handlePassword}
                        handleModalClose={handleModalClose} />
                </Modal>
            </div>
        </div>
    )
}

export default Login;