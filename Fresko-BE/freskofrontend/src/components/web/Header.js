import axios from "axios";
import { route } from "./../../vars.js";
import { useEffect, useState } from "react";

import { Link } from 'react-router-dom';

export default function Header() {
  return (

    <>
    <header>
      <div className="header_logo_container">
        <h2> Лого </h2>
      </div>
      <nav>
        <ul>
          <li>
            <Link to="/:pagename">Почетна</Link>
          </li>
          <li>
            <Link to="#">Артикл</Link>
          </li>
        </ul>
      </nav>
    </header>
    </>

  )
}
