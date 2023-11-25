import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { useEffect, useState } from 'react';


function App() {
    const [test, setTest] = useState("");

    useEffect(async () => {
        await axios.post(`https://localhost:7252/Page`, {
            /*Id: 23,
            ParentId: 22,
            PageName: "osstj"*/
        }).then(res => {
            console.log(res);
            setTest(res.data);
        });
    }, [test]);

    return (
        <div className="App">
            <h1>{test}</h1>
        </div>
    );
}

export default App;