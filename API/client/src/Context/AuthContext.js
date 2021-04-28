import React, { useState, useContext, useEffect, createContext } from 'react';
import { useHistory } from 'react-router-dom';

const AuthContext = createContext();
const AuthUpdateContext = createContext();

export function useLogin() {
    return useContext(AuthContext);
}

export function useLoginUpdate() {
    return useContext(AuthUpdateContext);
}

export function AuthProvider({ children }) {
    const history = useHistory();
    const [isAuth, setIsAuth] = useState(false);
    
    useEffect(() => {
        (() => {
            const userData = JSON.parse(localStorage.getItem('userData'))
            console.log(userData);
            console.log("useEffect hits");
        })();
    }, [history]);

    return (
        <AuthContext.Provider value={isAuth}>
            <AuthUpdateContext.Provider value={setIsAuth}>
                {children}
            </AuthUpdateContext.Provider>
        </AuthContext.Provider>
    )
}
