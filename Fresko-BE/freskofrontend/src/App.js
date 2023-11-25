import { BrowserRouter } from 'react-router-dom';
import './App.css';
import axios from 'axios';
import {useEffect, useState} from 'react';
import {route} from "./vars.js";


function App() {
  const [user, setUser] = useState(null);

  const fetchUser = async () => {
    await axios.get(route + "/user")
    .then(res => setUser(res.data))
    .catch(err => console.log(err))
  };

  useEffect(() => {
    //fetchUser;
  }, [user])

  return (
    <BrowserRouter>
      
    </BrowserRouter>
  );
}

export default App;
