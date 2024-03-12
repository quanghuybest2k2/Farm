import axios from "axios";
import React, { useState, useEffect } from "react";
import { Link, useParams } from "react-router-dom";
import config from "../../config";
import swal from "sweetalert";

const EnvironmentEdit = () => {
  let { id } = useParams();

  const [inputErrorList, setInputErrorList] = useState({});

  const [environment, setEnvironment] = useState({});

  useEffect(() => {
    axios
      .get(`${config.API_URL}/environments/${id}`)
      .then((res) => {
        //   console.log(res.data.results);
        if (res.data) {
          setEnvironment(res.data);
        } else {
          setEnvironment(null);
        }
      })
      .catch(function (error) {
        if (error.response) {
          if (error.response.status === 404) {
            swal("Oops!", error.response.data.message, "error");
          }
          if (error.response.status === 500) {
            // alert(error.response.data);
            swal("Oops!", error.response.data, "error");
          }
        }
      });
  }, [id]);

  const handleInput = (e) => {
    e.persist();
    setEnvironment({ ...environment, [e.target.name]: e.target.value });
  };

  const updateEnvironment = (e) => {
    e.preventDefault();

    const data = {
      airQuality: environment.airQuality,
      temperature: environment.temperature,
      sensorLocation: environment.sensorLocation,
      brightness: environment.brightness,
    };

    axios
      .put(`${config.API_URL}/environments/${id}`, data)
      .then((res) => {
        swal("Success", "Updated successfully", "success");
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

  if (Object.keys(environment).length === 0) {
    return (
      <div className="container">
        <h4>Not found!</h4>
      </div>
    );
  }

  return (
    <>
      <div className="container mt-5">
        <div className="row">
          <div className="col-md-12">
            <div className="card">
              <div className="card-header">
                <h4>
                  Edit Environment
                  <Link to="/environments" className="btn btn-danger float-end">
                    Back
                  </Link>
                </h4>
              </div>
              <div className="card-body">
                <form onSubmit={updateEnvironment}>
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
                      Update Environment
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

export default EnvironmentEdit;
