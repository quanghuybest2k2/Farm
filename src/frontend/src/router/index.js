import React from "react";
import { Routes, Route } from "react-router-dom";
import Home from "../pages/Home";
import About from "../pages/About";
import Environment from "../pages/Environment/Environment";
import EnvironmentCreate from "../pages/Environment/EnvironmentCreate";
import EnvironmentEdit from "../pages/Environment/EnvironmentEdit";

const MyRouter = () => {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/about" element={<About />} />
      <Route path="/environments" element={<Environment />} />
      <Route path="/environments/create" element={<EnvironmentCreate />} />
      <Route path="/environments/:id/edit" element={<EnvironmentEdit />} />
    </Routes>
  );
};

export default MyRouter;
