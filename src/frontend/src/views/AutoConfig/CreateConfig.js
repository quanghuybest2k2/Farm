import React, { useEffect, useState } from 'react'
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
} from '@coreui/react'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'
import config from '../../config'
import axios from 'axios'
import { useNavigate } from 'react-router-dom'

const CreateConfig = () => {
  const [loading, setLoading] = useState(true)
  const today = new Date()
  const [startDate, setStartDate] = useState(today)
  const [endDate, setEndDate] = useState(null)
  const [farms, setFarms] = useState([])
  // chọn thiết bị
  const [selectedDevices, setSelectedDevices] = useState([])
  const [disabledOption, setDisabledOption] = useState(false)
  const navigate = useNavigate()
  const [schedule, setSchedule] = useState({
    type: 0,
    startValue: 0,
    endValue: 0,
    startDate: '',
    endDate: '',
    isActive: false,
    farmId: 0,
  })

  useEffect(() => {
    axios
      .get(`${config.API_URL}/farms`)
      .then((response) => {
        // console.log(response.data.results)
        setFarms(response.data.results)
        setLoading(false)
      })
      .catch((error) => {
        console.error('Error fetching schedules:', error)
        setLoading(false)
      })
  }, [])

  // xử lý chọn thiết bị
  const handleDeviceChange = (deviceId) => {
    if (!selectedDevices.includes(deviceId)) {
      setSelectedDevices([...selectedDevices, deviceId])
      setDisabledOption(true)
    }
  }

  // reset chọn thiết bị
  const resetSelectedDevices = () => {
    setSelectedDevices([])
    setDisabledOption(false)
  }

  const handleInput = (e) => {
    e.persist()
    setSchedule({ ...schedule, [e.target.name]: e.target.value })
  }
  // api tạo mới
  const submitForm = (e) => {
    e.preventDefault()

    const data = {
      type: schedule.type,
      startValue: schedule.startValue,
      endValue: schedule.endValue,
      startDate: schedule.startDate,
      endDate: schedule.endDate,
      isActive: schedule.isActive,
      farmId: schedule.farmId,
    }
    axios
      .post(`${config.API_URL}/schedules`, data)
      .then((res) => {
        alert('Thành công')
        navigate('#/auto-config')
        setLoading(false)
      })
      .catch((error) => {
        console.error('Error created schedules:', error)
        setLoading(false)
      })
  }

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
                  Tạo lập lịch cấu hình tự động thay cho việc <code>Bật/Tắt</code> thủ công.
                </p>
                <CForm onSubmit={submitForm}>
                  <CRow className="mb-3">
                    <CFormLabel className="col-sm-2 col-form-label">Loại</CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect size="large" className="mb-3" aria-label="Chọn loại">
                        <option disabled>Chọn loại</option>
                        <option value="1">Nhiệt độ</option>
                        <option value="2">Độ ẩm</option>
                        <option value="3">Độ sáng</option>
                      </CFormSelect>
                    </CCol>
                  </CRow>
                  <CRow className="mb-3">
                    <CFormLabel className="col-sm-2 col-form-label">Khu vực</CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect size="large" className="mb-3" aria-label="Chọn khu vực">
                        <option disabled>Chọn khu vực</option>
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
                    <CFormLabel className="col-sm-2 col-form-label">Thiết bị</CFormLabel>
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
                          farm.devices.map((device) => (
                            <option value={device.id} key={device.id}>
                              {device.name}
                            </option>
                          )),
                        )}
                      </CFormSelect>
                      <CFormSelect size="large" className="mb-3" aria-label="Chọn trạng thái">
                        <option value="selectStatus">Chọn trạng thái</option>
                        <option value="false">Tắt</option>
                        <option value="true">Bật</option>
                      </CFormSelect>
                      {/* Danh sách chọn */}
                      <ul>
                        {selectedDevices.map((deviceId) => {
                          const device = farms
                            .flatMap((farm) => farm.devices)
                            .find((device) => device.id === deviceId)
                          return <li key={device.id}>{device.name}</li>
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
                          <CFormInput type="number" placeholder="Nhập giá trị bắt đầu...." />
                        </div>
                        <span className="text-muted mt-4">-</span>
                        <div className="ms-2">
                          <h6 className="mb-3">
                            Đến giá trị <code>(số nguyên)</code>
                          </h6>
                          <CFormInput type="number" placeholder="Nhập giá trị kết thúc...." />
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
                            selected={startDate}
                            onChange={(date) => setStartDate(date)}
                            selectsStart
                            startDate={startDate}
                            endDate={endDate}
                            minDate={today}
                            withPortal
                            portalId="root-portal"
                            placeholderText="Chọn ngày bắt đầu"
                            className="form-control"
                            dateFormat="dd/MM/yyyy"
                          />
                        </div>
                        <span className="text-muted mt-4">-</span>
                        <div className="ms-2">
                          <h6 className="mb-3">Đến ngày</h6>
                          <DatePicker
                            selected={endDate}
                            onChange={(date) => setEndDate(date)}
                            selectsEnd
                            startDate={startDate}
                            endDate={endDate}
                            minDate={startDate || today}
                            withPortal
                            portalId="root-portal"
                            placeholderText="Chọn ngày kết thúc"
                            className="form-control"
                            dateFormat="dd/MM/yyyy"
                          />
                        </div>
                      </div>
                    </CCol>
                  </CRow>
                  <CRow className="mt-4">
                    <CFormLabel className="col-sm-2 col-form-label">Tình trạng</CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect size="large" className="mb-3" aria-label="Chọn giá trị">
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
  )
}

export default CreateConfig
