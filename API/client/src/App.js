import React from 'react';
import NavBar from './Components/NavBar';
import Welcome from './Pages/Welcome';
import Home from './Pages/Home';
import Login from './Pages/Login';
import Report from './Pages/Report';
import Footer from './Components/Footer';
import ProtectedRoute from "./ProtectedRoute";
import PageRoutes from './PageRoutes';
import { AuthProvider } from './AuthContext';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import { useLogin } from './AuthContext';
import './Styles/App.css';


function App() {

    return (
        <div className="App">
            <NavBar />
            <AuthProvider>
                <PageRoutes />
            </AuthProvider>
            <Footer />
        </div>

    );
}

export default App;
