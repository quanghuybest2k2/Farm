import React, { useState, useEffect } from 'react'
import axios from 'axios'
import config from '../../config'
import { format } from 'date-fns'
import Swal from 'sweetalert2'
import CIcon from '@coreui/icons-react'
import {
  CCard,
  CCardBody,
  CCardHeader,
  CCol,
  CRow,
  CTable,
  CTableBody,
  CTableDataCell,
  CTableHead,
  CTableHeaderCell,
  CTableRow,
  CButton,
  CLink,
  CTooltip,
  CButtonGroup,
  CDropdown,
  CDropdownToggle,
  CDropdownMenu,
  CDropdownItem,
  CFormLabel,
  CModal,
  CModalBody,
  CModalHeader,
  CModalFooter,
  CModalTitle,
  CBadge,
} from '@coreui/react'

import { cilTrash, cilColorBorder, cilPlus, cilInfo } from '@coreui/icons'

const AutoConfig = () => {
  const [loading, setLoading] = useState(true)
  const [selectedValue, setSelectedValue] = useState(null)
  // visible show model
  const [visible, setVisible] = useState(false)
  // list item
  const [schedules, setSchedules] = useState([])
  let stt = 1
  const [scheduleId, setScheduleId] = useState(null)

  // show record per page
  const handleItemClick = (value) => {
    setSelectedValue(value)
  }

  // get all Schedules
  const getSchedules = () => {
    axios
      .get(`${config.API_URL}/schedules`)
      .then((response) => {
        // console.log(response.data.results)
        setSchedules(response.data.results)
        setLoading(false)
      })
      .catch((error) => {
        console.error('Error fetching schedules:', error)
        setLoading(false)
      })
  }

  useEffect(() => {
    getSchedules()
  }, [])

  // xóa lập lịch
  const deleteSchedule = (id) => {
    setScheduleId(id)
    setVisible(true)
  }

  // xử lý xác nhận xóa
  const handleDeleteConfirmed = (id) => {
    axios
      .delete(`${config.API_URL}/schedules/${id}`)
      .then((res) => {
        Swal.fire({
          icon: 'success',
          text: 'Xóa thành công',
          showConfirmButton: false,
          position: 'top-end',
          toast: true,
          timer: 2000,
          showClass: {
            popup: `
                animate__animated
                animate__fadeInRight
                animate__faster
            `,
          },
        })
        getSchedules()
        setVisible(false)
      })
      .catch((error) => {
        console.error('Error deleted schedule:', error)
        setLoading(false)
      })
  }

  return (
    <>
      <CRow>
        <CCol xs>
          <CCard className="mb-4">
            <CCardHeader>Cấu hình tự động</CCardHeader>
            <CCardBody>
              <p className="text-body-secondary small">
                Thông tin căn bản của <code>thiết bị</code>
                <CLink href={'#auto-config/create'}>
                  <CButton color="success" type="button" size="sm" className="float-end">
                    <CIcon icon={cilPlus} />
                    Tạo mới
                  </CButton>
                </CLink>
              </p>
              <CTable responsive>
                <CTableHead>
                  <CTableRow>
                    <CTableHeaderCell scope="col">STT</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Loại</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Khu vực</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Số thiết bị</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Từ giá trị</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Đến giá trị</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Từ ngày</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Đến ngày</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Tình trạng</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Thao tác</CTableHeaderCell>
                  </CTableRow>
                </CTableHead>
                <CTableBody>
                  {loading ? (
                    <CTableRow>
                      <CTableDataCell colSpan="11">Loading...</CTableDataCell>
                    </CTableRow>
                  ) : schedules.length === 0 ? (
                    <CTableRow>
                      <CTableDataCell colSpan="11">
                        Hiện tại chưa có lịch. Bạn có thể bắt đầu bằng cách tạo lịch mới!
                      </CTableDataCell>
                    </CTableRow>
                  ) : (
                    schedules.map((schedule) => (
                      <CTableRow key={schedule.id}>
                        <CTableHeaderCell scope="row">{stt++}</CTableHeaderCell>
                        <CTableDataCell>
                          {schedule.type === 1
                            ? 'Nhiệt độ'
                            : schedule.type === 2
                              ? 'Độ ẩm'
                              : 'Độ sáng'}
                        </CTableDataCell>
                        <CTableDataCell>{schedule.farmName}</CTableDataCell>
                        <CTableDataCell>{schedule.deviceSchedules.length}</CTableDataCell>
                        <CTableDataCell>{schedule.startValue}</CTableDataCell>
                        <CTableDataCell>{schedule.endValue}</CTableDataCell>
                        <CTableDataCell>
                          {format(new Date(schedule.startDate), 'dd/MM/yyyy HH:mm:ss')}
                        </CTableDataCell>
                        <CTableDataCell>
                          {format(new Date(schedule.endDate), 'dd/MM/yyyy HH:mm:ss')}
                        </CTableDataCell>
                        <CTableDataCell>
                          <CBadge color={schedule.isActive ? 'success' : 'danger'}>
                            {schedule.isActive ? 'Đang hoạt động' : 'Không hoạt động'}
                          </CBadge>
                        </CTableDataCell>
                        <CTableDataCell>
                          <CButtonGroup role="group" aria-label="Basic mixed styles example">
                            <CCol xs={5}>
                              <CTooltip content="Xem chi tiết">
                                <CLink href={`#auto-config/detail/${schedule.id}`}>
                                  <CButton color="info" type="button" size="sm">
                                    <CIcon icon={cilInfo} />
                                  </CButton>
                                </CLink>
                              </CTooltip>
                            </CCol>
                            <CCol xs={5}>
                              <CTooltip content="Sửa">
                                <CLink href={`#auto-config/edit/${schedule.id}`}>
                                  <CButton color="warning" type="button" size="sm">
                                    <CIcon icon={cilColorBorder} />
                                  </CButton>
                                </CLink>
                              </CTooltip>
                            </CCol>
                            <CCol xs={5}>
                              <CTooltip content="Xóa">
                                <CButton
                                  color="danger"
                                  type="button"
                                  size="sm"
                                  onClick={() => deleteSchedule(schedule.id)}
                                >
                                  <CIcon icon={cilTrash} />
                                </CButton>
                              </CTooltip>
                            </CCol>
                          </CButtonGroup>
                        </CTableDataCell>
                      </CTableRow>
                    ))
                  )}
                </CTableBody>
              </CTable>
              <br />
              <CFormLabel style={{ marginRight: '10px' }}>Hiển thị</CFormLabel>
              <CDropdown>
                <CDropdownToggle color="primary">{selectedValue || '10'}</CDropdownToggle>
                <CDropdownMenu>
                  <CDropdownItem onClick={() => handleItemClick('10')}>10</CDropdownItem>
                  <CDropdownItem onClick={() => handleItemClick('20')}>20</CDropdownItem>
                  <CDropdownItem onClick={() => handleItemClick('30')}>30</CDropdownItem>
                </CDropdownMenu>
              </CDropdown>
              <CFormLabel style={{ marginLeft: '10px' }}>bản ghi trên trang</CFormLabel>
            </CCardBody>
          </CCard>
        </CCol>
      </CRow>
      {/* model show */}
      <CModal
        backdrop="static"
        visible={visible}
        onClose={() => setVisible(false)}
        aria-labelledby="Xóa lịch"
      >
        <CModalHeader>
          <CModalTitle>Bạn có chắc muốn xóa mục này?</CModalTitle>
        </CModalHeader>
        <CModalBody>Dữ liệu sẽ không thể khôi phục. Bạn có muốn tiếp tục?</CModalBody>
        <CModalFooter>
          <CButton color="primary" onClick={() => handleDeleteConfirmed(scheduleId)}>
            Xác nhận
          </CButton>

          <CButton color="secondary" onClick={() => setVisible(false)}>
            Hủy bỏ
          </CButton>
        </CModalFooter>
      </CModal>
    </>
  )
}

export default AutoConfig
