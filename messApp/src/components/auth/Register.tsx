import {useEffect, useState,useRef} from "react";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faCheck, faTimes,faInfoCircle} from "@fortawesome/free-solid-svg-icons";
import axios from "../api/axios";


const USER_REGEX = /^[a-zA-Z0-9]{3,20}$/;
const PASSWORD_REGEX = /^(?!\s*$).{6,200}$/;
const EMAIL_REGEX = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/;
const REGISTER_URL = "/api/Account/signup";

const Register = () => {
    
    const userRef = useRef<HTMLInputElement>(null);
    const errRef = useRef<HTMLParagraphElement>(null);
    
    const [user, setUser] = useState('');
    const [validName,setValidName] = useState(false);
    const [userFocus, setUserFocus] = useState(false);
    
    const [email, setEmail] = useState('');
    const [validEmail,setValidEmail] = useState(false);
    const [emailFocus, setEmailFocus] = useState(false);

    const [pwd, setPwd] = useState('');
    const [validPwd,setValidPwd] = useState(false);
    const [pwdFocus, setPwdFocus] = useState(false);

    const [matchPwd, setMatchPwd] = useState('');
    const [validMatch,setValidMatch] = useState(false);
    const [matchPwdFocus, setMatchPwdFocus] = useState(false);

    const [success, setSuccess] = useState(false);
    const [errMsg, setErrMsg] = useState("");

    useEffect(() => {
        userRef.current?.focus();
    }, []);
    
    useEffect(() => {
        const result = USER_REGEX.test(user);
/*        console.log(result);
        console.log(user); */
        setValidName(result);
    }, [user]);

    useEffect(() => {
        const result = EMAIL_REGEX.test(email);
/*        console.log(result);
        console.log(email); */
        setValidEmail(result);
    }, [email]);
    
    useEffect(()=>{
        const result = PASSWORD_REGEX.test(pwd);
        /*console.log(result);*/
        setValidPwd(result);
        var match = pwd===matchPwd && pwd !== "";
/*        console.log(match);*/
        setValidMatch(match);
        setValidPwd(result);
    },[pwd,matchPwd])

    useEffect(() => {
        setErrMsg("");
    }, [pwd, matchPwd, user, email]);
    
    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        
        e.preventDefault();
        const v1 = USER_REGEX.test(user);
        const v2 = EMAIL_REGEX.test(email);
        const v3 = PASSWORD_REGEX.test(pwd);
        if (!v1 || !v2 || !v3) {
            setErrMsg("Formularz zawiera błędy");
            return;
        }
        try {
            const response = await axios.post(REGISTER_URL, 
                {
                    userId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    email: email,
                    username: user,
                    password: pwd
                });
                setSuccess(true);
                console.log(response);
  
                console.log(response.data);
        }catch (err: any){
            if (err.response.status === 400) {
                setErrMsg("Użytkownik o podanym adresie email/nazwie już istnieje");
                return;
            }
            if (!err.response) {
                setErrMsg("Błąd połączenia");
                return;
            }
        }
    };
    return (
        <>
            { success ? (
                <section>
                    <h2>Rejestracja zakończona sukcesem</h2>
                    <p>Na podany adres email została wysłana wiadomość z linkiem aktywacyjnym</p>
                    <p>
                        <a href="http://localhost:5173/login">Zaloguj się</a>
                    </p>
                </section>
            ) : (
                      
        <section>
            <h1>Sign Up</h1>
            <p ref={errRef} className={errMsg ? "errmsg" : "offscreen"} aria-live={"assertive"}>
                {errMsg}
            </p>
            <form onSubmit={handleSubmit}>
                <label htmlFor="user">Nazwa użytkownika: </label>
                <span className={validName ? "valid": "hide"}>
                    <FontAwesomeIcon icon={faCheck}/>
                </span>
                <span className={validName || !user ? "hide": "invalid"} >
                    <FontAwesomeIcon icon={faTimes}/>
                </span>
                <input
                    ref={userRef}
                    id="user"
                    type="text"
                    value={user}
                    autoComplete="off"
                    onChange={(e)=> setUser(e.target.value)}
                    onFocus={() => setUserFocus(true)}
                    onBlur={() => setUserFocus(false)}
                    />
                <p className={userFocus && user && !validName ? "instruction" :"offscreen"}>
                    <FontAwesomeIcon icon={faInfoCircle}/>
                    4 do 20 znaków, tylko litery i cyfry bez spacji
                </p>

                <label htmlFor="email">Email: </label>
                <span className={validEmail ? "valid": "hide"}>
                    <FontAwesomeIcon icon={faCheck}/>
                </span>
                <span className={validEmail || !email ? "hide": "invalid"} >
                    <FontAwesomeIcon icon={faTimes}/>
                </span>
                <input
                    id="email"
                    type="text"
                    value={email}
                    autoComplete="off"
                    onChange={(e)=> setEmail(e.target.value)}
                    onFocus={() => setEmailFocus(true)}
                    onBlur={() => setEmailFocus(false)}
                />
                <p className={emailFocus && email && !validEmail ? "instruction" :"offscreen"}>
                    <FontAwesomeIcon icon={faInfoCircle}/>
                    Niepoprawny adres email
                </p>
                
                <label htmlFor="password">Hasło: </label>
                <span className={validPwd ? "valid": "hide"}>
                    <FontAwesomeIcon icon={faCheck}/>
                </span>
                <span className={validPwd || !pwd ? "hide": "invalid"} >
                    <FontAwesomeIcon icon={faTimes}/>
                </span>
                <input
                    id="password"
                    type="password"
                    value={pwd}
                    required
                    onChange={(e)=> setPwd(e.target.value)}
                    onFocus={() => setPwdFocus(true)}
                    onBlur={() => setPwdFocus(false)}
                />
                <p className={pwdFocus   && !validPwd ? "instruction" :"offscreen"}>
                    <FontAwesomeIcon icon={faInfoCircle}/>
                    6 do 200 znaków, nie może być puste
                </p>
                
                <label htmlFor="passwordMatch">Potwierdz hasło: </label>
                <span className={validMatch ? "valid": "hide"}>
                    <FontAwesomeIcon icon={faCheck}/>
                </span>
                <span className={validMatch || !matchPwd ? "hide": "invalid"} >
                    <FontAwesomeIcon icon={faTimes}/>
                </span>
                <input
                    id="passwordMatch"
                    type="password"
                    value={matchPwd}
                    required
                    onChange={(e)=> setMatchPwd(e.target.value)}
                    onFocus={() => setMatchPwdFocus(true)}
                    onBlur={() => setMatchPwdFocus(false)}
                />
                <p className={matchPwdFocus && matchPwd && !validMatch ? "instruction" :"offscreen"}>
                    <FontAwesomeIcon icon={faInfoCircle}/>
                    6 do 200 znaków, nie może być puste
                </p>
                <button disabled={!validMatch || !validName || !validPwd || !validEmail}>Zarejestruj się</button>
            </form>
            <p>
                Already have a account?<br />
                <span className="line">
                            {/*put router link here*/}
                    <a href="http://localhost:5173/login">Sign In</a>
                        </span>
            </p>
        </section>)
            }
        </>
    );
    
};

export default Register;