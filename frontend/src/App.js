import "./App.css";
import { Route, Routes } from "react-router-dom";
import Regist from "./pages/Regist";
import useToken from "./components/useToken";
import Login from "./pages/Login";
import Questions from "./pages/Questions";
import 'bootstrap/dist/css/bootstrap.min.css';


function App() {
    const { token, setToken } = useToken();
    

    if (!token) {
        return <Login setToken={setToken} />;
    }

    return (
        <div className="App">
            <h1>Questionaire</h1>
            <Routes>
                <Route path="/regist" element={<Regist />} />
                <Route path="/questions" element={<Questions />} />
                <Route path="/login" element={<Login setToken={setToken} />} />
                <Route path="/" element={<Questions />} />
                
            </Routes>
        </div>
    );
}

export default App;
