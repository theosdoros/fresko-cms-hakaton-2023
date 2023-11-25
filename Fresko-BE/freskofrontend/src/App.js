import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import {useEffect, useState} from 'react';


function App() {
  const [test, setTest] = useState("");

  useEffect( () => {
  const testfunc = async () => {
    // await axios.get(`https://localhost:7252/Component/Index`).then(res => {
    //   console.log(res);
    //   setTest(res.data);
    // });
    // await axios.post(`https://localhost:7252/ArticleText/AddArticle`, {
    //   text: "asdasdasdas"
    // }).then(res => {
    //       console.log(res);
    //       setTest(res.data);
    //     })

    //   await axios.post(`https://localhost:7252/Page/Create`, {
    //     ParentId: 2,
    //     PageName: "asdasdasdas",
    //     CreationDate: "2023-11-25T17:21:51.202Z"
    // }).then(res => {
    //       console.log(res.data);
    //       setTest(res.data);
    //     });
  }
    testfunc();
  }, [test]);

  return (
    <div className="App">
      <h1>{test}</h1>
    </div>
  );
}

export default App;
