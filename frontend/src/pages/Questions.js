import { useState, useRef, useEffect } from "react";
import Form from "react-bootstrap/Form";
import ReactDOM from 'react-dom';
import Button from "react-bootstrap/Button";
import "./Questions.css";

import axios from "../api/axios";

const QUESTIONS_URL = "/questions";
function Questions() {
    const userRef = useRef();

    const [questions, setQuestions] = useState([]);
    const [question1, setQuestion1] = useState("");
    const [question2, setQuestion2] = useState("");
    const [question3, setQuestion3] = useState("");
    const [question4, setQuestion4] = useState("");
    const [question5, setQuestion5] = useState("");
    const [question6, setQuestion6] = useState("");
    const [question7, setQuestion7] = useState("");
    const [question8, setQuestion8] = useState("");
    const [question9, setQuestion9] = useState("");
    const [question10, setQuestion10] = useState("");
    const [error, setError] = useState("");
    const [success, setSuccess] = useState(false);

    useEffect(() => {
        setError("");
        axios.get(`${QUESTIONS_URL}`)
            .then(
                res => {
                    if (res.status == 200) {
                        setQuestions(res.data)
                    }
                }).catch(err => {
                    setError('Something went wrong');
                })
    }, [question1, question2, question3, question4, question5, question6, question7, question8, question9, question10]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        console.log(e.target)
        for (let i=0; i < e.target.length-1; ++i) {
            console.log(e.target[i].value)
        }

    }

    return (
        <div className="questions-wrapper pt-4">
            <h1>Questions</h1>
            <p className={error ? "errmsg" : "offscreen"} aria-live="assertive">
                {error}
            </p>
            <Form onSubmit={handleSubmit}>
                {questions.length ? questions.map((question) => {
                    return (
                        <Form.Group className="mb-3" key={question.questionId}>
                            <Form.Label>
                                <p>{question.label}</p>
                                {question.answerType == "Numeric" ?
                                    <Form.Control
                                    id="question1"
                                    type={question.answerType == "Numeric" ? "text" : "radio"}
                                    ref={userRef}
                                    defaultValue={question.answerContent}
                                    required
                                /> : <select>
                                    {question.choices.split(', ').map((choice) => {
                                        return <option value={choice}>{choice}</option>
                                    })}
                                    </select>
                                }
                            </Form.Label>
                        </Form.Group>
                    )
            }) : ''}
            <Button type="submit">Submit</Button>
            </Form>

                            {/*<Form.Group className="mb-3">
                    <Form.Label>
                        <p>From 1 to 10 how interested are you about Blockchain?</p>
                        <Form.Control
                            id="question2"
                            type="text"
                            ref={userRef}
                            onChange={(e) => setQuestion2(e.target.value)}
                            value={question2}
                            required
                        />
                    </Form.Label>
                </Form.Group>
                <div className="my-3">
                    <Label for="ques">Do you know about Blockchain?</Label>
                    <Input id="category" name="select" type="select" required onChange={(e) => handleCategory(e)}>

                        <option>question</option>
                        <option>suggestion</option>
                        <option>clarification</option>

                    </Input>
                </div>
                <Form.Group className="mb-3">
                    <Form.Label>
                        <p>question4</p>
                        <Form.Control
                            id="question4"
                            type="question4"
                            ref={userRef}
                            onChange={(e) => setQuestion4(e.target.value)}
                            value={question4}
                            required
                        />
                    </Form.Label>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>
                        <p>Question5</p>
                        <Form.Control
                            id="question5"
                            type="question5"
                            onChange={(e) => setQuestion5(e.target.value)}
                            value={question5}
                            required
                        />
                    </Form.Label>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>
                        <p>question6</p>
                        <Form.Control
                            id="question6"
                            type="question6"
                            onChange={(e) => setQuestion6(e.target.value)}
                            value={question6}
                            required
                        />
                    </Form.Label>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>
                        <p>question7</p>
                        <Form.Control
                            id="question7"
                            type="question7"
                            onChange={(e) => setQuestion7(e.target.value)}
                            value={question7}
                            required
                        />
                    </Form.Label>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>
                        <p>question7</p>
                        <Form.Control
                            id="question7"
                            type="question7"
                            onChange={(e) => setQuestion7(e.target.value)}
                            value={question7}
                            required
                        />
                    </Form.Label>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>
                        <p>question8</p>
                        <Form.Control
                            id="question8"
                            type="question8"
                            onChange={(e) => setQuestion8(e.target.value)}
                            value={question8}
                            required
                        />
                    </Form.Label>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>
                        <p>question9</p>
                        <Form.Control
                            id="question9"
                            type="question9"
                            onChange={(e) => setQuestion9(e.target.value)}
                            value={question9}
                            required
                        />
                    </Form.Label>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>
                        <p>question10</p>
                        <Form.Control
                            id="question10"
                            type="question10"
                            onChange={(e) => setQuestion10(e.target.value)}
                            value={question10}
                            required
                        />
                    </Form.Label>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Button type="submit">Submit</Button>
                </Form.Group>
            </Form>
        
        */}</div>)
}

export default Questions;