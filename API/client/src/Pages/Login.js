import React from 'react';
import { Link } from 'react-router-dom';
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
                                    type="submit">
                                    Sign Up
                                    </button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Login;