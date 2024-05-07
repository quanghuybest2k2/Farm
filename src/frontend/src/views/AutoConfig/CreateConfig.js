import React, { useEffect, useState } from "react";
import {
  CButton,
  CCard,
  CCardBody,
  CCardHeader,
  CCol,
  CForm,
  CFormSelect,
  CFormInput,
  CFormLabel,
  CRow,
  CLink,
  CSpinner,
} from "@coreui/react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import config from "../../config";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { format } from "date-fns";
import Swal from "sweetalert2";

const CreateConfig = () => {
  const [loading, setLoading] = useState(true);
  const today = new Date();
  const [startDate, setStartDate] = useState(today);
  const [endDate, setEndDate] = useState(today);
  const [farms, setFarms] = useState([]);
  // optiop ở chọn khu vực
  const [farmSelected, setFarmSelected] = useState(false);
  // chọn thiết bị
  const [selectedDevices, setSelectedDevices] = useState([]);
  // status device
  const [selectedStatus, setSelectedStatus] = useState("");
  const [disabledOption, setDisabledOption] = useState(false);
  const navigate = useNavigate();
  const [schedule, setSchedule] = useState({
    type: 1,
    startValue: 0,
    endValue: 0,
    startDate: "",
    endDate: "",
    isActive: false,
    farmId: 0,
    devices: [
      {
        id: "",
        statusDevice: false,
      },
    ],
  });

  useEffect(() => {
    axios
      .get(`${config.API_URL}/farms`)
      .then((response) => {
        // console.log(response.data.results)
        setFarms(response.data.results);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error fetching schedules:", error);
        setLoading(false);
      });
  }, []);

  // xử lý chọn thiết bị
  const handleDeviceChange = (deviceId) => {
    if (!selectedDevices.includes(deviceId)) {
      setSelectedDevices([...selectedDevices, deviceId]);
      setDisabledOption(true);
    }
  };

  // xử lý chọn status của đèn
  const handleStatusChange = (e) => {
    setSelectedStatus(e.target.value);
  };

  // reset chọn thiết bị
  const resetSelectedDevices = () => {
    setSelectedDevices([]);
    setDisabledOption(false);
  };

  // xử lý lấy giá trị của control
  const handleInput = (field, value) => {
    setSchedule({ ...schedule, [field]: value });
  };

  //Chọn ngày giờ start
  const handleStartDateChange = (date) => {
    setStartDate(date);
  };

  //Chọn ngày giờ end
  const handleEndDateChange = (date) => {
    setEndDate(date);
  };

  // api tạo mới
  const submitForm = (e) => {
    e.preventDefault();

    // format date
    const formatStartDate = format(startDate, "yyyy/MM/dd HH:mm:ss") ?? "";
    const formatEndDate = format(endDate, "yyyy/MM/dd HH:mm:ss") ?? "";

    const data = {
      type: parseInt(schedule.type),
      startValue: parseInt(schedule.startValue),
      endValue: parseInt(schedule.endValue),
      startDate: formatStartDate,
      endDate: formatEndDate,
      isActive: schedule.isActive,
      farmId: schedule.farmId,
      devices: selectedDevices.map((deviceId) => ({
        id: deviceId,
        statusDevice: selectedStatus === "1",
      })),
    };
    // console.log(data)

    axios
      .post(`${config.API_URL}/schedules`, data)
      .then((res) => {
        Swal.fire({
          icon: "success",
          text: "Tạo mới thành công",
          showConfirmButton: false,
          position: "top-end",
          toast: true,
          timer: 2000,
          showClass: {
            popup: `
                animate__animated
                animate__fadeInRight
                animate__faster
            `,
          },
        });
        navigate("/auto-config");
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error created schedules:", error);
        setLoading(false);
      });
  };

  return (
    <CRow>
      <CCol xs={12}>
        <CCard className="mb-4">
          <CCardHeader>
            <strong>Tạo</strong> <small>lịch mới</small>
            <CLink href="#/auto-config">
              <CButton className="float-end" color="primary">
                Trở về
              </CButton>
            </CLink>
          </CCardHeader>
          <CCardBody>
            {loading ? (
              <div className="text-center">
                <CSpinner color="primary" />
              </div>
            ) : (
              <>
                <p className="text-body-secondary small">
                  Tạo lập lịch cấu hình tự động thay cho việc{" "}
                  <code>Bật/Tắt</code> thủ công.
                </p>
                <CForm onSubmit={submitForm}>
                  <CRow className="mb-3">
                    <CFormLabel
                      className="col-sm-2 col-form-label"
                      onChange={(e) => handleInput("type", e.target.value)}
                    >
                      Loại
                    </CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect
                        size="large"
                        className="mb-3"
                        aria-label="Chọn loại"
                        onChange={(e) => handleInput("type", e.target.value)}
                      >
                        <option disabled>Chọn loại</option>
                        <option value="1">Nhiệt độ</option>
                        <option value="2">Độ ẩm</option>
                        <option value="3">Độ sáng</option>
                      </CFormSelect>
                    </CCol>
                  </CRow>
                  <CRow className="mb-3">
                    <CFormLabel className="col-sm-2 col-form-label">
                      Khu vực
                    </CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect
                        size="large"
                        className="mb-3"
                        aria-label="Chọn khu vực"
                        onChange={(e) => {
                          handleInput("farmId", e.target.value);
                          setFarmSelected(true);
                        }}
                      >
                        <option disabled={farmSelected}>Chọn khu vực</option>
                        {farms.map((farm) => (
                          <option value={farm.id} key={farm.id}>
                            {farm.name}
                          </option>
                        ))}
                      </CFormSelect>
                    </CCol>
                  </CRow>
                  <CRow className="mb-3">
                    <code className="mb-3">
                      <strong>Mẹo</strong>: Có thể chọn nhiều thiết bị
                    </code>
                    <CFormLabel className="col-sm-2 col-form-label">
                      Thiết bị
                    </CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect
                        size="large"
                        className="mb-3"
                        aria-label="Chọn thiết bị"
                        onChange={(e) => handleDeviceChange(e.target.value)}
                        value="select"
                      >
                        <option disabled={disabledOption} value="select">
                          Chọn thiết bị
                        </option>
                        {farms.map((farm) =>
                          farm.devices.map((device) => {
                            const isDeviceSelected = selectedDevices.includes(
                              device.id
                            );
                            return (
                              <option
                                key={device.id}
                                value={device.id}
                                hidden={isDeviceSelected}
                              >
                                {device.name}
                              </option>
                            );
                          })
                        )}
                      </CFormSelect>
                      <CFormSelect
                        size="large"
                        className="mb-3"
                        aria-label="Chọn trạng thái"
                        onChange={handleStatusChange}
                      >
                        <option disabled>Chọn trạng thái</option>
                        <option value="0">Tắt</option>
                        <option value="1">Bật</option>
                      </CFormSelect>
                      {/* Danh sách chọn */}
                      <ul>
                        {selectedDevices.map((deviceId) => {
                          const device = farms
                            .flatMap((farm) => farm.devices)
                            .find((device) => device.id === deviceId);
                          return <li key={device.id}>{device.name}</li>;
                        })}
                      </ul>
                      <CButton
                        color="danger"
                        size="sm"
                        className="float-end"
                        onClick={resetSelectedDevices}
                      >
                        Làm mới
                      </CButton>
                    </CCol>
                  </CRow>
                  <CRow className="mb-3">
                    <CCol sm={5}>
                      <div className="d-flex mt-3 align-items-center">
                        <div className="me-2">
                          <h6 className="mb-3">
                            Từ giá trị <code>(số nguyên)</code>
                          </h6>
                          <CFormInput
                            type="number"
                            placeholder="Nhập giá trị bắt đầu...."
                            name="startValue"
                            value={schedule.startValue}
                            onChange={(e) =>
                              handleInput("startValue", e.target.value)
                            }
                          />
                        </div>
                        <span className="text-muted mt-4">-</span>
                        <div className="ms-2">
                          <h6 className="mb-3">
                            Đến giá trị <code>(số nguyên)</code>
                          </h6>
                          <CFormInput
                            type="number"
                            placeholder="Nhập giá trị kết thúc...."
                            name="endValue"
                            value={schedule.endValue}
                            onChange={(e) =>
                              handleInput("endValue", e.target.value)
                            }
                          />
                        </div>
                      </div>
                    </CCol>
                  </CRow>
                  <CRow className="mb-3">
                    <CCol sm={5}>
                      <div className="d-flex mt-3 align-items-center">
                        <div className="me-2">
                          <h6 className="mb-3">Từ ngày</h6>
                          <DatePicker
                            withPortal
                            portalId="root-portal"
                            placeholderText="Chọn ngày bắt đầu"
                            className="form-control"
                            dateFormat="dd/MM/yyyy HH:mm:ss"
                            showTimeSelect
                            timeFormat="HH:mm:ss"
                            timeIntervals={10}
                            selected={startDate}
                            onChange={handleStartDateChange}
                            selectsStart
                            minDate={today}
                          />
                        </div>
                        <span className="text-muted mt-4">-</span>
                        <div className="ms-2">
                          <h6 className="mb-3">Đến ngày</h6>
                          <DatePicker
                            withPortal
                            portalId="root-portal"
                            placeholderText="Chọn ngày kết thúc"
                            className="form-control"
                            dateFormat="dd/MM/yyyy HH:mm:ss"
                            showTimeSelect
                            timeFormat="HH:mm:ss"
                            timeIntervals={10}
                            selected={endDate}
                            onChange={handleEndDateChange}
                            selectsEnd
                            minDate={startDate || today}
                          />
                        </div>
                      </div>
                    </CCol>
                  </CRow>
                  <CRow className="mt-4">
                    <CFormLabel className="col-sm-2 col-form-label">
                      Tình trạng
                    </CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect
                        size="large"
                        className="mb-3"
                        aria-label="Chọn giá trị"
                        onChange={(e) =>
                          handleInput("isActive", e.target.value === "1")
                        }
                      >
                        <option disabled>Chọn giá trị</option>
                        <option value="0">Tắt</option>
                        <option value="1">Bật</option>
                      </CFormSelect>
                    </CCol>
                  </CRow>
                  <CCol className="mt-3">
                    <CButton color="primary" type="submit">
                      Tạo mới
                    </CButton>
                  </CCol>
                </CForm>
              </>
            )}
          </CCardBody>
        </CCard>
      </CCol>
    </CRow>
  );
};

export default CreateConfig;
