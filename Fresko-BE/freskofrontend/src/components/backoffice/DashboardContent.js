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
  const [currComponent, setCurrComponent] = useState(null);
  const [componentList, setComponentList] = useState([]);
  const [components, setComponents] = useState([]);
  const [sortedComponents, setSortedComponents] = useState([]);

  const getComponents = async () => {
    await axios
      .get(route + "/page/" + page.id)
      .then((res) => {
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
    var component = sortedComponents.find(componentData.id);
    if (component == null) {
      //create to append to page and component table
    } else {
      //update
    }
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
              setComponents((components) => [
                ...components,
                {
                  text: "",
                  position: components.length + 1,
                  creation_date: Date.now,
                  alias: "article",
                },
              ]);
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
              setComponents((components) => [
                ...components,
                {
                  url: "",
                  name_overwrite: "",
                  position: components.length + 1,
                  creation_date: Date.now,
                  alias: "link",
                },
              ]);
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
                position={index}
                updatedData={updateComponent}
              />
            );
          }
        })}
      </div>
      <button>Објави старницу :)</button>
    </div>
  );
}
