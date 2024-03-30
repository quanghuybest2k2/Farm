import React from "react";
import { Routes, Route } from "react-router-dom";
import Dashboard from "../pages/Dashboard";
import Environment from "../pages/Environment/Environment";
import EnvironmentCreate from "../pages/Environment/EnvironmentCreate";
import EnvironmentEdit from "../pages/Environment/EnvironmentEdit";

const MyRouter = () => {
  return (
    <Routes>
      <Route path="/" element={<Dashboard />} />
      <Route path="/environments" element={<Environment />} />
      <Route path="/environments/create" element={<EnvironmentCreate />} />
      <Route path="/environments/:id/edit" element={<EnvironmentEdit />} />
    </Routes>
  );
};

export default MyRouter;
