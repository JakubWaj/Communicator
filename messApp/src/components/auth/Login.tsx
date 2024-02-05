import { useRef, useState, useEffect, useContext,FormEvent } from 'react';
import useAuth from "../../hooks/useAuth.ts";
import axios from "../api/axios"
const LOGIN_URL = '/api/Account/signin';
import { Link, useNavigate, useLocation } from 'react-router-dom';
import Cookies from 'js-cookie';
const Login = () => {
    
    // @ts-ignore
    const {setAuth} = useAuth();
    const userRef = useRef<HTMLInputElement>(null);
    const errRef = useRef<HTMLParagraphElement>(null);
    const navigate = useNavigate();
    const location = useLocation();
    const from = location.state?.from?.pathname || "/main";
    const [email, setEmail] = useState('');
    const [pwd, setPwd] = useState('');
    const [errMsg, setErrMsg] = useState('');
    const [success, setSuccess] = useState(false);

    useEffect(() => {
        userRef.current?.focus();
    }, [])

    useEffect(() => {
        setErrMsg('');
    }, [email, pwd])

    const handleSubmit = async (e:FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        try {
            Cookies.remove('accessToken');
            const response = await axios.post(LOGIN_URL,
                {   
                    email,
                    password: pwd
                }
            );
            console.log(JSON.stringify(response?.data));
            const accessToken = response?.data?.accessToken;
            console.log(accessToken)
            setAuth({ email, pwd, accessToken });
            setEmail(''); 
            setPwd('');
            Cookies.set('accessToken', accessToken, { expires: 30 });
            navigate(from, { replace: true });
            setSuccess(true);
        } catch (err :any) {
            if (!err?.response) {
                setErrMsg('No Server Response');
            } else {
                setErrMsg('Login Failed');
            }
            errRef.current?.focus();
        }
    }

    return (
        <>
            {success ? (
                <section>
                    <h1>You are logged in!</h1>
                    <br />
                    <p>
                        <a href="#">Go to Home</a>
                    </p>
                </section>
            ) : (
                <section>
                    <p ref={errRef} className={errMsg ? "errmsg" : "offscreen"} aria-live="assertive">{errMsg}</p>
                    <h1>Sign In</h1>
                    <form onSubmit={handleSubmit}>
                        <label htmlFor="email">Email:</label>
                        <input
                            type="text"
                            id="email"
                            ref={userRef}
                            autoComplete="off"
                            onChange={(e) => setEmail(e.target.value)}
                            value={email}
                            required
                        />

                        <label htmlFor="password">Password:</label>
                        <input
                            type="password"
                            id="password"
                            onChange={(e) => setPwd(e.target.value)}
                            value={pwd}
                            required
                        />
                        <button>Sign In</button>
                    </form>
                    <p>
                        Need an Account?<br />
                        <span className="line">
                            {/*put router link here*/}
                            <a href="http://localhost:5173/Register">Sign Up</a>
                        </span>
                    </p>
                </section>
            )}
        </>
    )
}

export default Login