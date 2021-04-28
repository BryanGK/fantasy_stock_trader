import React from 'react';
import Welcome from '../Pages/Welcome';
import Home from '../Pages/Home';
import Login from '../Pages/Login';
import Report from '../Pages/Report';
import NavBar from '../Components/NavBar';
import Footer from '../Components/Footer';
import ProtectedRoute from "./ProtectedRoute";
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import { useLogin } from '../Context/AuthContext';

function PageRoutes() {

    const isAuth = useLogin();

    return (
        <Router>
            <NavBar />
            <Switch>
                <Route path="/" exact component={Welcome} />
                <Route path="/login" exact component={Login} />
                <ProtectedRoute path="/home" component={Home} isAuth={isAuth} />
                <ProtectedRoute path="/report" component={Report} isAuth={isAuth} />
            </Switch>
            <Footer />
        </Router>

    )
}

export default PageRoutes