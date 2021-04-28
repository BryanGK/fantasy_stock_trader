import React from 'react';
import NavBar from './Components/NavBar';
import Welcome from './Pages/Welcome';
import Home from './Pages/Home';
import Login from './Pages/Login';
import Report from './Pages/Report';
import Footer from './Components/Footer';
import ProtectedRoute from "./ProtectedRoute";
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import './Styles/App.css';

function App() {
    return (
        <Router>
            <div className="App">
                <NavBar />
                <Switch>
                    <Route path="/" exact component={Welcome} />
                    <Route path="/login" exact component={Login} />
                    <ProtectedRoute path="/home" component={Home} isAuth />
                    <ProtectedRoute path="/report" component={Report} isAuth />
                </Switch>
                <Footer />
            </div>
        </Router>
    );
}

export default App;
