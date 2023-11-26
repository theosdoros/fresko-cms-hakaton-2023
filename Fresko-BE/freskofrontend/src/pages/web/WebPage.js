import axios from "axios";
import { route } from "./../../vars.js";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import FilePicker from "../../components/web/FilePicker.js";
import Article from "../../components/web/Article.js";
import ImagePicker from "../../components/web/ImagePicker.js";
import LinkPicker from "../../components/web/LinkPicker.js";
import WebHeader from "../../components/web/WebHeader.js";

export default function WebPage() {
  const [components, setComponents] = useState([]);
  const [sortedComponents, setSortedComponents] = useState([]);

  let params = useParams();

  const getComponents = async () => {
    await axios
      .get(route + "/" + params.pagename)
      .then((res) => organizeComponents(res.data))
      .catch((err) => console.log(err));
  };

  const organizeComponents = (pageData) => {
    var pageData = pageData;
    if (pageData == null) return;
    setComponents([]);

    if (pageData.articles.size != 0) {
      pageData.articles.forEach((e) => {
        var temp = {
          text: e.text,
          position: e.position,
          creation_date: e.cretion_date,
          alias: "article",
        };
        setComponents((articleList) => [...articleList, temp]);
      });
    }

    if (pageData.files.size != 0) {
      pageData.files.forEach((e) => {
        var temp = {
          absolute_path: e.absolute_path,
          description: e.description,
          position: e.position,
          creation_date: e.cretion_date,
          alias: "file",
        };
        setComponents((fileList) => [...fileList, temp]);
      });
    }
    if (pageData.images.size != 0) {
      pageData.images.forEach((e) => {
        var temp = {
          absolute_path: e.absolute_path,
          description: e.description,
          position: e.position,
          creation_date: e.cretion_date,
          alias: "image",
        };
        setComponents((imageList) => [...imageList, temp]);
      });
    }
    if (pageData.links.size != 0) {
      pageData.links.forEach((e) => {
        var temp = {
          url: e.url,
          name_overwrite: e.name_overwrite,
          position: e.position,
          creation_date: e.cretion_date,
          alias: "link",
        };
        setComponents((components) => [...components, temp]);
      });
    }
  };

  const sortComponents = () => {
    var tempArr = components;

    for (var i = 0; i < tempArr.length; i++) {
      for (var j = i + 1; j < tempArr.length; j++) {
        if (tempArr[i].position >= tempArr[j].position) {
          var temp = tempArr[i];
          tempArr[i] = tempArr[j];
          tempArr[j] = temp;
        }
      }
    }
    setSortedComponents(tempArr);
  };

  useEffect(() => {
    setComponents([]);
    getComponents();
  }, []);

  useEffect(() => {
    sortComponents();
  }, [components]);

  return (
    <div className="webpage">
      <WebHeader />
      {sortedComponents.map((c) => {
        if (c.alias == "article") {
          return <Article data={c} />;
        }
        if (c.alias == "image") {
          return <ImagePicker data={c} />;
        }
        if (c.alias == "file") {
          return <FilePicker data={c} />;
        }
        if (c.alias == "link") {
          return <LinkPicker data={c} />;
        }
      })}
    </div>
  );
}
