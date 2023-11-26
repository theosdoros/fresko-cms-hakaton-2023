import axios from "axios";
import { route } from "../../vars.js";
import { useEffect, useState } from "react";

export default function WebNav() {
  const [pages, setPages] = useState([]);

  const getAllPages = async () => {
    await axios.get(route + "/page/index").then((res) => {
      setPages(res.data);
      console.log(res.data);
    });
  };

  useEffect(() => {
    getAllPages();
  }, []);

  return (
    <div className="web_nav_container">
      {pages.map((element) => {
        return (
          <a href={"/" + element.page_name} className="web_nav_item">
            {element.page_name}
          </a>
        );
      })}
    </div>
  );
}
