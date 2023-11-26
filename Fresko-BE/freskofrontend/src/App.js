import { BrowserRouter, Routes, Route } from "react-router-dom";
import "./App.css";
import axios from "axios";
import { useEffect, useState } from "react";
import { route } from "./vars.js";
import { jwtDecode } from "jwt-decode";

import Login from "./pages/auth/Login.js";
import Register from "./pages/auth/Register.js";
import WebPage from "./pages/web/WebPage.js";
import LandingPage from "./pages/web/LandingPage.js";
import Media from "./pages/backoffice/Media.js";
import AdminPanel from "./pages/backoffice/AdminPanel.js";
import Dashboard from "./pages/backoffice/Dashboard.js";
import BeHeader from "./components/backoffice/BeHeader.js";

function App() {
  const [currUser, setCurrUser] = useState(
    JSON.parse(localStorage.getItem("currUser"))
  );

  const appendUser = (u) => {
    if (u == null) return;
    var decoded = jwtDecode(u);
    var user = {
      id: Number(decoded.nameid),
      username: decoded.unique_name,
      approved: decoded.actort == "True",
      isAdmin: decoded.role == "True",
    };
    localStorage.setItem("currUser", JSON.stringify(user));
    setCurrUser(JSON.parse(localStorage.getItem("currUser")));
  };

  useEffect(() => {}, [currUser]);

  return (
    <BrowserRouter>
      <Routes>
        <>
          <Route path="/" element={<LandingPage />} />
        </>
        {currUser == null && (
          <>
            <Route
              path="/fresko/login"
              element={<Login appendUser={appendUser} isLoggingOut={false} />}
            />
            <Route path="/fresko/register" element={<Register />} />
          </>
        )}
        {currUser != null && (
          <>
            <Route
              path="/fresko/logout"
              element={<Login appendUser={appendUser} isLoggingOut={true} />}
            />
            <Route
              path="/fresko/dashboard"
              element={<Dashboard user={currUser} />}
            />
            <Route path="/fresko/media" element={<Media />} />
            {currUser.isAdmin && (
              <Route path="/fresko/admin-panel" element={<AdminPanel />} />
            )}
          </>
        )}
        {currUser != null && !currUser.approved && (
          <Route path="/fresko/pending" element={<LandingPage />} />
        )}
        <Route path="/:pagename" element={<WebPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
