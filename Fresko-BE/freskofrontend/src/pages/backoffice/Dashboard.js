import axios from "axios";
import { route } from "./../../vars.js";
import { useEffect, useState } from "react";
import DashboardContent from "../../components/backoffice/DashboardContent.js";
import BeHeader from "../../components/backoffice/BeHeader.js";

export default function Dashboard() {
  const [pages, setPages] = useState([]);
  const [sortedPages, setSortedPages] = useState([]);
  const [pageName, setPageName] = useState(null);
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
      })
      .catch((err) => console.log(err));
  };

  useEffect(() => {
    getPages();
  }, []);

  useEffect(() => {
    console.log(pageName);
  }, [pageName]);

  return (
    <div>
      <BeHeader />
      <div>
        <div
          style={{ width: "30vw", height: "100vw", backgroundColor: "pink" }}
        >
          <button
            onClick={() => {
              setPageName(null);
              setParentIdState(0);
            }}
          >
            Add page
          </button>
          <br />
          <br />
          {sortedPages.map((el, index) => {
            if (el.parent_id != 0) {
              return (
                <div>
                  <button
                    onClick={() => setPageName(el.page_name)}
                    style={{ marginLeft: "25px" }}
                  >
                    {el.page_name}
                  </button>
                  <br />
                </div>
              );
            } else {
              return (
                <div>
                  <button onClick={() => setPageName(el.page_name)}>
                    {el.page_name}
                  </button>
                  <button
                    onClick={() => {
                      setPageName(null);
                      setParentIdState(el.id);
                    }}
                  >
                    Add page
                  </button>
                  <br />
                </div>
              );
            }
          })}
        </div>
        {pageName == null && (
          <div>
            <input
              value={newPageName}
              onChange={(event) => setNewPageName(event.target.value)}
            />
            <br />
            <button
              onClick={() => {
                createPage();
                setPageName(newPageName);
              }}
            >
              Potvrdi
            </button>
          </div>
        )}
        <DashboardContent pageName={pageName} />
      </div>
    </div>
  );
}
