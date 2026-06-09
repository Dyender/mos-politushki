import Header from "../components/Header";
import { useEffect, useState } from "react";

export default function Game() {
  const [count, setCount] = useState(0);
  const [rateClick, setRateClick] = useState(1);
  const [rateWait, setRateWait] = useState(0);
  const [currentLvl, setcurrentLvl] = useState(1);
  const [costForNextLvl, setcostForNextLvl] = useState(1000);
  const [isUpgrades, setIsUpgrades] = useState(false);
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

  return (
    <div className="app">
      <Header level={currentLvl} />
      <div className="mainBlock">
        <div className="counter">
          <button
            className={"mainButton"}
            onClick={() => setCount(count + rateClick)}
          >
            <h1>{count} 💵</h1>
          </button>
        </div>

        <hr />
        <button
          className="lvlButton glow-pink"
          onClick={() => {
            count >= costForNextLvl
              ? (setCount(count - costForNextLvl),
                setcurrentLvl(currentLvl + 1),
                setcostForNextLvl(costForNextLvl * 5))
              : alert("не хватает деняк");
          }}
        >
          <p>Upgrade to</p>
          <p>lvl {currentLvl + 1}</p>
          <hr />
          <p className="cost">{costForNextLvl} 💵</p>
        </button>

        <div className="buttonBlock">
          <button
            className={"glow-pink small-button"}
            onClick={() => setRateClick(rateClick + 1)}
          >
            📊
          </button>
          <button
            className={"glow-pink small-button"}
            onClick={() => setIsUpgrades(!isUpgrades)}
          >
            📈
          </button>
          <button
            className={"glow-pink small-button"}
            onClick={() => setRateWait(rateWait + 1)}
          >
            🏛️
          </button>
          <button
            className={"glow-pink small-button"}
            onClick={() => setRateWait(rateWait + 1)}
          >
            ❤️
          </button>
        </div>
      </div>
      <hr />
      <div className={isUpgrades ? "upgradeBlock" : "upgradeBlock hidden"}>
        {upgrades.map((upgrade) => (
          <button key={upgrade.id} className="buttonUpgrade">
            <div>
              <p>{upgrade.title}</p> <p>{upgrade.description}</p>
            </div>{" "}
            <img className="upgradeImg" src={upgrade.img} />{" "}
          </button>
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
