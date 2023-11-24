import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import {useEffect, useState} from 'react';

function App() {
  const [test, setTest] = useState("");
  useEffect(() => {
    axios.get(`https://localhost:7252/home`)
        .then(res => {
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
