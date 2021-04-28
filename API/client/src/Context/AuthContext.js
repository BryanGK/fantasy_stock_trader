import React, { useState, useContext, useEffect } from 'react';
import { useHistory } from 'react-router-dom';

const AuthContext = React.createContext();
const AuthUpdateContext = React.createContext();

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

    }, [history])

    return (
        <AuthContext.Provider value={isAuth}>
            <AuthUpdateContext.Provider value={setIsAuth}>
                {children}
            </AuthUpdateContext.Provider>
        </AuthContext.Provider>
    )
}
