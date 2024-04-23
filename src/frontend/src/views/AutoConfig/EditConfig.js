import React, { useState } from "react";
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
} from "@coreui/react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { subDays, format, startOfDay, endOfDay } from "date-fns";

const EditConfig = () => {
  const [startDate, setStartDate] = useState("2024-04-08");
  const [endDate, setEndDate] = useState(null);
  const endDateNow = endOfDay(new Date());

  return (
    <>
      <CRow>
        <CCol xs={12}>
          <CCard className="mb-4">
            <CCardHeader>
              <strong>Edit</strong> <small>Schedules</small>
              <CLink href="#/auto-config">
                <CButton className="float-end" color="primary">
                  Back
                </CButton>
              </CLink>
            </CCardHeader>
            <CCardBody>
              <p className="text-body-secondary small">
                Edit automatic profiles to replace scheduled manual{" "}
                <code>on/off</code>.
              </p>
              <CForm>
                <CRow className="mb-3">
                  <CFormLabel className="col-sm-2 col-form-label">
                    Type
                  </CFormLabel>
                  <CCol sm={10}>
                    <CFormInput
                      type="text"
                      placeholder="Enter type...."
                      value="Nhiệt độ"
                    />
                  </CCol>
                </CRow>
                <CRow className="mb-3">
                  <CFormLabel className="col-sm-2 col-form-label">
                    Area
                  </CFormLabel>
                  <CCol sm={10}>
                    <CFormInput
                      type="text"
                      placeholder="Enter area...."
                      value="farm-2"
                    />
                  </CCol>
                </CRow>
                <CRow className="mb-3">
                  <CFormLabel className="col-sm-2 col-form-label">
                    Area Sensor
                  </CFormLabel>
                  <CCol sm={10}>
                    <CFormInput
                      type="text"
                      placeholder="Enter area sensor...."
                      value="KV2"
                    />
                  </CCol>
                </CRow>
                <CRow className="mb-3">
                  <CFormLabel className="col-sm-2 col-form-label">
                    Device
                  </CFormLabel>
                  <CCol sm={10}>
                    <CFormSelect
                      size="large"
                      className="mb-3"
                      aria-label="Select device"
                      value="1"
                    >
                      <option>Select device</option>
                      <option value="0">Quạt 1</option>
                      <option value="1">Đèn 1</option>
                      <option value="2">Đèn 2</option>
                    </CFormSelect>
                  </CCol>
                </CRow>
                <CRow className="mb-3">
                  <CFormLabel className="col-sm-2 col-form-label">
                    Status
                  </CFormLabel>
                  <CCol sm={10}>
                    <CFormSelect
                      size="large"
                      className="mb-3"
                      aria-label="Select status"
                      value="1"
                    >
                      <option>Select status</option>
                      <option value="0">Off</option>
                      <option value="1">On</option>
                    </CFormSelect>
                  </CCol>
                </CRow>
                <CRow className="mb-3">
                  <CCol sm={5}>
                    <div className="d-flex mt-3 align-items-center">
                      <div className="me-2">
                        <h6 className="mb-3">
                          From value <code>(number)</code>
                        </h6>
                        <CFormInput
                          type="number"
                          placeholder="Enter start value...."
                          value="25"
                        />
                      </div>
                      <span className="text-muted mt-4">-</span>
                      <div className="ms-2">
                        <h6 className="mb-3">
                          To value <code>(number)</code>
                        </h6>
                        <CFormInput
                          type="number"
                          placeholder="Enter end value...."
                          value="30"
                        />
                      </div>
                    </div>
                  </CCol>
                </CRow>
                <CRow className="mb-3">
                  <CCol sm={5}>
                    <div className="d-flex mt-3 align-items-center">
                      <div className="me-2">
                        <h6 className="mb-3">From date</h6>
                        <DatePicker
                          selected={startDate}
                          onChange={(date) => setStartDate(date)}
                          selectsStart
                          startDate={startDate}
                          endDate={endDate}
                          withPortal
                          portalId="root-portal"
                          placeholderText="Choose from date"
                          className="form-control"
                          dateFormat="dd/MM/yyyy"
                          maxDate={endDateNow}
                        />
                      </div>
                      <span className="text-muted mt-4">-</span>
                      <div className="ms-2">
                        <h6 className="mb-3">To date</h6>
                        <DatePicker
                          selected={endDate ?? endDateNow}
                          onChange={(date) => setEndDate(date)}
                          selectsEnd
                          startDate={startDate}
                          endDate={endDate}
                          minDate={startDate}
                          maxDate={endDateNow}
                          withPortal
                          portalId="root-portal"
                          placeholderText="Choose to date"
                          className="form-control"
                          dateFormat="dd/MM/yyyy"
                        />
                      </div>
                    </div>
                  </CCol>
                </CRow>
                <CRow className="mt-4">
                  <CFormLabel className="col-sm-2 col-form-label">
                    Active
                  </CFormLabel>
                  <CCol sm={10}>
                    <CFormSelect
                      size="large"
                      className="mb-3"
                      aria-label="Select active"
                      value="1"
                    >
                      <option>Select active</option>
                      <option value="0">Off</option>
                      <option value="1">On</option>
                    </CFormSelect>
                  </CCol>
                </CRow>
                <CCol className="mt-3">
                  <CButton color="primary" type="submit">
                    Update
                  </CButton>
                </CCol>
              </CForm>
            </CCardBody>
          </CCard>
        </CCol>
      </CRow>
    </>
  );
};

export default EditConfig;
