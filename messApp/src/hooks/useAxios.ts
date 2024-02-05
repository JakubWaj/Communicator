import Cookies from "js-cookie";
import axios from "axios";

const getToken = () => {
    const token = Cookies.get('accessToken');
    if (!token) {
        throw new Error("No token found");
    }
    return token;
};

export const useAxios = () => {
    //   const { getToken } = useAuth();
    const instance = axios.create({
        baseURL: 'http://localhost:5153'
    });

    instance.interceptors.request.use(
        async (req) => {
            req.headers.Authorization = `Bearer ${getToken()}`;
            return req;
        },
        (error) => Promise.reject(error)
    );

    return instance;
};