import { BrowserRouter, Route } from 'react-router-dom';
import './App.css';
import axios from 'axios';
import {useEffect, useState} from 'react';
import {route} from "./vars.js";


import Login from './pages/auth/Login.js';
import Register from './pages/auth/Register.js';
import WebPage from './pages/web/WebPage.js';
import LandingPage from './pages/web/LandingPage.js';
import Media from './pages/backoffice/Media.js';
import AdminPanel from './pages/backoffice/AdminPanel.js';
import Dashboard from './pages/backoffice/Dashboard.js'


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
      <Route 
        path="/fresko/login"
        element={<Login/>}
      />
      <Route 
        path="/fresko/register"
        element={<Register/>}
      />
      {
        user == null &&
        <>
          <Route 
          path="/fresko/dashboard"
          element={<Dashboard/>}
        />
        <Route 
          path="/fresko/media"
          element={<Media/>}
        />
        <Route 
          path="/fresko/admin-panel"
          element={<AdminPanel/>}
        />
      </>
      }
      
      <Route 
        path="/fresko/pending"
        element={<LandingPage/>}
      />
      <Route 
        path="/:pagename"
        element={<WebPage/>}
      />
    </BrowserRouter>
  );
}

export default App;
