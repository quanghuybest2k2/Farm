import React from "react";
import { Routes, Route } from "react-router-dom";
import Home from "../pages/Home";
import About from "../pages/About";
import Environment from "../pages/Environment";
import EnvironmentCreate from "../pages/EnvironmentCreate";

const MyRouter = () => {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/about" element={<About />} />
      <Route path="/environments" element={<Environment />} />
      <Route path="/environments/create" element={<EnvironmentCreate />} />
    </Routes>
  );
};

export default MyRouter;
