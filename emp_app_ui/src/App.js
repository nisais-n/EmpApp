import "./App.css";
import React from "react";
import { Home } from "./Pages/Home";
import { Department } from "./Pages/Department";
import { Employee } from "./Pages/Employee";
import { Navigation } from "./Pages/Components/Navigation";

import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
function App() {
  return (
    <Router>
      <div className="container">
        <h3 className="m-3 d-flex justify-content-center">Emp App</h3>

        <Navigation />

        <Routes>
          <Route exact path="/" element={<Home />} />
          <Route path="/department" element={<Department />} />
          <Route path="/employee" element={<Employee />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
