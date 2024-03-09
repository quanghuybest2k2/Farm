import React from "react";

const Loading = () => {
  return (
    <div className="text-center">
      <div
        className="spinner-border text-success"
        role="status"
        aria-hidden="true"
      >
        <span className="visually-hidden">Loading...</span>
      </div>
      <span className="ms-2">Đang tải...</span>
    </div>
  );
};

export default Loading;
