import "./header.css";
export default function Header(props) {
  return (
    <header>
      <p>{props.level} lvl.</p>
      <div className="navigation">
        <ul>
          <li>Home</li>
          <li>Game</li>
          <li>About</li>
        </ul>
      </div>
    </header>
  );
}
