import React from 'react';
import PageRoutes from './Routing/PageRoutes';
import { AuthProvider } from './Context/AuthContext';
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

export default App;
