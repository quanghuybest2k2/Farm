import axios from "axios";
import React, { useState } from "react";
import { Link } from "react-router-dom";
import config from "../config";
import Loading from "../components/Loading";
import swal from "sweetalert";

const EnvironmentCreate = () => {
  const [inputErrorList, setInputErrorList] = useState({});
  const [isVisibleLoading, setIsVisibleLoading] = useState(true);

  const [environment, setEnvironment] = useState({
    name: "",
    type: "",
  });

  const handleInput = (e) => {
    e.persist();
    setEnvironment({ ...environment, [e.target.name]: e.target.value });
  };

  const saveEnvironment = (e) => {
    e.preventDefault();

    setIsVisibleLoading(true);

    const data = {
      name: environment.name,
      type: environment.type,
    };

    axios
      .post(`${config.API_URL}/environments`, data)
      .then((res) => {
        if (res.data) {
          //   alert(res.data.message);
          swal("Success", res.data.message, "success");
          setIsVisibleLoading(false);
        }
      })
      .catch(function (error) {
        if (error.response) {
          if (error.response.status === 422) {
            setInputErrorList(error.response.data.errors);
          }
          if (error.response.status === 500) {
            // alert(error.response.data);
            swal("Oops!", error.response.data, "error");
          }
          setIsVisibleLoading(false);
        }
      });
  };

  return (
    <>
      {isVisibleLoading ? (
        <Loading />
      ) : (
        <div className="container mt-5">
          <div className="row">
            <div className="col-md-12">
              <div className="card">
                <div className="card-header">
                  <h4>
                    Add Environment
                    <Link
                      to="/environments"
                      className="btn btn-danger float-end"
                    >
                      Back
                    </Link>
                  </h4>
                </div>
                <div className="card-body">
                  <form onSubmit={saveEnvironment}>
                    <div className="mb-3">
                      <label>Name</label>
                      <input
                        type="text"
                        name="name"
                        value={environment.name}
                        onChange={handleInput}
                        className="form-control"
                      />
                      <span className="text-danger">{inputErrorList.name}</span>
                    </div>
                    <div className="mb-3">
                      <label>Type</label>
                      <input
                        type="text"
                        name="type"
                        value={environment.type}
                        onChange={handleInput}
                        className="form-control"
                      />
                      <span className="text-danger">{inputErrorList.type}</span>
                    </div>
                    <div className="mb-3">
                      <button type="submit" className="btn btn-primary">
                        Save Environment
                      </button>
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default EnvironmentCreate;
