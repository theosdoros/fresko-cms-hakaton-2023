import axios from "axios";
import { route } from "./../../vars.js";
import { useEffect, useState } from "react";
import { useParams } from "react-router";

export default function WebPage() {
  const [components, setComponents] = useState([]);
  let params = useParams();

  const getComponents = async () => {
    await axios
      .get(route + "/" + params.pagename)
      .then((res) => console.log(res.data))
      .catch((err) => console.log(err));
  };

  useEffect(() => {
    getComponents();
  }, []);

  return <h1>{params.pagename}</h1>;
}
