import React, { useEffect, useRef, useState } from 'react'
import PropTypes from 'prop-types'

import {
  CRow,
  CCol,
  CDropdown,
  CDropdownMenu,
  CDropdownItem,
  CDropdownToggle,
  CWidgetStatsA,
  CCardLink,
} from '@coreui/react'
import { getStyle } from '@coreui/utils'
import CIcon from '@coreui/icons-react'
import { cilArrowTop, cilOptions, cilBrightness, cilDrop } from '@coreui/icons'
import DataTypeEnum from '../../DataTypeEnum'
import axios from 'axios'
import config from '../../config'

const InformationEnvironment = (props) => {
  const widgetChartRef1 = useRef(null)
  const widgetChartRef2 = useRef(null)
  const [selectedLocationValue, setSelectedLocationValue] = useState(
    DataTypeEnum.SENSORLOCATION.KV2,
  )
  const [environment, setEnvironment] = useState(null)

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

  useEffect(() => {
    document.documentElement.addEventListener('ColorSchemeChange', () => {
      if (widgetChartRef1.current) {
        setTimeout(() => {
          widgetChartRef1.current.data.datasets[0].pointBackgroundColor = getStyle('--cui-primary')
          widgetChartRef1.current.update()
        })
      }

      if (widgetChartRef2.current) {
        setTimeout(() => {
          widgetChartRef2.current.data.datasets[0].pointBackgroundColor = getStyle('--cui-info')
          widgetChartRef2.current.update()
        })
      }
    })
  }, [widgetChartRef1, widgetChartRef2])

  const sensorLocation = DataTypeEnum.SENSORLOCATION.KV2

  // call api
  const fetchData = async () => {
    await axios
      .get(`${config.API_URL}/environments/real-time?sensorLocation=${sensorLocation}`)
      .then((res) => {
        // console.log(res.data)
        if (res.data) {
          setEnvironment(res.data)
        } else {
          setEnvironment([])
        }
      })

    // log
    // console.log('APIs called')
  }

  useEffect(() => {
    // call
    fetchData()

    const millisecond = 5000
    const interval = setInterval(fetchData, millisecond)
    return () => clearInterval(interval)
  }, [])

  return (
    <CRow className={props.className} xs={{ gutter: 4 }}>
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
              <CDropdownItem onClick={() => handleLocationClick(DataTypeEnum.SENSORLOCATION.KV1)}>
                KV1
              </CDropdownItem>
              <CDropdownItem onClick={() => handleLocationClick(DataTypeEnum.SENSORLOCATION.KV2)}>
                KV2
              </CDropdownItem>
              <CDropdownItem onClick={() => handleLocationClick(DataTypeEnum.SENSORLOCATION.KV3)}>
                KV3
              </CDropdownItem>
            </CDropdownMenu>
          </CDropdown>
        </div>
      </div>
      {environment && (
        <>
          <CCol sm={6} xl={4} xxl={3}>
            <CWidgetStatsA
              className="pb-5"
              color="primary"
              value={
                <>
                  {environment.brightness ?? 0}{' '}
                  <span className="fs-6 fw-normal">
                    (Lux <CIcon icon={cilBrightness} /> )
                  </span>
                </>
              }
              title="Cường độ ánh sáng"
              action={
                <CDropdown alignment="end">
                  <CDropdownToggle color="transparent" caret={false} className="text-white p-0">
                    <CIcon icon={cilOptions} />
                  </CDropdownToggle>
                  <CDropdownMenu>
                    <CDropdownItem>
                      <CCardLink href="#/device-control">See more</CCardLink>
                    </CDropdownItem>
                  </CDropdownMenu>
                </CDropdown>
              }
            />
          </CCol>
          <CCol sm={6} xl={4} xxl={3}>
            <CWidgetStatsA
              className="pb-5"
              color="info"
              value={
                <>
                  {environment.temperature.toFixed(2) ?? 0}{' '}
                  <span className="fs-6 fw-normal">
                    (<sup>o</sup>C <CIcon icon={cilArrowTop} />)
                  </span>
                </>
              }
              title="Nhiệt độ"
              action={
                <CDropdown alignment="end">
                  <CDropdownToggle color="transparent" caret={false} className="text-white p-0">
                    <CIcon icon={cilOptions} />
                  </CDropdownToggle>
                  <CDropdownMenu>
                    <CDropdownItem>
                      <CCardLink href="#/device-control">See more</CCardLink>
                    </CDropdownItem>
                  </CDropdownMenu>
                </CDropdown>
              }
            />
          </CCol>
          <CCol sm={6} xl={4} xxl={3}>
            <CWidgetStatsA
              className="pb-5"
              color="warning"
              value={
                <>
                  {environment.humidity ?? 0}{' '}
                  <span className="fs-6 fw-normal">
                    (% <CIcon icon={cilDrop} />)
                  </span>
                </>
              }
              title="Độ ẩm"
              action={
                <CDropdown alignment="end">
                  <CDropdownToggle color="transparent" caret={false} className="text-white p-0">
                    <CIcon icon={cilOptions} />
                  </CDropdownToggle>
                  <CDropdownMenu>
                    <CDropdownItem>
                      <CCardLink href="#/device-control">See more</CCardLink>
                    </CDropdownItem>
                  </CDropdownMenu>
                </CDropdown>
              }
            />
          </CCol>
        </>
      )}
    </CRow>
  )
}

InformationEnvironment.propTypes = {
  className: PropTypes.string,
  withCharts: PropTypes.bool,
}

export default InformationEnvironment
