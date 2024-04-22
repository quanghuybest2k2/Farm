import React, { useState } from 'react'
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
} from '@coreui/react'
import { DocsExample } from 'src/components'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'
import { subDays, format, startOfDay, endOfDay } from 'date-fns'

const CreateConfig = () => {
  const [startDate, setStartDate] = useState(null)
  const [endDate, setEndDate] = useState(null)
  const endDateNow = endOfDay(new Date())

  return (
    <>
      <CRow>
        <CCol xs={12}>
          <CCard className="mb-4">
            <CCardHeader>
              <strong>Create</strong> <small>New Schedules</small>
            </CCardHeader>
            <CCardBody>
              <p className="text-body-secondary small">
                Create new automatic profiles to replace scheduled manual <code>on/off</code>.
              </p>
              <CForm>
                <CRow className="mb-3">
                  <CFormLabel className="col-sm-2 col-form-label">Type</CFormLabel>
                  <CCol sm={10}>
                    <CFormInput type="text" />
                  </CCol>
                </CRow>
                <CRow className="mb-3">
                  <CFormLabel className="col-sm-2 col-form-label">Area</CFormLabel>
                  <CCol sm={10}>
                    <CFormInput type="text" />
                  </CCol>
                </CRow>
                <CRow className="mb-3">
                  <CFormLabel className="col-sm-2 col-form-label">Area Sensor</CFormLabel>
                  <CCol sm={10}>
                    <CFormInput type="text" />
                  </CCol>
                </CRow>
                <CRow className="mb-3">
                  <CFormLabel className="col-sm-2 col-form-label">Device</CFormLabel>
                  <CCol sm={10}>
                    <CFormSelect size="sm" className="mb-3" aria-label="Select device">
                      <option>Select device</option>
                      <option value="0">Quạt 1</option>
                      <option value="1">Đèn 1</option>
                      <option value="2">Đèn 2</option>
                    </CFormSelect>
                  </CCol>
                </CRow>
                <CRow className="mb-3">
                  <CFormLabel className="col-sm-2 col-form-label">Status</CFormLabel>
                  <CCol sm={10}>
                    <CFormSelect size="sm" className="mb-3" aria-label="Select status">
                      <option>Select status</option>
                      <option value="0">Off</option>
                      <option value="1">On</option>
                    </CFormSelect>
                  </CCol>
                </CRow>
                <CRow className="mb-3">
                  <CFormLabel className="col-sm-2 col-form-label">From value</CFormLabel>
                  <CCol sm={10}>
                    <CFormInput type="number" />
                  </CCol>
                </CRow>
                <CRow className="mb-3">
                  <CFormLabel className="col-sm-2 col-form-label">To value</CFormLabel>
                  <CCol sm={10}>
                    <CFormInput type="number" />
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
                <CRow className="mb-3">
                  <CFormLabel className="col-sm-2 col-form-label">Active</CFormLabel>
                  <CCol sm={10}>
                    <CFormSelect size="sm" className="mb-3" aria-label="Select active">
                      <option>Select active</option>
                      <option value="0">Off</option>
                      <option value="1">On</option>
                    </CFormSelect>
                  </CCol>
                </CRow>
                <CButton color="primary" type="submit">
                  Create
                </CButton>
              </CForm>
            </CCardBody>
          </CCard>
        </CCol>
      </CRow>
    </>
  )
}

export default CreateConfig
