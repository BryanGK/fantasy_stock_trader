import React, { useState, useContext } from 'react';

const AuthContext = React.createContext();
const AuthUpdateContext = React.createContext();

export function useLogin() {
    return useContext(AuthContext);
}

export function useLoginUpdate() {
    return useContext(AuthUpdateContext);
}

export function AuthProvider({ children }) {
    const [isAuth, setIsAuth] = useState(true);

    const userLogin = () => {

    }

    return (
        <AuthContext.Provider value={isAuth}>
            <AuthUpdateContext.Provider value={setIsAuth}>
                {children}
            </AuthUpdateContext.Provider>
        </AuthContext.Provider>
    )
}
