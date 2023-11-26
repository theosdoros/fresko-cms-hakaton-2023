import axios from "axios";
import { route } from "./../../vars.js";
import { useEffect, useState } from "react";
import DashboardContent from "../../components/backoffice/DashboardContent.js";
import BeHeader from "../../components/backoffice/BeHeader.js";

import "../../DashboardStyle.css";

export default function Dashboard() {
  const [pages, setPages] = useState([]);
  const [sortedPages, setSortedPages] = useState([]);
  const [pageName, setPageName] = useState(null);
  const [selectedPage, setSelectedPage] = useState(null);
  const [newPageName, setNewPageName] = useState("");
  const [parentIdState, setParentIdState] = useState(0);

  const getPages = async () => {
    setPages([]);
    await axios
      .get(route + "/page/index")
      .then((res) => {
        setPages(res.data);
        sortPages(res.data);
      })
      .catch((err) => console.log(err));
  };

  const sortPages = (res) => {
    if (res == undefined || res == null) return;
    var tempArr = res;

    var test = [];

    for (var i = 0; i < tempArr.length; i++) {
      if (tempArr[i].parent_id == 0) {
        test.push(tempArr[i]);
      }
      for (var j = i + 1; j < tempArr.length; j++) {
        if (tempArr[i].id == tempArr[j].parent_id) {
          test.push(tempArr[j]);
        }
      }
    }
    setSortedPages(test);
  };

  const createPage = async () => {
    var obj = {
      parentId: parentIdState,
      pageName: newPageName,
      userId: JSON.parse(localStorage.getItem("currUser")).id,
    };
    await axios
      .post(route + "/page/create", obj)
      .then((res) => {
        getPages();
        setNewPageName("");
      })
      .catch((err) => console.log(err));
  };

  useEffect(() => {
    getPages();
  }, []);

  return (
    <div className="dashboard-hero-container">
      
      <div>
        <div style={{ width: "30vw", height: "100%",}} className="dashboard-addpage-container">
          <button className="dashboard-addpage-button"
            onClick={() => {
              setPageName(null);
              setParentIdState(0);
            }}
          >
            Додај страницу <i class="fa-solid fa-plus"></i>
          </button>
          <br />
          <br />
          {sortedPages.map((el, index) => {
            if (el.parent_id != 0) {
              return (
                <div>
                  <button className="dashboard-added-button"
                    onClick={() => {
                      setPageName(el.page_name);
                      setSelectedPage(el);
                    }}
                    style={{ marginLeft: "25px" }}
                  ><i class="fa-solid fa-file"></i>
                    {el.page_name}
                  </button>
                  <br />
                </div>
              );
            } else {
              return (
                <div>
                  <button className="dashboard-added-button"
                    onClick={() => {
                      setPageName(el.page_name);
                      setSelectedPage(el);
                    }}
                  ><i class="fa-solid fa-file"></i>
                    {el.page_name}
                  </button>
                  <button className="dashboard-added-button"
                    onClick={() => {
                      setPageName(null);
                      setParentIdState(el.id);
                    }}
                  >
                    Додај страницу
                  </button><i class="fa-solid fa-plus"></i>
                  <br />
                </div>
              );
            }
          })}
          {pageName == null && (
          <div>
            <input className="dashboard-input-pagename" placeholder="Унеси име странице овде"
              value={newPageName}
              onChange={(event) => setNewPageName(event.target.value)}
            />
            <br />
            <button className="dashboard-confirm-button"
              onClick={() => {
                createPage();
                setPageName(newPageName);
              }}
            >
              Потврди<i class="fa-solid fa-plus"></i>
            </button>
          </div>
        )}
        {pageName != null && (
          <DashboardContent page={selectedPage} pageName={pageName} />
        )}
      </div>
      </div>
      <div className="dashboard-hero-main-content">
      <BeHeader />
          <div className="dashboard-article-write-content">
              <textarea ></textarea>
          </div>
      </div>
    </div>
  );
}
