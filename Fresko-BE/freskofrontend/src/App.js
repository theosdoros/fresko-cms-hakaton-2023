import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { useEffect, useState } from 'react';
function App() {
    const [test, setTest] = useState("");

    useEffect(() => {
        // axios.get(`https://localhost:7252/Component`)
        //     .then(res => {
        //       setTest(res.data);
        //     });

        async function fetchData() {
            await axios.post(`https://localhost:7252/PageModel/Create`, {
                Id: 22,
                ParentId: 21,
                PageName: "agas"
            }
            ).then(res => {
                console.log(res);
                setTest(res.data);
            });
        }
        fetchData();
    }, [test]);

    return (
        <div className="App">
            <h1>{test}</h1>
        </div>
    );  
}
export default App;