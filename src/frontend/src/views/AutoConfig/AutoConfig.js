import React, { useState, useEffect } from 'react'
import axios from 'axios'
import config from '../../config'
import { format } from 'date-fns'
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
} from '@coreui/react'

import { cilTrash, cilColorBorder, cilCheckCircle, cilXCircle, cilPlus } from '@coreui/icons'

const AutoConfig = () => {
  const [loading, setLoading] = useState(true)
  const [selectedValue, setSelectedValue] = useState(null)
  // visible show model
  const [visible, setVisible] = useState(false)
  // list item
  const [schedules, setSchedules] = useState([])

  // show record per page
  const handleItemClick = (value) => {
    setSelectedValue(value)
  }

  useEffect(() => {
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
  }, [])

  return (
    <>
      <CRow>
        <CCol xs>
          <CCard className="mb-4">
            <CCardHeader>Automatic Configuration</CCardHeader>
            <CCardBody>
              <p className="text-body-secondary small">
                Basic information for the <code>Device</code>
                <CLink href={'#auto-config/create'}>
                  <CButton color="success" type="button" size="sm" className="float-end">
                    <CIcon icon={cilPlus} />
                    <text>Create New</text>
                  </CButton>
                </CLink>
              </p>
              <CTable responsive>
                <CTableHead>
                  <CTableRow>
                    <CTableHeaderCell scope="col">STT</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Type</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Area</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Device name</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Device status</CTableHeaderCell>
                    <CTableHeaderCell scope="col">From value</CTableHeaderCell>
                    <CTableHeaderCell scope="col">To value</CTableHeaderCell>
                    <CTableHeaderCell scope="col">From date</CTableHeaderCell>
                    <CTableHeaderCell scope="col">To date</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Is Active</CTableHeaderCell>
                    <CTableHeaderCell scope="col">Action</CTableHeaderCell>
                  </CTableRow>
                </CTableHead>
                <CTableBody>
                  {loading ? (
                    <CTableRow>
                      <CTableDataCell colSpan="11">Loading...</CTableDataCell>
                    </CTableRow>
                  ) : (
                    schedules.map((schedule) => (
                      <CTableRow key={schedule.id}>
                        <CTableHeaderCell scope="row">1</CTableHeaderCell>
                        <CTableDataCell>
                          {schedule.type === 1
                            ? 'Nhiệt độ'
                            : schedule.type === 2
                              ? 'Độ ẩm'
                              : 'Độ sáng'}
                        </CTableDataCell>
                        <CTableDataCell>{schedule.farm.name}</CTableDataCell>
                        <CTableDataCell>
                          {schedule.farm.devices.map((device) => (
                            <text key={device.id}>{device.name}</text>
                          ))}
                        </CTableDataCell>
                        <CTableDataCell>
                          {schedule.status ? (
                            <CIcon icon={cilCheckCircle} style={{ background: 'green' }} />
                          ) : (
                            <CIcon icon={cilXCircle} style={{ background: 'red' }} />
                          )}
                        </CTableDataCell>
                        <CTableDataCell>{schedule.startValue}</CTableDataCell>
                        <CTableDataCell>{schedule.endValue}</CTableDataCell>
                        <CTableDataCell>
                          {format(new Date(schedule.startDate), 'dd/MM/yyyy HH:mm:ss')}
                        </CTableDataCell>
                        <CTableDataCell>
                          {format(new Date(schedule.endDate), 'dd/MM/yyyy HH:mm:ss')}
                        </CTableDataCell>
                        <CTableDataCell>
                          {schedule.isActive ? (
                            <CIcon icon={cilCheckCircle} style={{ background: 'green' }} />
                          ) : (
                            <CIcon icon={cilXCircle} style={{ background: 'red' }} />
                          )}
                        </CTableDataCell>
                        <CTableDataCell>
                          <CButtonGroup role="group" aria-label="Basic mixed styles example">
                            <CCol xs={8}>
                              <CTooltip content="Edit">
                                <CLink href="#auto-config/edit/1">
                                  <CButton color="warning" type="button" size="sm">
                                    <CIcon icon={cilColorBorder} />
                                  </CButton>
                                </CLink>
                              </CTooltip>
                            </CCol>
                            <CCol xs={8}>
                              <CTooltip content="Delete">
                                <CLink>
                                  <CButton
                                    color="danger"
                                    type="button"
                                    size="sm"
                                    onClick={() => setVisible(!visible)}
                                  >
                                    <CIcon icon={cilTrash} />
                                  </CButton>
                                </CLink>
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
              <CFormLabel style={{ marginRight: '10px' }}>Show</CFormLabel>
              <CDropdown>
                <CDropdownToggle color="primary">{selectedValue || '10'}</CDropdownToggle>
                <CDropdownMenu>
                  <CDropdownItem onClick={() => handleItemClick('10')}>10</CDropdownItem>
                  <CDropdownItem onClick={() => handleItemClick('20')}>20</CDropdownItem>
                  <CDropdownItem onClick={() => handleItemClick('30')}>30</CDropdownItem>
                </CDropdownMenu>
              </CDropdown>
              <CFormLabel style={{ marginLeft: '10px' }}>entices</CFormLabel>
            </CCardBody>
          </CCard>
        </CCol>
      </CRow>
      {/* model show */}
      <CModal
        backdrop="static"
        visible={visible}
        onClose={() => setVisible(false)}
        aria-labelledby="StaticBackdropExampleLabel"
      >
        <CModalHeader>
          <CModalTitle id="StaticBackdropExampleLabel">
            Are you sure you want to delete this item?
          </CModalTitle>
        </CModalHeader>
        <CModalBody>
          The data will be permanently deleted. Do you really want to continue?
        </CModalBody>
        <CModalFooter>
          <CButton color="primary">Submit</CButton>
          <CButton color="secondary" onClick={() => setVisible(false)}>
            Cancel
          </CButton>
        </CModalFooter>
      </CModal>
    </>
  )
}

export default AutoConfig
