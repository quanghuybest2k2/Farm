import React from "react";
import "@fortawesome/fontawesome-free/css/all.css";
import "./sb-admin-2.css";
import { useState } from "react";

const Dashboard = () => {
  const [farmStatus, setFarmStatus] = useState({
    environment: {
      temperature: 25,
      humidity: 80,
      lightIntensity: 70,
    },
    deviceStatus: {
      waterPumps: Array.from({ length: 3 }, (_, i) => ({
        isOn: true,
        name: `W${i + 1}`,
      })),
      lights: Array.from({ length: 3 }, (_, i) => ({
        isOn: false,
        name: `L${i + 1}`,
      })),
      fans: Array.from({ length: 3 }, (_, i) => ({
        isOn: true,
        name: `F${i + 1}`,
      })),
    },
    cameraInfo: Array.from({ length: 3 }, () => ({
      info: "No unusual activity detected",
    })),
  });

  const toggleDevice = (deviceType, index) => {
    setFarmStatus((prevStatus) => {
      const newStatus = { ...prevStatus };
      newStatus.deviceStatus[deviceType][index].isOn =
        !newStatus.deviceStatus[deviceType][index].isOn;
      return newStatus;
    });
  };

  return (
    <div id="content-wrapper" className="d-flex flex-column">
      <div id="content">
        <div className="container-fluid">
          <div className="container-fluid mx-4">
            <div className="row mt-5">
              <div className="col-lg-4">
                <h2 className="h3 mb-3 text-gray-900">Môi trường</h2>
                <p className="text-gray-900">
                  <i className="fas fa-thermometer-half mr-2" />
                  Nhiệt độ: {farmStatus.environment.temperature}°C
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
                  <i className="fas fa-vial mr-2" />
                  Độ ẩm: {farmStatus.environment.humidity}%
                </p>
                <p className="text-gray-900">
                  <i className="fas fa-sun mr-2" />
                  Cường độ ánh sáng: {farmStatus.environment.lightIntensity}%
                </p>
                <div className="card shadow mb-4">
                  <div className="card-body">
                    <h4 className="small font-weight-bold">
                      Độ ẩm <span className="float-right">80%</span>
                    </h4>
                    <div className="progress mb-4">
                      <div
                        className="progress-bar bg-info"
                        role="progressbar"
                        style={{ width: "80%" }}
                        aria-valuenow={80}
                        aria-valuemin={0}
                        aria-valuemax={100}
                      />
                    </div>

                    <h4 className="small font-weight-bold">
                      Cường độ ánh sáng
                      <span className="float-right">70%</span>
                    </h4>
                    <div className="progress mb-2">
                      <div
                        className="progress-bar bg-warning"
                        role="progressbar"
                        style={{ width: "70%" }}
                        aria-valuenow={70}
                        aria-valuemin={0}
                        aria-valuemax={100}
                      />
                    </div>
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
                    <h3 className="h5 my-3 text-gray-900">
                      <i className="fas fa-faucet mr-2" /> Máy bơm nước
                    </h3>
                    <div className="flex-wrap" role="group">
                      {farmStatus.deviceStatus.waterPumps.map((pump, index) => (
                        <button
                          key={index}
                          className={`m-1 fixed-size-button rounded btn ${
                            pump.isOn ? "btn-success" : "btn-danger"
                          }`}
                          onClick={() => toggleDevice("waterPumps", index)}
                        >
                          <div>{pump.name}</div>
                          <div>{pump.isOn ? "Bật" : "Tắt"}</div>
                        </button>
                      ))}
                    </div>

                    <h3 className="h5 my-3 text-gray-900">
                      <i className="fas fa-lightbulb mr-2" /> Đèn
                    </h3>
                    <div className="flex-wrap" role="group">
                      {farmStatus.deviceStatus.lights.map((pump, index) => (
                        <button
                          key={index}
                          className={`btn fixed-size-button m-1 rounded ${
                            pump.isOn ? "btn-success" : "btn-danger"
                          }`}
                          onClick={() => toggleDevice("lights", index)}
                        >
                          <div>{pump.name}</div>
                          <div>{pump.isOn ? "Bật" : "Tắt"}</div>
                        </button>
                      ))}
                    </div>

                    <h3 className="h5 my-3 text-gray-900">
                      <i className="fas fa-fan mr-2" />
                      Quạt
                    </h3>
                    <div className="flex-wrap" role="group">
                      {farmStatus.deviceStatus.fans.map((pump, index) => (
                        <button
                          key={index}
                          className={`fixed-size-button m-1 rounded btn ${
                            pump.isOn ? "btn-success" : "btn-danger"
                          }`}
                          onClick={() => toggleDevice("fans", index)}
                        >
                          <div>{pump.name}</div>
                          <div>{pump.isOn ? "Bật" : "Tắt"}</div>
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
    </div>
  );
};

export default Dashboard;
