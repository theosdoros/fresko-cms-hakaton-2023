import axios from "axios";
import { route } from "../../vars.js";
import { useEffect, useState } from "react";

export default function BeHeader() {
  useEffect(() => {}, []);

  return (
    <div>
      <a href="/fresko/dashboard">sardzaj</a>
      <a href="/fresko/media">medije</a>
      {JSON.parse(localStorage.getItem("currUser")) && (
        <a href="/fresko/admin-panel">admin panel</a>
      )}
    </div>
  );
}
