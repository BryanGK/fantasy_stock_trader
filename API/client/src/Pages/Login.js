import React, { useState } from 'react';
import { Link, useHistory, Redirect } from 'react-router-dom';
import { Form, Button, Card, Modal, Alert } from 'react-bootstrap';
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
    const [displayModalError, setDisplayModalError] = useState(false);
    const [error, setError] = useState({
        diplay: false,
        message: '',
        usernameLength: false,
        passwordLength: false,
        inputLength: false,
    })

    const handleModalShow = () => setDisplayModal(true);

    const handleModalClose = () => setDisplayModal(false);

    const handleUsername = e => setUsername(e.target.value);

    const handlePassword = e => setPassword(e.target.value)


    const checkInputLength = () => {
        if (username.length < 4) {
            setError({ usernameLength: true });
            return false;
        }
        if (password.length < 8) {
            setError({ passwordLength: true });
            return false;
        }
        return true;
    }

    const postLogin = (e) => {
        e.preventDefault();
        if (!checkInputLength())
            return;
        axios.post('/api/login', {
            username: username,
            password: password
        })
            .then(response => {
                checkReturnData(response.data);
            })
            .catch(err => {
                setError({
                    message: err.response.data,
                    display: true
                });
                console.log(err.response.data);
            })
    }

    const postCreateAccount = (e) => {
        e.preventDefault();
        if (!checkInputLength())
            return;
        axios.post('api/createuser', {
            username: username,
            password: password
        })
            .then(response => {
                checkReturnData(response.data);
            })
            .catch(err => {
                setError({ message: err.response.data });
                setDisplayModalError(true);
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
            {error.display ?
                <div className="login-alerts">
                    <Alert variant="danger" onClose={() => setError({ display: false })} dismissible>
                        <p>{error.message}</p>
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
                            {error.usernameLength ?
                                <p className="username-error">Username must be at least 4 characters long</p>
                                : null}
                            <Form.Group controlId="formBasicPassword">
                                <Form.Label>Password</Form.Label>
                                <Form.Control
                                    onChange={handlePassword}
                                    value={password}
                                    type="password"
                                    placeholder="Password" />
                            </Form.Group>
                            {error.passwordLength ?
                                <p className="password-error">Password must be at least 8 characters long</p>
                                : null}
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
                        setDisplayModalError={setDisplayModalError}
                        postCreateAccount={postCreateAccount}
                        handleUsername={handleUsername}
                        handlePassword={handlePassword}
                        handleModalClose={handleModalClose}
                        displayModalError={displayModalError}
                        errorMessage={error.message}
                        passwordError={error.passwordLength}
                        usernameError={error.usernameLength}
                    />
                </Modal>
            </div>
        </div>
    )
}

export default Login;