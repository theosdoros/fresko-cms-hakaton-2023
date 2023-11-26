import axios from "axios";
import { route } from "../../vars.js";
import { useEffect, useState } from "react";

export default function LinkPicker({ data }) {
  return (
    <a href={data.url}>
      {data.name_overwrite.trim().length == 0 ? data.url : data.name_overwrite}
    </a>
  );
}
