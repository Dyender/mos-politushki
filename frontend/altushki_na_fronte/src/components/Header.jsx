import "./header.css";
import { Link } from "react-router-dom";

export default function Header(props) {
  return (
    <header>
      <p>{props.level} lvl.</p>
      <div className="navigation">
        <ul>
          <li><Link to="/">Home</Link></li>
          <li><Link to="/game">Game</Link></li>
          <li><Link to="/shop">Shop</Link></li>
          <li><Link to="/about">About</Link></li>
        </ul>
      </div>
    </header>
  );
}
