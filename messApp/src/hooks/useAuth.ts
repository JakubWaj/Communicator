import {useContext} from "react";
import AuthContext from "../context/AuthProvider";
import Cookies from "js-cookie";


const useAuth=() =>{
    return useContext(AuthContext);
}
export default useAuth;

