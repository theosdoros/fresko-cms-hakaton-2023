import axios from "axios";
import { route } from "../../vars.js";
import { useEffect, useState } from "react";

export default function LinkPicker({ data, updatedData, page }) {
  const [url, setUrl] = useState(data.url);
  const [text, setText] = useState(data.name_overwrite);

  const setNewData = () => {
    data = {
      url: url,
      position: data.position,
      name_overwrite: text,
      alias: "link",
      page: page,
    };
    updatedData(data);
  };
  useEffect(() => {
    if (data.name_overwrite.trim().length != 0) {
      setText(data.name_overwrite);
    }
  }, []);

  return (
    <div>
      <h3>
        Екстерна веза
        <div>
          <label>Веза</label>
          <br />
          <input
            type="text"
            value={url}
            onChange={(e) => setUrl(e.target.value)}
            onBlur={() => setNewData()}
          />
          <br />
          <br />
          <label>Текст везе</label>
          <br />
          <input
            type="text"
            value={text}
            onChange={(e) => setText(e.target.value)}
            onBlur={() => setNewData()}
          />
          <br />
        </div>
      </h3>
    </div>
  );
}
