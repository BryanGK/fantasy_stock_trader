import React, { useState, useContext, createContext } from 'react';

const AuthContext = createContext();
const AuthUpdateContext = createContext();

export function useLogin() {
    return useContext(AuthContext);
}

export function useLoginUpdate() {
    return useContext(AuthUpdateContext);
}

export function AuthProvider({ children }) {
    const userData = JSON.parse(localStorage.getItem('userData'));
    // const [userData1, setUserData] = useState(userData);
    const [isAuth, setIsAuth] = useState(userData ? true : false);
    
    return (
        <AuthContext.Provider value={isAuth}>
            <AuthUpdateContext.Provider value={setIsAuth}>
                {children}
            </AuthUpdateContext.Provider>
        </AuthContext.Provider>
    )
}