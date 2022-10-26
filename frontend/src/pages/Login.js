import { useState, useRef, useEffect, useContext } from "react";
import { useNavigate } from "react-router-dom";
import {Form} from "react-bootstrap";
import Button from "react-bootstrap/Button";
import "./Login.css";
import Signup from "./Signup";
import axios from "../api/axios";
import Questions from "./Questions";
import Regist from "./Regist";
const LOGIN_URL = "/login";

const Login = (props) => {
    const navigate = useNavigate();
    const userRef = useRef();
    const errRef = useRef();

    const [userid, setUserid] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [errMsg, setErrMsg] = useState("");

    useEffect(() => {
        userRef.current.focus();
    }, []);

    useEffect(() => {
        setErrMsg("");
    }, [email, password]);


    const signUp = () => {
        props.setToken({ token: { logged: false }, setToken: props.setToken });
        navigate("/regist");
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.get(`${LOGIN_URL}/${email}`);

            const pwd = response.data;
            console.log('aaaaaaaaaaaaaaa')
            if (pwd !== -1) {
                console.log('aaaaaaaaaaaaaaa')
                setUserid(response.data)
                //const role = response.data.isModerator;
                // console.log(JSON.stringify(response?.data));
                //setUserid(userid);
                //setPassword("");
                //props.setToken({
                //    token: { email, userName, password, role },
                //    setToken: props.setToken,
                //});
                navigate("/questions")
            } else {
                setErrMsg("Email or Password Incorrect");
            }
        } catch (err) {
            console.log(err)
            if (!err.response) {
                setErrMsg("No Server Response");
            } else if (err.response.status === 400) {
                setErrMsg("Missing Username or Password");
            } else if (err.response.status === 401) {
                setErrMsg("Unauthorized");
            } else {
                setErrMsg("Login Failed");
            }
            errRef.current.focus();
        }
    };

    const handleSignup = async (e) => {
        e.preventDefault();
        navigate("/regist");
        
    };


    return (
        <>
            <div className="login-wrapper pt-4">
                <h1>Log In</h1>
                <p
                    ref={errRef}
                    className={errMsg ? "errmsg" : "offscreen"}
                    aria-live="assertive"
                >
                    {errMsg}
                </p>
                <Form onSubmit={handleSubmit}>
                    <Form.Group className="mb-3">
                        <Form.Label>
                            <p>Email</p>
                            <Form.Control
                                id="email"
                                type="email"
                                ref={userRef}
                                onChange={(e) => setEmail(e.target.value)}
                                value={email}
                                required
                            />
                        </Form.Label>
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Form.Label>
                            <p>Password</p>
                            <Form.Control
                                id="password"
                                type="password"
                                onChange={(e) => setPassword(e.target.value)}
                                value={password}
                                required
                            />
                        </Form.Label>
                    </Form.Group>
                    <Form.Group className="mb-3">
                        <Button type="submit" onClick={handleSubmit}>Submit</Button>
                    </Form.Group>
                </Form>
                <p>
                    Don't have an account?{" "}
                    <Button onClick={handleSignup}>Sign Up</Button>
                </p>
            </div>
            {/* )} */}
        </>
    );
};

export default Login;