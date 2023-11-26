import axios from "axios";
import { route } from "../../vars.js";
import { useEffect, useState } from "react";
import Dialog, { DialogProps } from "@mui/material/Dialog";
import Article from "./Article.js";
import ImagePicker from "./ImagePicker.js";
import FilePicker from "./FilePicker.js";
import LinkPicker from "./LinkPicker.js";

export default function DashboardContent({ page, pageName }) {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [initData, setData] = useState(null);
  const [currComponent, setCurrComponent] = useState(null);
  const [componentList, setComponentList] = useState([]);
  const [components, setComponents] = useState([]);
  const [sortedComponents, setSortedComponents] = useState([]);

  const getComponents = async () => {
    if (page == null) return;
    await axios
      .get(route + "/page/" + page.id)
      .then((res) => {
        setData(res.data);
        organizeComponents(res.data);
      })
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

  const updateComponent = (componentData) => {
    //create to append to page and component table
    console.log(componentData);
    console.log("initdata");
    console.log(initData);
    var temp = initData;

    switch (componentData.alias) {
      case "article":
        var art = temp.articles.filter(
          (a) => a.position == componentData.position
        );

        if (art[0] == undefined) {
          temp.articles.push(componentData);
        } else {
          temp.articles.splice(
            temp.articles.findIndex(
              (a) => a.position == componentData.position
            ),
            1
          );
          temp.articles.push(componentData);
        }
        break;
      case "link":
        var art = temp.links.filter(
          (a) => a.position == componentData.position
        );

        if (art[0] == undefined) {
          temp.links.push(componentData);
        } else {
          temp.links.splice(
            temp.links.findIndex((a) => a.position == componentData.position),
            1
          );
          temp.links.push(componentData);
        }
        break;
      case "image":
        var art = temp.images.filter(
          (a) => a.position == componentData.position
        );
        if (art.size == 0) {
          temp.images.push(componentData);
        }
        break;
      case "file":
        var art = temp.files.filter(
          (a) => a.position == componentData.position
        );
        if (art == undefined) {
          temp.files.push(componentData);
        }
        break;
      default:
        console.log("error");
        break;
    }
    console.log("after");
    console.log(temp);
    setData(temp);
  };

  const publishPage = async () => {
    console.log(initData);
    var obj = {
      pageId: page.id,
      articles: initData.articles,
      links: initData.links,
      images: initData.images,
      files: initData.files,
    };
    console.log(obj);
    await axios
      .post(route + "/page/UpdatePage", {
        pageId: page.id,
        articles: initData.articles,
        links: initData.links,
        images: initData.images,
        files: initData.files,
      })
      .then((res) => console.log(res.data))
      .catch((err) => console.log(err));
  };

  useEffect(() => {
    setComponents([]);
    getComponents();
  }, [page]);

  useEffect(() => {
    sortComponents();
  }, [components]);

  return (
    <div>
      <Dialog open={isModalOpen} onClose={() => setIsModalOpen(false)}>
        <div>
          <h3>Choose a component</h3>
          <button
            onClick={() => {
              setIsModalOpen(false);
              setCurrComponent("article");
              var obj = {
                text: "",
                position: components.length + 1,
                creation_date: Date.now,
                alias: "article",
              };
              setComponents((components) => [...components, obj]);
              setCurrComponent(obj);
            }}
          >
            Add Article Text
          </button>
          <br />
          <br />
          <button
            onClick={() => {
              setIsModalOpen(false);
              setCurrComponent("link");
              var obj = {
                url: "",
                name_overwrite: "",
                position: components.length + 1,
                creation_date: Date.now,
                alias: "link",
              };
              setComponents((components) => [...components, obj]);
              setCurrComponent(obj);
            }}
          >
            Add Link Picker
          </button>
          <br />
          <br />
          <button
            onClick={() => {
              setIsModalOpen(false);
              setCurrComponent("image");
            }}
          >
            Add Image Picker
          </button>
          <br />
          <br />
          <button
            onClick={() => {
              setIsModalOpen(false);
              setCurrComponent("file");
            }}
          >
            Add File Picker
          </button>
          <br />
          <br />
        </div>
      </Dialog>
      <div>
        <button onClick={() => setIsModalOpen(true)}>Add module</button>
        {sortedComponents.map((c, index) => {
          if (c.alias == "article") {
            return (
              <Article
                data={c}
                page={page}
                position={index}
                updatedData={updateComponent}
              />
            );
          }
          if (c.alias == "image") {
            return (
              <ImagePicker
                data={c}
                position={index}
                updatedData={updateComponent}
              />
            );
          }
          if (c.alias == "file") {
            return (
              <FilePicker
                data={c}
                position={index}
                updatedData={updateComponent}
              />
            );
          }
          if (c.alias == "link") {
            return (
              <LinkPicker
                data={c}
                page={page}
                position={index}
                updatedData={updateComponent}
              />
            );
          }
        })}
      </div>
      <button onClick={() => publishPage()}>Објави старницу :)</button>
    </div>
  );
}
