import { useEffect, useState } from "react";
import "./App.css";
import Header from "./components/Header";
import { Routes, Route } from "react-router-dom";

import Game from "./pages/Game";
import About from "./pages/About";
import Home from "./pages/Home";
import Shop from "./pages/Shop";

function App() {
  
  return ( <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/game" element={<Game />} />
      <Route path="/about" element={<About />} />
      <Route path="/shop" element={<Shop />} />
    </Routes>
    
  );
}

export default App;
