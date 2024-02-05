import {createContext, useState, useContext, useEffect,ReactNode} from "react";
import {AxiosInstance} from "axios";
const AuthContext = createContext({});
export const useAuth = () => useContext(AuthContext);

interface AuthProviderProps {
    children: ReactNode;
}

export const _getUser = async (axios: AxiosInstance): Promise<User> => {
    const response = await axios.get("/Account/me");

    return response.data;
};

export interface User {
    id: number;
    namename: string;
    email: string;
}

export const AuthProvider = ({ children }:AuthProviderProps) => {
    const [user, setUser] = useState<User | null>(null);
    const [loaded, setLoaded] = useState(false);
    
    useEffect(() => {
        console.log(auth)
    });
    const [auth, setAuth] = useState<any>({});
    return (
        <AuthContext.Provider value={{ auth, setAuth }}>
    {children}
    </AuthContext.Provider>
)
}
export default AuthContext;