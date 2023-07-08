import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import LandingPage from "./common/landing_page";
import Login from "./Auth/Login";
import Dashboard from "./Admin/Dashboard";
import Users from "./Admin/user/Users";
import Employees from "./Admin/employee/Employees";
const App = () => {
  return (
    <Router>
      <Routes>
        <Route exact path="/" element={<LandingPage />} />
      </Routes>
      <Routes>
        <Route exact path="/login" element={<Login />} />
      </Routes>
      <Routes>
        <Route exact path="/admin/dashboard" element={<Dashboard />} />
      </Routes>
      <Routes>
        <Route exact path="/users" element={<Users />} />
      </Routes>
      <Routes>
        <Route exact path="/employees" element={<Employees />} />
      </Routes>
    </Router>
  );
};

export default App;
