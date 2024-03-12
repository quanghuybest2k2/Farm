import axios from "axios";
import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import config from "../../config";
import swal from "sweetalert";

const EnvironmentCreate = () => {
  const navigate = useNavigate();
  const [inputErrorList, setInputErrorList] = useState({});

  const [environment, setEnvironment] = useState({
    temperature: 0,
    airQuality: 0,
    sensorLocation: "",
    brightness: 0,
  });
  const handleInput = (e) => {
    e.persist();
    setEnvironment({ ...environment, [e.target.name]: e.target.value });
  };

  const saveEnvironment = (e) => {
    e.preventDefault();

    const data = {
      airQuality: environment.airQuality,
      temperature: environment.temperature,
      sensorLocation: environment.sensorLocation,
      brightness: environment.brightness,
    };

    axios
      .post(`${config.API_URL}/environments`, data)
      .then((res) => {
        //   alert(res.data.message);
        swal("Success", "Create successfully", "success");
        navigate("/environments");
      })
      .catch(function (error) {
        if (error.response) {
          if (error.response.status === 400) {
            setInputErrorList(error.response.data.errors);
          }
          if (error.response.status === 500) {
            // alert(error.response.data);
            swal("Oops!", error.response.data, "error");
          }
        }
      });
  };

  return (
    <>
      <div className="container mt-5">
        <div className="row">
          <div className="col-md-12">
            <div className="card">
              <div className="card-header">
                <h4>
                  Add Environment
                  <Link to="/environments" className="btn btn-danger float-end">
                    Back
                  </Link>
                </h4>
              </div>
              <div className="card-body">
                <form onSubmit={saveEnvironment}>
                  <div className="mb-3">
                    <label>Temperature</label>
                    <input
                      type="number"
                      name="temperature"
                      value={environment.temperature}
                      onChange={handleInput}
                      className="form-control"
                    />
                    <span className="text-danger">
                      {inputErrorList.temperature}
                    </span>
                  </div>

                  <div className="mb-3">
                    <label>airQuality</label>
                    <input
                      type="number"
                      name="airQuality"
                      value={environment.airQuality}
                      onChange={handleInput}
                      className="form-control"
                    />
                    <span className="text-danger">
                      {inputErrorList.airQuality}
                    </span>
                  </div>

                  <div className="mb-3">
                    <label>SensorLocation</label>
                    <input
                      type="text"
                      name="sensorLocation"
                      value={environment.sensorLocation}
                      onChange={handleInput}
                      className="form-control"
                    />
                    <span className="text-danger">
                      {inputErrorList.sensorLocation}
                    </span>
                  </div>

                  <div className="mb-3">
                    <label>Brightness</label>
                    <input
                      type="number"
                      name="brightness"
                      value={environment.brightness}
                      onChange={handleInput}
                      className="form-control"
                    />
                    <span className="text-danger">
                      {inputErrorList.brightness}
                    </span>
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
    </>
  );
};

export default EnvironmentCreate;
