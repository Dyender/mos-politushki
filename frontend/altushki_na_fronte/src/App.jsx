import { useEffect, useState } from "react";
import "./App.css";
import Header from "./components/Header";

function App() {
  const [count, setCount] = useState(0);
  const [rateClick, setRateClick] = useState(1);
  const [rateWait, setRateWait] = useState(0);
  const [lvl, setLvl] = useState(0);
  const [upgrades, setUpgrades] = useState([
    {
      id: 1,
      title: "Upgrade 1",
      description: "desciption if 1 upgrade",
      img: "https://avatars.mds.yandex.net/i?id=c5975475a533622dea43ec3e6549a05b_l-10285533-images-thumbs&n=13",
      purchased: false,
    },
    {
      id: 1,
      title: "Upgrade 1",
      description: "desciption if 1 upgrade",
      img: "https://avatars.mds.yandex.net/i?id=c5975475a533622dea43ec3e6549a05b_l-10285533-images-thumbs&n=13",
      purchased: false,
    },
    {
      id: 1,
      title: "Upgrade 1",
      description: "desciption if 1 upgrade",
      img: "https://avatars.mds.yandex.net/i?id=c5975475a533622dea43ec3e6549a05b_l-10285533-images-thumbs&n=13",
      purchased: false,
    },
    {
      id: 1,
      title: "Upgrade 1",
      description: "desciption if 1 upgrade",
      img: "https://avatars.mds.yandex.net/i?id=c5975475a533622dea43ec3e6549a05b_l-10285533-images-thumbs&n=13",
      purchased: false,
    },
  ]);

  useEffect(() => {
    const interval = setInterval(() => {
      setCount((count) => count + rateWait);
    }, 1000);
    return () => clearInterval(interval);
  }, [rateWait]);

  function handleUpgrades() {}

  return (
    <div className="app">
      <Header level={lvl} />
      <div className="mainBlock">
        <div className="counter">
          <button
            className={"mainButton"}
            onClick={() => setCount(count + rateClick)}
          >
            <h1>{count} 💵</h1>
          </button>
        </div>

        <div className="buttonBlock">
          <button
            className={"glow-pink"}
            onClick={() => setRateClick(rateClick + 1)}
          >
            📊
          </button>
          <button
            className={"glow-pink"}
            onClick={() => setRateWait(rateWait + 1)}
          >
            🏛️
          </button>
        </div>
      </div>
      <hr />
      <div className="upgradeBlock">
        {upgrades.map((upgrade) => (
          <div id={upgrade.id} className="upgrade">
            <div>
              <p>{upgrade.title}</p> <p>{upgrade.description}</p>
            </div>{" "}
            <img className="upgradeImg" src={upgrade.img} />{" "}
          </div>
        ))}
      </div>
      <hr />
      debug
      <p>count: {count}</p>
      <p>rateClick: {rateClick}</p>
      <p>rateWait: {rateWait}</p>
    </div>
  );
}

export default App;
