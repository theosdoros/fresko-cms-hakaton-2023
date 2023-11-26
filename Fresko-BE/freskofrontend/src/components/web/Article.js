import axios from "axios";
import { route } from "./../../vars.js";
import { useEffect, useState } from "react";

export default function Article({ data }) {
  return (
    <div>
      <div dangerouslySetInnerHTML={{ __html: data.text }}></div>
    </div>
  );
}
