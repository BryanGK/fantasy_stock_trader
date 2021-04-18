import React from 'react';
import { Link } from 'react-router-dom';
import CreateAccountModal from '../Components/CreateAccountModal';
import '../Styles/Login.css';

function Login() {
    return (
        <div>
            <h1>Login</h1>
            <div className="container login-form-container">
                <div className="card">
                    <div className="card-body">
                        <div className="row login-form">
                            <form>
                                <input
                                    type="text"
                                    className="form-control"
                                    placeholder="Username">
                                </input>
                                <input
                                    type="password"
                                    className="form-control"
                                    placeholder="Password">
                                </input>
                                <Link to="/home"><button
                                    className="btn btn-primary"
                                    type="submit">
                                    Login
                                    </button></Link>
                                <button
                                    className="btn btn-secondary"
                                    type="button"
                                    data-target="#staticBackdrop"
                                    data-toggle="modal">

                                    Sign Up
                                    </button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>

            <div className="modal-dialog modal-dialog-centered">
                <div className="modal fade" id="staticBackdrop" tabIndex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                    <div className="modal-dialog">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title" id="staticBackdropLabel">Modal title</h5>
                                <button type="button" className="btn-close" data-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div className="modal-body">
                                This is the body of the modal.
                        </div>
                            <div className="modal-footer">
                                <button type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
                                <Link to="/home"><button type="button" className="btn btn-primary" data-dismiss="modal">Create Account</button></Link>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Login;