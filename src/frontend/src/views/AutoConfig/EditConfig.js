import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { useParams } from 'react-router-dom'
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
} from '@coreui/react'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'
import { subDays, format, startOfDay, endOfDay, parseISO } from 'date-fns'
import axios from 'axios'
import config from '../../config'

const EditConfig = () => {
  const navigate = useNavigate()
  const [loading, setLoading] = useState(true)
  const [schedule, setSchedule] = useState(null)
  const today = new Date()
  const [startDate, setStartDate] = useState(today)
  const [endDate, setEndDate] = useState(null)
  // id from url
  const { id } = useParams()

  useEffect(() => {
    axios
      .get(`${config.API_URL}/schedules/${id}`)
      .then((response) => {
        console.log(response.data)
        setSchedule(response.data)
        setLoading(false)
      })
      .catch((error) => {
        console.error('Error fetching schedules:', error)
        setLoading(false)
      })
  }, [])

  const handleSubmit = async (e) => {
    e.preventDefault()
    try {
      const updatedSchedule = {
        type: parseInt(schedule.type),
        status: schedule.status,
        startValue: parseInt(schedule.startValue),
        endValue: parseInt(schedule.endValue),
        startDate: schedule.startDate,
        endDate: schedule.endDate,
        isActive: schedule.isActive,

        farmId: '140e8470-86ec-4e10-b28e-cb94d9165c54',
        deviceId: '8a8bd086-1167-4d69-93a4-351317c20080',
        // farmId: schedule.farmId,
        // deviceId: schedule.deviceId,
      }

      await axios.put(`${config.API_URL}/schedules/${id}`, updatedSchedule).then((res) => {
        alert('Update successfully')
        navigate('/auto-config')
      })
    } catch (error) {
      console.error('Error updating schedule:', error)
    }
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
            <p className="text-body-secondary small">
              Sửa lập lịch cấu hình tự động thay cho việc <code>Bật/Tắt</code> thủ công.
            </p>
            <CForm>
              {schedule && (
                <>
                  <CRow className="mb-3">
                    <CFormLabel className="col-sm-2 col-form-label">Loại</CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect
                        size="large"
                        className="mb-3"
                        aria-label="Select status"
                        value={schedule.type}
                        onChange={(e) => setSchedule({ ...schedule, type: e.target.value })}
                      >
                        <option>Select Type</option>
                        <option value="1">Nhiệt độ</option>
                        <option value="2">Độ ẩm</option>
                        <option value="3">Độ sáng</option>
                      </CFormSelect>
                    </CCol>
                  </CRow>
                  <CRow className="mb-3">
                    <CFormLabel className="col-sm-2 col-form-label">Khu vực</CFormLabel>
                    <CCol sm={10}>
                      <CFormInput
                        type="text"
                        placeholder="Nhập khu vực...."
                        value={schedule.farm.name}
                      />
                    </CCol>
                  </CRow>
                  <CRow className="mb-3">
                    <CFormLabel className="col-sm-2 col-form-label">Thiết bị</CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect
                        size="large"
                        className="mb-3"
                        aria-label="Chọn thiết bị"
                        value={schedule.farm.devices.map((device) => device.order)}
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
                    <CFormLabel className="col-sm-2 col-form-label">Trạng thái</CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect
                        size="large"
                        className="mb-3"
                        aria-label="Chọn trạng thái"
                        value={schedule.status ? '1' : '0'}
                        onChange={(e) =>
                          setSchedule({
                            ...schedule,
                            status: e.target.value === '1' ? true : false,
                          })
                        }
                      >
                        <option>Chọn trạng thái</option>
                        <option value="0">Tắt</option>
                        <option value="1">Bật</option>
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
                            value={schedule.startValue}
                            onChange={(e) =>
                              setSchedule({
                                ...schedule,
                                startValue: e.target.value,
                              })
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
                            value={schedule.endValue}
                            onChange={(e) =>
                              setSchedule({
                                ...schedule,
                                endValue: e.target.value,
                              })
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
                            selected={parseISO(schedule.startDate)}
                            onChange={(date) => setStartDate(date)}
                            selectsStart
                            startDate={parseISO(schedule.startDate)}
                            endDate={endDate}
                            minDate={today}
                            withPortal
                            portalId="root-portal"
                            placeholderText="Chọn ngày bắt đầu"
                            className="form-control"
                            dateFormat="dd/MM/yyyy HH:mm:ss"
                          />
                        </div>
                        <span className="text-muted mt-4">-</span>
                        <div className="ms-2">
                          <h6 className="mb-3">Đến ngày</h6>
                          <DatePicker
                            selected={parseISO(schedule.endDate)}
                            onChange={(date) => setEndDate(date)}
                            selectsEnd
                            startDate={startDate}
                            endDate={endDate}
                            minDate={startDate || today}
                            withPortal
                            portalId="root-portal"
                            placeholderText="Chọn ngày kết thúc"
                            className="form-control"
                            dateFormat="dd/MM/yyyy HH:mm:ss"
                          />
                        </div>
                      </div>
                    </CCol>
                  </CRow>
                  <CRow className="mt-4">
                    <CFormLabel className="col-sm-2 col-form-label">Kích hoạt</CFormLabel>
                    <CCol sm={10}>
                      <CFormSelect
                        size="large"
                        className="mb-3"
                        aria-label="Chọn giá trị"
                        value={schedule.isActive ? '1' : '0'}
                        onChange={(e) =>
                          setSchedule({
                            ...schedule,
                            isActive: e.target.value === '1' ? true : false,
                          })
                        }
                      >
                        <option>Chọn giá trị</option>
                        <option value="0">Tắt</option>
                        <option value="1">Bật</option>
                      </CFormSelect>
                    </CCol>
                  </CRow>
                  <CCol className="mt-3">
                    <CButton color="primary" type="submit" onClick={handleSubmit}>
                      Cập nhật
                    </CButton>
                  </CCol>
                </>
              )}
            </CForm>
          </CCardBody>
        </CCard>
      </CCol>
    </CRow>
  )
}

export default EditConfig
