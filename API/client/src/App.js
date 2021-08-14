import React from 'react';
import PageRoutes from './Routing/PageRoutes';
import { AuthProvider } from './Context/AuthContext';
import { withRouter } from 'react-router-dom';
import './Styles/App.css';



function App() {

    return (
        <div className="App">
            <AuthProvider>
                <PageRoutes />
            </AuthProvider>
        </div>

    );
}

export default withRouter(App);
