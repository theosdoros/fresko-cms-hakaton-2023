import axios from "axios";
import { route } from "../../vars.js";
import { useEffect, useState } from "react";

export default function BeHeader() {
  useEffect(() => {}, []);

  return (
    <div className="dashboard-header">
      <a href="/fresko/dashboard">Садржај<i class="fa-solid fa-book"></i></a>
      <a href="/fresko/media">Медије<i class="fa-solid fa-photo-film"></i></a>
      {JSON.parse(localStorage.getItem("currUser")) && (
        <a href="/fresko/admin-panel">Администраторски панел<i class="fa-solid fa-address-card"></i></a>
      )}
    </div>
  );
}
