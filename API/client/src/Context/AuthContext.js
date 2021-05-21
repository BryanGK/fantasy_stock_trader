import React, { useState, useContext, createContext, useEffect } from 'react';

const AuthContext = createContext();
const AuthUpdateContext = createContext();
const CurrentUserContext = createContext();
const UpdateUserContext = createContext();

export function useLogin() {
    return useContext(AuthContext);
}

export function useLoginUpdate() {
    return useContext(AuthUpdateContext);
}

export function useCurrentUser() {
    return useContext(CurrentUserContext);
}

export function useUserUpdate() {
    return useContext(UpdateUserContext);
}

export function AuthProvider({ children }) {
    const userData = JSON.parse(localStorage.getItem('userData'));
    const [isAuth, setIsAuth] = useState(userData ? true : false);
    const [currentUser, setCurrentUser] = useState();

    useEffect(() => {
        setCurrentUser(JSON.parse(localStorage.getItem('userData')));
        console.log("USERDATA");
    }, [isAuth]);

    return (
        <AuthContext.Provider value={isAuth}>
            <AuthUpdateContext.Provider value={setIsAuth}>
                <CurrentUserContext.Provider value={currentUser}>
                    <UpdateUserContext.Provider value={setCurrentUser}>
                        {children}
                    </UpdateUserContext.Provider>
                </CurrentUserContext.Provider>
            </AuthUpdateContext.Provider>
        </AuthContext.Provider>
    )
}