import React, { useEffect, useState } from 'react'
import { subDays, format, startOfDay, endOfDay } from 'date-fns'
import classNames from 'classnames'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'

import {
  CButton,
  CCard,
  CCardBody,
  CCardFooter,
  CCol,
  CProgress,
  CRow,
  CCardHeader,
  CDropdownToggle,
  CDropdown,
  CDropdownMenu,
  CDropdownItem,
} from '@coreui/react'
import CIcon from '@coreui/icons-react'
import { cilCloudDownload } from '@coreui/icons'

import StatisticalChart from './StatisticalChart'
import config from '../../config'
import axios from 'axios'
import DataTypeEnum from '../../DataTypeEnum'
import StatisticsBySpecificDate from './StatisticsBySpecificDate'

const Statistical = () => {
  const [startDate, setStartDate] = useState(null)
  const [endDate, setEndDate] = useState(null)
  const [statistics, setStatistics] = useState(null)
  const [selectedValue, setSelectedValue] = useState(DataTypeEnum.TEMPERATURE)
  const [selectedLocationValue, setSelectedLocationValue] = useState(
    DataTypeEnum.SENSORLOCATION.KV2,
  )
  // choose date specific
  const [selectedDate, setSelectedDate] = useState(null)
  const [statisticsSpecificDate, setStatisticsSpecificDate] = useState(null)

  const handleItemClick = (value) => {
    setSelectedValue(value)
  }

  const handleLocationClick = (value) => {
    Swal.fire({
      title: 'Information',
      text: `You click ${value}`,
      icon: 'info',
      confirmButtonText: 'OK',
      timer: 1500,
    })
    setSelectedLocationValue(value)
  }

  const progressExample = [
    { title: 'Visits', value: '29.703 Users', percent: 40, color: 'success' },
    { title: 'Unique', value: '24.093 Users', percent: 20, color: 'info' },
    { title: 'Pageviews', value: '78.706 Views', percent: 60, color: 'warning' },
    { title: 'New Users', value: '22.123 Users', percent: 80, color: 'danger' },
    { title: 'Bounce Rate', value: 'Average Rate', percent: 40.15, color: 'primary' },
  ]

  const sensorLocation = DataTypeEnum.SENSORLOCATION.KV2
  const startDateBefore7Day = subDays(startOfDay(new Date()), 7)
  const endDateNow = endOfDay(new Date())

  // call api
  const fetchData = async () => {
    const formattedStartDate = startDate
      ? format(startDate, 'yyyy-MM-dd')
      : format(startDateBefore7Day, 'yyyy-MM-dd')
    const formattedEndDate = endDate
      ? format(endDate, 'yyyy-MM-dd')
      : format(endDateNow, 'yyyy-MM-dd')

    // choose date specific
    const formattedSelectedDate = selectedDate
      ? format(selectedDate, 'yyyy-MM-dd')
      : format(endDateNow, 'yyyy-MM-dd')

    console.log('start: ' + formattedStartDate)
    console.log('end: ' + formattedEndDate)
    console.log('choose date: ' + formattedSelectedDate)

    await axios
      .get(
        `${config.API_URL}/environments/daily-averages?sensorLocation=${sensorLocation}&startDate=${formattedStartDate}&endDate=${formattedEndDate}`,
      )
      .then((res) => {
        // console.log(res.data)
        if (res.data) {
          setStatistics(res.data)
        } else {
          setStatistics([])
        }
      })

    await axios
      .get(
        `${config.API_URL}/environments/specifieddate?sensorLocation=${sensorLocation}&date=${formattedSelectedDate}`,
      )
      .then((res) => {
        console.log(res.data)
        if (res.data) {
          setStatisticsSpecificDate(res.data)
        } else {
          setStatisticsSpecificDate([])
        }
      })

    // log
    console.log('APIs called')
  }

  useEffect(() => {
    // call
    fetchData()

    const millisecond = 5000
    const interval = setInterval(fetchData, millisecond)
    return () => clearInterval(interval)
  }, [startDate, endDate, selectedDate])

  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          <h4>Search</h4>
        </CCardHeader>
        <CCardBody>
          <div className="d-flex justify-content-between align-items-center mb-3">
            <div className="col-2">
              <h4>Khu vực</h4>
            </div>
            <div className="col-10">
              <CDropdown className="align-self-start">
                <CDropdownToggle color="success">
                  {selectedLocationValue || DataTypeEnum.SENSORLOCATION.KV2}
                </CDropdownToggle>
                <CDropdownMenu>
                  <CDropdownItem
                    onClick={() => handleLocationClick(DataTypeEnum.SENSORLOCATION.KV1)}
                  >
                    KV1
                  </CDropdownItem>
                  <CDropdownItem
                    onClick={() => handleLocationClick(DataTypeEnum.SENSORLOCATION.KV2)}
                  >
                    KV2
                  </CDropdownItem>
                  <CDropdownItem
                    onClick={() => handleLocationClick(DataTypeEnum.SENSORLOCATION.KV3)}
                  >
                    KV3
                  </CDropdownItem>
                </CDropdownMenu>
              </CDropdown>
            </div>
          </div>
          <CRow className="mb-4">
            <CCol sm={5}>
              <div className="d-flex mt-3 align-items-center">
                <div className="me-2">
                  <h6 className="mb-3">From date</h6>
                  <DatePicker
                    selected={startDate ?? startDateBefore7Day}
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
            <CCol sm={5}>
              <div className="d-flex mt-3 align-items-center">
                <div className="me-2">
                  <h6 className="mb-3">Statistics by</h6>
                  <CDropdown>
                    <CDropdownToggle color="primary">
                      {selectedValue || DataTypeEnum.TEMPERATURE}
                    </CDropdownToggle>
                    <CDropdownMenu>
                      <CDropdownItem onClick={() => handleItemClick(DataTypeEnum.TEMPERATURE)}>
                        Temperature
                      </CDropdownItem>
                      <CDropdownItem onClick={() => handleItemClick(DataTypeEnum.HUMIDITY)}>
                        Humidity
                      </CDropdownItem>
                      <CDropdownItem onClick={() => handleItemClick(DataTypeEnum.BRIGHTNESS)}>
                        Brightness
                      </CDropdownItem>
                    </CDropdownMenu>
                  </CDropdown>
                </div>
              </div>
            </CCol>
            <CCol sm={2}>
              <CButton color="primary" className="float-end">
                <CIcon icon={cilCloudDownload} />
              </CButton>
            </CCol>
          </CRow>
          <StatisticalChart data={statistics} dataType={selectedValue} />
          <div className="d-flex justify-content-between align-items-center mb-3">
            <div className="col-2">
              <h4>Specific date</h4>
              <CRow className="mb-4">
                <CCol sm={12}>
                  <div className="d-flex mt-3 align-items-center">
                    <div className="me-2">
                      <h6 className="mb-3">Choose date</h6>
                      <DatePicker
                        selected={selectedDate ?? endDateNow}
                        onChange={(date) => setSelectedDate(date)}
                        maxDate={endDateNow}
                        withPortal
                        portalId="root-portal"
                        placeholderText="Choose date"
                        className="form-control"
                        dateFormat="dd/MM/yyyy"
                      />
                    </div>
                  </div>
                </CCol>
              </CRow>
            </div>
          </div>
          <StatisticsBySpecificDate data={statisticsSpecificDate} />
        </CCardBody>
      </CCard>
    </>
  )
}

export default Statistical
