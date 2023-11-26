import axios from "axios";
import { route } from "./../../vars.js";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

export default function Register() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [email, setEmail] = useState("");
  const [isUsernameSet, setIsUsernameSet] = useState(true);
  const [isPasswordSet, setIsPasswordSet] = useState(true);
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
        <div className="regsiter_image">slicka</div>
        <div className="regsiter_right">
          <div className="regsiter_logo">
            <div className="regsiter_form">
              <p>Korisnicko ime</p>
              <input
                value={username}
                onChange={(e) => setUsername(e.target.value)}
              />
              {!isUsernameSet && (
                <p className="input_err">Polje ne može biti prazno!</p>
              )}
              <p>E-mail</p>
              <input value={email} onChange={(e) => setEmail(e.target.value)} />
              {!isEmailSet && (
                <p className="input_err">Polje ne može biti prazno!</p>
              )}
              <p>Lozinka</p>
              <input
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
              {!isPasswordSet && (
                <p className="input_err">Polje ne može biti prazno!</p>
              )}
              <button
                onClick={() => {
                  setIsUsernameSet(username.trim().length !== 0);
                  setIsPasswordSet(password.trim().length !== 0);
                  setIsEmailSet(email.trim().length !== 0);
                  if (isPasswordSet && isUsernameSet && isEmailSet) {
                    register();
                    setValidation(true);
                  }
                }}
              >
                Registruj me
              </button>
              {!validation && <p>Kredencijali koje ste uneli su neispravni!</p>}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
