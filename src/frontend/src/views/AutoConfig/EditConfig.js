import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
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
import { format } from 'date-fns'
import axios from 'axios'
import config from '../../config'
import Swal from 'sweetalert2'

const EditConfig = () => {
  const navigate = useNavigate()
  const [loading, setLoading] = useState(true)
  const [schedule, setSchedule] = useState({})
  // list item
  const [farms, setFarms] = useState([])
  const today = new Date()
  const [startDate, setStartDate] = useState(today)
  const [endDate, setEndDate] = useState(today)
  // status device
  const [selectedStatus, setSelectedStatus] = useState('')
  // id from url
  const { id } = useParams()

  // get all Schedules
  const getFarms = () => {
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
  }

  useEffect(() => {
    // get all farms
    getFarms()

    axios
      .get(`${config.API_URL}/schedules/${id}`)
      .then((response) => {
        const scheduleData = response.data
        scheduleData.startDate = new Date(scheduleData.startDate)
        scheduleData.endDate = new Date(scheduleData.endDate)
        setSchedule(scheduleData)
        console.log(scheduleData)
        setLoading(false)
      })
      .catch((error) => {
        console.error('Error fetching schedules:', error)
        setLoading(false)
      })
  }, [id])

  // xử lý chọn status của đèn
  const handleStatusChange = (e) => {
    setSelectedStatus(e.target.value)
  }

  // xử lý lấy giá trị của control
  const handleInput = (field, value) => {
    setSchedule({ ...schedule, [field]: value })
  }

  //Chọn ngày giờ start
  const handleStartDateChange = (date) => {
    setStartDate(date)
    setSchedule({ ...schedule, startDate: date })
  }

  //Chọn ngày giờ end
  const handleEndDateChange = (date) => {
    setEndDate(date)
    setSchedule({ ...schedule, endDate: date })
  }

  // xử lý cập nhật
  const handleSubmit = (e) => {
    e.preventDefault()

    // format date
    const formatStartDate = format(startDate, 'yyyy/MM/dd HH:mm:ss') ?? ''
    const formatEndDate = format(endDate, 'yyyy/MM/dd HH:mm:ss') ?? ''

    const data = {
      type: parseInt(schedule.type) ?? 1,
      startValue: parseInt(schedule.startValue),
      endValue: parseInt(schedule.endValue),
      startDate: formatStartDate,
      endDate: formatEndDate,
      isActive: schedule.isActive,
      farmId: schedule.farmId,
      devices: schedule.deviceSchedules.map((device) => ({
        id: device.deviceId,
        statusDevice: selectedStatus === '1',
      })),
    }
    console.log(data)

    // axios
    //   .put(`${config.API_URL}/schedules/${id}`, data)
    //   .then((res) => {
    //     Swal.fire({
    //       icon: 'success',
    //       text: 'Cập nhật thành công',
    //       showConfirmButton: false,
    //       position: 'top-end',
    //       toast: true,
    //       timer: 2000,
    //       showClass: {
    //         popup: `
    //             animate__animated
    //             animate__fadeInRight
    //             animate__faster
    //         `,
    //       },
    //     })
    //     navigate('/auto-config')
    //     setLoading(false)
    //   })
    //   .catch((error) => {
    //     console.error('Error updated schedules:', error)
    //     setLoading(false)
    //   })
  }

  return (
    <CRow>
      <CCol xs={12}>
        <CCard className="mb-4">
          <CCardHeader>
            <strong>Sửa</strong> <small>lịch mới</small>
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
                  Sửa lập lịch cấu hình tự động thay cho việc <code>Bật/Tắt</code> thủ công.
                </p>
                <CForm onSubmit={handleSubmit}>
                  <CRow className="mb-3">
                    <CFormLabel
                      className="col-sm-2 col-form-label"
                      onChange={(e) => handleInput('type', e.target.value)}
                    >
                      Loại
                    </CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect
                        size="large"
                        className="mb-3"
                        aria-label="Chọn loại"
                        onChange={(e) => handleInput('type', e.target.value)}
                        value={schedule.type}
                      >
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
                      <CFormSelect
                        size="large"
                        className="mb-3"
                        aria-label="Chọn khu vực"
                        onChange={(e) => handleInput('farmId', e.target.value)}
                        value={schedule.farmId}
                      >
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
                    <CFormLabel className="col-sm-2 col-form-label">Thiết bị</CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect
                        size="large"
                        className="mb-3"
                        aria-label="Chọn thiết bị"
                        value={schedule.deviceSchedules.map((device) => device.order)}
                      >
                        <option>Select device</option>
                        <option value="0">Đèn 1</option>
                        <option value="1">Đèn 2</option>
                        <option value="2">Đèn 3</option>
                        <option value="3">Đèn 4</option>
                        <option value="4">Quạt 5</option>
                        <option value="5">Quạt 6</option>
                        <option value="6">Quạt 7</option>
                        <option value="7">Quạt 8</option>
                      </CFormSelect>
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
                            onChange={(e) => handleInput('startValue', e.target.value)}
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
                            onChange={(e) => handleInput('endValue', e.target.value)}
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
                            selected={schedule.startDate}
                            onChange={handleStartDateChange}
                            selectsStart
                            minDate={schedule.startDate}
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
                            selected={schedule.endDate}
                            onChange={handleEndDateChange}
                            selectsEnd
                            minDate={today}
                          />
                        </div>
                      </div>
                    </CCol>
                  </CRow>
                  <CRow className="mt-4">
                    <CFormLabel className="col-sm-2 col-form-label">Tình trạng</CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect
                        size="large"
                        className="mb-3"
                        aria-label="Chọn giá trị"
                        onChange={(e) => handleInput('isActive', e.target.value === '1')}
                        value={schedule.isActive ? '1' : '0'}
                      >
                        <option disabled>Chọn giá trị</option>
                        <option value="0">Tắt</option>
                        <option value="1">Bật</option>
                      </CFormSelect>
                    </CCol>
                  </CRow>
                  <CCol className="mt-3">
                    <CButton color="primary" type="submit">
                      Cập nhật
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

export default EditConfig
