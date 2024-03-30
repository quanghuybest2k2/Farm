import React, { useEffect, useState } from "react";
import "@fortawesome/fontawesome-free/css/all.css";
import "./sb-admin-2.css";
import config from "../config";
import axios from "axios";

const Dashboard = () => {
  const [controlDevice, setControlDevice] = useState([]);
  const [devices, setDevices] = useState([]);
  const [filteredLights, setFilteredLights] = useState([]);
  const [filteredFans, setFilteredFans] = useState([]);

  const deviceId = "sensor-0";
  const action = "get";

  const type = {
    light: "light",
    fan: "fan",
  };

  const fetchData = () => {
    // socket
    axios
      .get(
        `${config.API_URL}/socketmangement?deviceId=${deviceId}&action=${action}`
      )
      .then((res) => {
        if (res.data) {
          setControlDevice(res.data);
        } else {
          setControlDevice([]);
        }
      });

    // device
    axios.get(`${config.API_URL}/devices`).then((res) => {
      // console.log(res.data.results);
      if (res.data) {
        setDevices(res.data.results);

        // Filter lights
        const lights = res.data.results.filter(
          (device) => device.type === type.light
        );
        setFilteredLights(lights);

        // Filter fans
        const fans = res.data.results.filter(
          (device) => device.type === type.fan
        );
        setFilteredFans(fans);
      } else {
        setDevices([]);
        setFilteredLights([]);
        setFilteredFans([]);
      }
    });
    console.log("APIs called");
  };

  useEffect(() => {
    // call
    fetchData();

    const millisecond = 5000;

    // Call fetchData every {millisecond} seconds
    const interval = setInterval(fetchData, millisecond);

    // Clear interval on component unmount
    return () => clearInterval(interval);
  }, []);

  const [farmStatus, setFarmStatus] = useState({
    cameraInfo: Array.from({ length: 3 }, () => ({
      info: "No unusual activity detected",
    })),
  });

  const updateDeviceStatus = (deviceId, newStatus) => {
    axios
      .put(`${config.API_URL}/devices/${deviceId}`, { status: newStatus })
      .then((res) => {
        console.log("Update successfully!");
        fetchData();
      })
      .catch((error) => {
        console.error("Error", error);
      });
  };

  return (
    <div id="content-wrapper" className="d-flex flex-column">
      {controlDevice && controlDevice.location && (
        <div id="content">
          <div className="container-fluid">
            <div className="container-fluid mx-4">
              <div className="row mt-5">
                <div className="col-lg-4">
                  <h2 className="h3 mb-3 text-gray-900">Môi trường</h2>
                  <p className="text-gray-900">
                    <i className="fas fa-thermometer-half mr-2" />
                    Nhiệt độ: {controlDevice.current.temp_c ?? 0}°C
                  </p>
                  <div className="card shadow">
                    <div className="card-body p-4">
                      <div
                        id="demo3"
                        className="carousel slide"
                        data-ride="carousel"
                      >
                        {/* Carousel inner */}
                        <div className="carousel-inner">
                          <div className="carousel-item active">
                            <div className="d-flex justify-content-around text-center">
                              <div className="flex-column">
                                <p className="small">
                                  <strong>21°C</strong>
                                </p>
                                <i
                                  className="fas fa-sun fa-2x mb-3"
                                  style={{ color: "#ddd" }}
                                />
                                <p className="mb-0">
                                  <strong>T2</strong>
                                </p>
                              </div>
                              <div className="flex-column">
                                <p className="small">
                                  <strong>20°C</strong>
                                </p>
                                <i
                                  className="fas fa-sun fa-2x mb-3"
                                  style={{ color: "#ddd" }}
                                />
                                <p className="mb-0">
                                  <strong>T3</strong>
                                </p>
                              </div>
                              <div className="flex-column">
                                <p className="small">
                                  <strong>16°C</strong>
                                </p>
                                <i
                                  className="fas fa-cloud fa-2x mb-3"
                                  style={{ color: "#ddd" }}
                                />
                                <p className="mb-0">
                                  <strong>T4</strong>
                                </p>
                              </div>
                              <div className="flex-column">
                                <p className="small">
                                  <strong>17°C</strong>
                                </p>
                                <i
                                  className="fas fa-cloud fa-2x mb-3"
                                  style={{ color: "#ddd" }}
                                />
                                <p className="mb-0">
                                  <strong>T5</strong>
                                </p>
                              </div>
                              <div className="flex-column">
                                <p className="small">
                                  <strong>18°C</strong>
                                </p>
                                <i
                                  className="fas fa-cloud-showers-heavy fa-2x mb-3"
                                  style={{ color: "#ddd" }}
                                />
                                <p className="mb-0">
                                  <strong>T6</strong>
                                </p>
                              </div>
                              <div className="flex-column">
                                <p className="small">
                                  <strong>18°C</strong>
                                </p>
                                <i
                                  className="fas fa-cloud-showers-heavy fa-2x mb-3"
                                  style={{ color: "#ddd" }}
                                />
                                <p className="mb-0">
                                  <strong>T7</strong>
                                </p>
                              </div>
                              <div className="flex-column">
                                <p className="small">
                                  <strong>20°C</strong>
                                </p>
                                <i
                                  className="fas fa-cloud-showers-heavy fa-2x mb-3"
                                  style={{ color: "#ddd" }}
                                />
                                <p className="mb-0">
                                  <strong>CN</strong>
                                </p>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                  <p className="text-gray-900 mt-3">
                    <i className="fas fa-vial mr-2 me-2" />
                    Độ ẩm: {controlDevice.current.humidity ?? 0}%
                  </p>
                  <p className="text-gray-900">
                    <i class="fa-solid fa-location-dot me-2" />
                    Vị trí: {controlDevice.location.name ?? ""}
                  </p>
                  <p className="text-gray-900">
                    <i class="fa-solid fa-sun me-2" />
                    Tình trạng: {controlDevice.current.condition.text ?? ""} /
                    Weather code: {controlDevice.current.condition.code ?? 0}
                  </p>
                  <p className="text-gray-900">
                    <i class="fa-solid fa-circle-half-stroke me-2" />
                    Hiện tại là:{" "}
                    {controlDevice.current.is_day === 0
                      ? "Ban đêm"
                      : "Ban ngày"}
                  </p>
                  <div className="card shadow mb-4">
                    <div className="card-body">
                      {/* card */}
                      <h4 className="small font-weight-bold">
                        Độ ẩm
                        <span className="float-right">
                          {controlDevice.current.humidity}%
                        </span>
                      </h4>
                      <div className="progress mb-4">
                        <div
                          className="progress-bar bg-info"
                          role="progressbar"
                          style={{
                            width: `${controlDevice.current.humidity}%`,
                          }}
                          aria-valuenow={controlDevice.current.humidity}
                          aria-valuemin={0}
                          aria-valuemax={100}
                        />
                      </div>
                      {/* end card */}
                    </div>
                  </div>
                </div>

                <div className="col-lg-8">
                  <div className="card shadow mb-4 mr-4">
                    <div className="card-header py-3">
                      <h6 className="h5 m-0 font-weight-bold text-primary">
                        Trạng thái thiết bị
                      </h6>
                    </div>

                    <div className="card-body">
                      {/* Fans */}
                      <h3 className="h5 my-3 text-gray-900">
                        <i className="fas fa-fan mr-2" />
                        fan
                      </h3>
                      <div className="flex-wrap" role="group">
                        {filteredFans.map((device, index) => (
                          <button
                            key={index}
                            className={`fixed-size-button m-1 rounded btn ${
                              device.status ? "btn-success" : "btn-danger"
                            }`}
                            onClick={() =>
                              updateDeviceStatus(device.id, !device.status)
                            }
                          >
                            <div>{device.name}</div>
                            <div>{device.status ? "Bật" : "Tắt"}</div>
                          </button>
                        ))}
                      </div>

                      {/* Lights */}
                      <h3 className="h5 my-3 text-gray-900">
                        <i className="fas fa-lightbulb mr-2" /> light
                      </h3>
                      <div className="flex-wrap" role="group">
                        {filteredLights.map((device, index) => (
                          <button
                            key={index}
                            className={`btn fixed-size-button m-1 rounded ${
                              device.status ? "btn-success" : "btn-danger"
                            }`}
                            onClick={() =>
                              updateDeviceStatus(device.id, !device.status)
                            }
                          >
                            <div>{device.name}</div>
                            <div>{device.status ? "Bật" : "Tắt"}</div>
                          </button>
                        ))}
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-lg-12">
                  <h2 className="h3 mb-3 text-gray-800">
                    Thông tin từ camera giám sát
                  </h2>
                  {farmStatus.cameraInfo.map((camera, index) => (
                    <p key={index}>
                      Camera {index + 1}: {camera.info}
                    </p>
                  ))}
                </div>
              </div>
            </div>

            <div className="row">{/* Content Column */}</div>
          </div>
        </div>
      )}
    </div>
  );
};

export default Dashboard;
