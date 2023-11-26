import axios from "axios";
import { route } from "../../vars.js";
import { useEffect, useState } from "react";

export default function Article({ data, position, updatedData, page }) {
  const [text, setText] = useState(data.text);

  const setNewData = () => {
    if (data == null) {
      data = { position: position, text: text };
    }
    data = {
      text: text,
      position: data.position,
      alias: "article",
      page: page,
    };
    updatedData(data);
  };

  useEffect(() => {
    if (data.text.trim().length != 0) {
      setText(data.text);
    }
  }, []);

  return (
    <div>
      <h3>Članak</h3>
      <textarea
        type="text"
        rows="15"
        cols="150"
        value={text}
        onChange={(e) => {
          setText(e.target.value);
        }}
        onBlur={() => setNewData()}
      />
    </div>
  );
}
