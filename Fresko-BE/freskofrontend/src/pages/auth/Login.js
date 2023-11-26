import axios from "axios";
import { route } from "./../../vars.js";
import { useEffect, useState } from "react";
import { useNavigate, Link } from "react-router-dom";

import Logo from '../../images/RegisterPageLogo.svg';

import "../../LoginStyle.css";

export default function Login({ appendUser, isLoggingOut }) {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [isUsernameSet, setIsUsernameSet] = useState(true);
  const [isPasswordSet, setIsPasswordSet] = useState(true);
  const [userExists, setUserExists] = useState(true);

  const navigate = useNavigate();

  const checkUser = (res) => {
    if (res.data == "User not found" || res.data == "Wrong Password") {
      setUserExists(false);
    } else {
      setUserExists(true);
      appendUser(res.data);
      if (JSON.parse(localStorage.getItem("currUser")).approved) {
        navigate("/fresko/dashboard");
      } else {
        navigate("/fresko/pending");
      }
    }
  };

  const login = async () => {
    if (username.trim().length !== 0 && password.trim().length !== 0) {
      await axios
        .post(route + "/auth/login", {
          username: username,
          password: password,
        })
        .then((res) => {
          checkUser(res);
        })
        .catch((err) => console.log(err));
    }
  };

  useEffect(() => {
    if (isLoggingOut) {
      localStorage.removeItem("currUser");
      appendUser(null);
    }
  }, [isLoggingOut]);

  return (
    <div className="login_container">
      <div className="login_card">
        <div className="login_image"></div>
        <div className="login_right">
          <div className="login_logo">
            <img src={ Logo } />
          </div>
            <div className="login_form">
              <div className="login_form_input_username">
              <p>Корисничко име</p>
              <input
                value={username}
                onChange={(e) => setUsername(e.target.value)}
              />
              {!isUsernameSet && (
                <p className="input_err">Polje ne može biti prazno!</p>
              )}
              </div>
              <div className="login_form_input_password">
              <p>Лозинка</p>
              <input
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
              {!isPasswordSet && (
                <p className="input_err">Polje ne može biti prazno!</p>
              )}
              </div>
              <button
                onClick={() => {
                  setIsUsernameSet(username.trim().length !== 0);
                  setIsPasswordSet(password.trim().length !== 0);
                  if (isPasswordSet && isUsernameSet) {
                    login();
                  }
                }}
              >
                Пријави ме
              </button>
              {!userExists && <p>Kredencijali koje ste uneli ne postoje!</p>}
          </div>
          <div className="login_register">
            <p>
              Имаш налог? <Link to="/fresko/register">Региструј се!</Link>
            </p>
          </div>
        </div>
      </div>
    </div>
  );
}
