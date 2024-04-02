import React, { useEffect, useState } from "react";
import "@fortawesome/fontawesome-free/css/all.css";
import config from "../config";
import axios from "axios";
import PieChart from "../components/PieChart";

const Dashboard = () => {
  const [controlDevice, setControlDevice] = useState([]);
  const [devices, setDevices] = useState([]);

  const farmId = "a023eaaa-6b6e-4169-88cf-95ef2dd8978a";

  const fetchData = async () => {
    // socket weather
    await axios
      .get(
        `${config.API_URL}/socketmanagement/messageToSocketSpecified?farmId=${farmId}`
      )
      .then((res) => {
        if (res.data) {
          setControlDevice(res.data);
        } else {
          setControlDevice([]);
        }
      });

    // device
    await axios.get(`${config.API_URL}/farms`).then((res) => {
      // console.log(res.data.results);
      if (res.data) {
        setDevices(res.data.results);
      } else {
        setDevices([]);
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

  const renderArea = () => {
    return (
      <>
        {devices.map((area, index) => (
          <div className="col-xl-4 col-md-6 mb-4" key={index}>
            <div className="card border-left-info shadow h-100 py-2">
              <div className="card-body">
                <div className="row no-gutters align-items-center">
                  <div className="col mr-2">
                    <div className="fs-6 text-center text-xs font-weight-bold text-info text-uppercase mb-2">
                      {area.name}
                    </div>
                    <h4 className="small font-weight-bold">
                      <text className="me-2">Tổng số thiết bị:</text>
                      <span className="float-right">
                        {area.active + area.off}
                      </span>
                    </h4>
                    <h4 className="small font-weight-bold">
                      <text className="me-2"> Đang hoạt động:</text>
                      <span className="float-right">{area.active}</span>
                    </h4>
                    <h4 className="small font-weight-bold">
                      <text className="me-2"> Đang tắt:</text>
                      <span className="float-right">{area.off}</span>
                    </h4>
                  </div>
                </div>
              </div>
            </div>
          </div>
        ))}
      </>
    );
  };

  const deviceTypes = [
    { name: "fan", iconClass: "fas fa-fan" },
    { name: "light", iconClass: "fas fa-lightbulb" },
    { name: "sensor", iconClass: "fa-solid fa-microchip" },
  ];

  const renderDevices = () => {
    return (
      <>
        {devices.map((area, index) => (
          <div key={index}>
            <div className="card shadow mb-4 mr-4 ">
              <div className="card-header py-3">
                <h6 className="h5 m-0 font-weight-bold text-primary">
                  Trạng thái thiết bị khu {area.name}
                </h6>
              </div>
              <div className="card-body">
                {/* devices */}
                <div>
                  {deviceTypes.map((type, index) => (
                    <div key={index}>
                      <h3 className="h5 my-3 text-gray-900">
                        <i
                          className={
                            type.iconClass
                              ? type.iconClass
                              : "fa-solid fa-microchip"
                          }
                        />
                        <text className="ms-2">{type.name}</text>
                      </h3>
                      <div className="flex-wrap" role="group">
                        {area.devices
                          .filter((device) => device.type === type.name)
                          .map((device, index) => (
                            <button
                              key={index}
                              className={`m-1 fixed-size-button rounded btn ${
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
                  ))}
                </div>

                {/* end devices */}
              </div>
            </div>
          </div>
        ))}
      </>
    );
  };

  // update status
  const updateDeviceStatus = async (deviceId, newStatus) => {
    try {
      const device = devices.find((device) => device.id === deviceId);
      const response = await axios.put(
        `${config.API_URL}/devices/${deviceId}`,
        {
          ...device,
          status: newStatus,
        }
      );
      console.log(response.data);
    } catch (error) {
      console.error("Error updating device status:", error);
    }
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
                  <h2 className="h3 mb-3 text-gray-900">7 ngày tới</h2>
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
                                <img
                                  style={{ width: "50px", height: "50px" }}
                                  src="https://cdn.weatherapi.com/weather/64x64/night/176.png"
                                  alt="Mưa rào"
                                />
                                <p className="mb-0">
                                  <strong>Ngày 1</strong>
                                </p>
                              </div>
                              <div className="flex-column">
                                <p className="small">
                                  <strong>20°C</strong>
                                </p>
                                <img
                                  style={{ width: "50px", height: "50px" }}
                                  src="https://cdn.weatherapi.com/weather/64x64/night/176.png"
                                  alt="Mưa rào"
                                />
                                <p className="mb-0">
                                  <strong>Ngày 2</strong>
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
                    <text className="me-2">Hiện tại là:</text>
                    {controlDevice.current.is_day === 0
                      ? "Ban đêm"
                      : "Ban ngày"}
                  </p>
                  <div className="card shadow mb-4">
                    <div className="card-body">
                      {/* card */}
                      <h4 className="small font-weight-bold">
                        <text className="me-2">Độ ẩm</text>
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

                {/* trang thai thiet bi */}
                <div className=" col-lg-8">
                  {/* khu thiết bị */}
                  <div className="card shadow mb-4 mr-4 ">
                    <div className="card-header py-3">
                      <h6 className="h5 m-0 font-weight-bold text-primary">
                        Khu thiết bị
                      </h6>
                    </div>

                    <div className="card-body">
                      <div className="row">
                        {/* khu x */}
                        {renderArea()}
                        {/* end khu x */}
                      </div>
                    </div>
                  </div>
                  {/* end khu thiet bi */}

                  {/* devices */}
                  {renderDevices()}
                  {/* end devices */}
                </div>
                {/* end trang thai thiet bi */}
              </div>
              {/* pie */}
              <div className="row">
                <div className="col-lg-6">
                  <h2 className="h3 mb-3 text-gray-800">Biểu đồ tròn</h2>
                  <div
                    className="row"
                    style={{ width: "300px", height: "200px" }}
                  >
                    <PieChart />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default Dashboard;
