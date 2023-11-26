import axios from "axios";
import { route } from "../../vars.js";
import { useEffect, useState } from "react";

export default function DashboardContent({ pageName }) {
  useEffect(() => {
    console.log(pageName);
  }, []);
  return <div></div>;
}
