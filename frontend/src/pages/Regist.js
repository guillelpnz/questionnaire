import { useState, useRef, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import "./Regist.css";
import axios from "../api/axios";
const REGIST_URL = "/users";
const EMAIL_RESTRICTION = /^[a-zA-z0-9]+(?:@[a-zA-z0-9]+\.)+[A-Za-z]+$/;
function Regist() {
    const userRef = useRef();

    const[firstName,setFirstName] = useState("");
    const[lastName,setLastName] = useState("");    
    const [role, setRole] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [error, setError] = useState("");
    const [success, setSuccess] = useState(false);

    useEffect(() => {
        userRef.current.focus();
    }, []);

    useEffect(() => {
        setError("");
    }, [firstName,lastName,role,email,password,confirmPassword]);

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (password === confirmPassword) {
            const v1 = EMAIL_RESTRICTION.test(email);
            const v2 = password.length === 6;

            if (v1 && v2) {
                await axios
                    .post(`${REGIST_URL}`, {
                        firstName: firstName,
                        lastName: lastName,
                        role: role,
                        email: email,
                        password: password,
                        confirmPassword: confirmPassword
                    })
                    .then((res) => {
                        if (res.status === 201) {
                            setSuccess(true);
                        }
                    })
                    .catch((err) => {
                        if (err.response.status === 0) {
                            setError("No server response");
                        } else if (err.response.status === 409) {
                            setError("User already exists");
                        } else {
                            setError("Register failed");
                        }
                    });
            } else if (!v1) {
                setError("Invalid email");
            } else if (!v2) {
                setError("Password can only be 6 characters");
            }
        } else {
            setError("Passwords do not match");
        }
    };

    return (
        <>
        {success ? (
                <div className="login-wrapper pt-4">
                    <h1 id="title">Registered Successfully!</h1>
                    <br />
                    <p>
                        <Link to="/login">Go to Login</Link>
                    </p>
                </div>
            ) : ( 
        <div className="register-wrapper pt-4">
            <h1>Register</h1>
            <p className={error ? "errmsg" : "offscreen"} aria-live="assertive">
                {error}
            </p>
            <Form onSubmit={handleSubmit}>
                <Form.Group className="mb-3">
                    <Form.Label>
                        <p>First Name</p>
                        <Form.Control
                            id="firstName"
                            type="firstName"
                            ref={userRef}
                            onChange={(e) => setFirstName(e.target.value)}
                            value={firstName}
                            required
                        />
                    </Form.Label>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>
                        <p>Last Name</p>
                        <Form.Control
                            id="lastName"
                            type="lastName"
                            ref={userRef}
                            onChange={(e) => setLastName(e.target.value)}
                            value={lastName}
                            required
                        />
                    </Form.Label>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>
                        <p>Role</p>
                        <Form.Control
                            id="role"
                            type="role"
                            ref={userRef}
                            onChange={(e) => setRole(e.target.value)}
                            value={role}
                            required
                        />
                    </Form.Label>
                </Form.Group>
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
                    <Form.Label>
                        <p>Confirm Password</p>
                        <Form.Control
                            id="confirmPassword"
                            type="password"
                            onChange={(e) => setConfirmPassword(e.target.value)}
                            value={confirmPassword}
                            required
                        />
                    </Form.Label>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Button type="submit">Submit</Button>
                </Form.Group>
            </Form>
            <p>
                Do you already have an account? Login{" "}
                <Link to="/login">here</Link>!
            </p>
        </div>
        )}
        </>
    );
}
export default Regist;