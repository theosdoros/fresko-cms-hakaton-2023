import axios from "axios";
import { route } from "../../vars.js";
import { useEffect, useState } from "react";

export default function ImagePicker({ data }) {
  useEffect(() => {}, []);

  return (
    <div>
      <p>{data.description}</p>
      <a href={data.absolute_path}>{data.absolute_path}</a>
    </div>
  );
}
