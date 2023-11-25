import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import {useEffect, useState} from 'react';


function App() {
  const [test, setTest] = useState("");

  useEffect(async () => {
    // axios.get(`https://localhost:7252/Component`)
    //     .then(res => {
    //       setTest(res.data);
    //     });

    var article = JSON.stringify( {
      Id: 22,
      Text: "asdasdasdas"
  });
    await axios.post(`https://localhost:7252/Component/AddArticle`, {
      Id: 22,
      Text: "asdasdasdas"
    }).then(res => {
          console.log(res);
          setTest(res.data);
        });
  }, [test]);

  return (
    <div className="App">
      <h1>{test}</h1>
    </div>
  );
}

export default App;
