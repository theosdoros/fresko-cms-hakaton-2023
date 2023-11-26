import axios from "axios";
import { route } from "./../../vars.js";
import { useEffect, useState } from "react";
import { useNavigate, Link } from "react-router-dom";

import "../../RegisterStyle.css";

import Logo from "../../images/RegisterPageLogo.svg";

export default function Register() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [repeatPassword, setRepeatPassword] = useState("");
  const [email, setEmail] = useState("");
  const [isUsernameSet, setIsUsernameSet] = useState(true);
  const [isPasswordSet, setIsPasswordSet] = useState(true);
  const [isRepeatPasswordSet, setIsRepeatPasswordSet] = useState(true);
  const [isEmailSet, setIsEmailSet] = useState(true);
  const [validation, setValidation] = useState(true);

  const navigate = useNavigate();
  const register = async () => {
    if (
      username.trim().length !== 0 &&
      password.trim().length !== 0 &&
      email.trim().length !== 0
    ) {
      await axios
        .post(route + "/auth/register", {
          username: username,
          password: password,
          email: email,
        })
        .then((res) => {
          if (res.data == "Success") {
            setIsUsernameSet("");
            setIsPasswordSet("");
            setIsRepeatPasswordSet("");
            setIsEmailSet("");
            navigate("/fresko/login");
          } else {
            setValidation(false);
          }
          console.log(res.data);
        })
        .catch((err) => console.log(err));
    }
  };

  useEffect(() => {}, []);

  return (
    <div className="regsiter_container">
      <div className="regsiter_card">
        <div className="regsiter_image"></div>
        <div className="regsiter_left">
          <div className="regsiter_logo">
            <img src={Logo} />
          </div>
          <div className="regsiter_form">
            <div className="register_form_input_username">
              <p>КОРИСНИЧКО ИМЕ</p>
              <input
                value={username}
                onChange={(e) => setUsername(e.target.value)}
              />
              {!isUsernameSet && (
                <p className="input_err">Поље не може бити празно!</p>
              )}
            </div>
            <div className="register_form_input_email">
              <p>E-МАИЛ</p>
              <input value={email} onChange={(e) => setEmail(e.target.value)} />
              {!isEmailSet && (
                <p className="input_err">Поље не може бити празно!</p>
              )}
            </div>
            <div className="register_form_input_password">
              <p>ЛОЗИНКА</p>
              <input
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
              {!isPasswordSet && (
                <p className="input_err">Поље не може бити празно!</p>
              )}
            </div>
            <div className="register_form_input_repeat_password">
              <p>ПОТВРДА ЛОЗИНКЕ</p>
              <input
                type="password"
                value={repeatPassword}
                onChange={(e) => setRepeatPassword(e.target.value)}
              />
              {!isRepeatPasswordSet && (
                <p className="input_err">Поље не може бити празно!</p>
              )}
            </div>
            <button
              onClick={() => {
                setIsUsernameSet(username.trim().length !== 0);
                setIsPasswordSet(password.trim().length !== 0);
                setIsRepeatPasswordSet(password.trim().length !== 0);
                setIsEmailSet(email.trim().length !== 0);
                if (
                  isPasswordSet &&
                  isUsernameSet &&
                  isEmailSet &&
                  isRepeatPasswordSet &&
                  password == repeatPassword
                ) {
                  register();
                  setValidation(true);
                }
              }}
            >
              РЕГИСРУЈ МЕ
            </button>
            {!validation && <p>Креденцијали које сте унели су неисправни!</p>}
            {password != repeatPassword && <p>Шифре се не покпапају!</p>}
          </div>
          <div className="register_login">
            <p>
              Имаш налог? <Link to="/fresko/login">Пријави се!</Link>
            </p>
          </div>
        </div>
      </div>
    </div>
  );
}
