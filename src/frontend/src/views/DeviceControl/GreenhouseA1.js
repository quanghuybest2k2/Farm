import { CCard, CCardBody, CCol, CRow, CCardHeader, CFormSwitch } from '@coreui/react'
import CustomCheckbox from './CustomCheckbox'
import React, { useEffect, useState } from 'react'
import InformationEnvironment from '../widgets/InformationEnvironment'
import CIcon from '@coreui/icons-react'
import { cibDiscover } from '@coreui/icons'
import devicesData from './devicesData'
// dalat maps
import MyMap from './MyMap'
import axios from 'axios'
import config from '../../config'

const GreenhouseA1 = () => {
  const [devices, setDevices] = useState(devicesData)

  const [checkboxes, setCheckboxes] = useState({
    parametersAutomatically: false,
    scheduledAutomation: false,
  })

  useEffect(() => {
    const devicesData = JSON.parse(localStorage.getItem('devices'))
    if (devicesData) {
      setDevices(devicesData)
    }
  }, [])

  const controlDevice = (device) => {
    const postData = {
      topicName: device.controllerCode,
      payload: {
        id: device.id,
        status: !device.status,
        order: device.order,
      },
    }

    axios
      .post(`${config.API_URL}/controldevices`, postData)
      .then((response) => {
        const updatedDevices = devices.map((d) => {
          if (d.id === device.id) {
            return { ...d, status: !d.status }
          }
          return d
        })
        setDevices(updatedDevices)
        localStorage.setItem('devices', JSON.stringify(updatedDevices))
      })
      .catch((error) => {
        console.error('Error controlling device:', error)
      })
  }

  const handleCheckboxChange = (checkboxName) => {
    setCheckboxes({
      ...checkboxes,
      [checkboxName]: !checkboxes[checkboxName],
    })
    if (!checkboxes[checkboxName]) {
      alert(`${checkboxName} đã check`)
    } else {
      alert(`${checkboxName} đã bỏ check`)
    }
  }

  return (
    <>
      <InformationEnvironment className="mb-4" />
      <CCard className="mb-4">
        <CCardHeader>
          <code>Greenhouse A1</code>
        </CCardHeader>
        <CCardBody>
          <CRow>
            <CCol sm={6}>
              <CustomCheckbox
                label="Parameters Automatically"
                defaultChecked={checkboxes.parametersAutomatically}
                onChange={() => handleCheckboxChange('parametersAutomatically')}
              />
            </CCol>
            <CCol sm={6}>
              <CustomCheckbox
                label="Scheduled Automation"
                defaultChecked={checkboxes.scheduledAutomation}
                onChange={() => handleCheckboxChange('scheduledAutomation')}
              />
            </CCol>
          </CRow>
          <CRow className="mt-5">
            {devices
              .reduce(
                (rows, key, index) =>
                  (index % 3 === 0 ? rows.push([key]) : rows[rows.length - 1].push(key)) && rows,
                [],
              )
              .map((row, rowIndex) => (
                <CCol sm={6} key={rowIndex}>
                  {row.map((device) => (
                    <CRow key={device.id}>
                      <CCol sm={6}>
                        <div className="form-check form-switch">
                          <input
                            className="form-check-input"
                            type="checkbox"
                            onChange={() => controlDevice(device)}
                            checked={device.status}
                          />
                          <label className="form-check-label">{device.name}</label>
                        </div>
                      </CCol>
                      <CCol sm={6}>
                        <CIcon
                          icon={cibDiscover}
                          size="xl"
                          style={{ color: device.status ? '#249542' : '#db5d5d' }}
                        />
                      </CCol>
                    </CRow>
                  ))}
                </CCol>
              ))}
          </CRow>
        </CCardBody>
      </CCard>
      {/* maps */}
      <CCard className="mb-4">
        <CCardHeader>
          <code>Distribution map</code>
        </CCardHeader>
        <CCardBody>
          <CRow>
            <MyMap />
          </CRow>
        </CCardBody>
      </CCard>
    </>
  )
}

export default GreenhouseA1
