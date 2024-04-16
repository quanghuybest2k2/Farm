import { CCard, CCardBody, CCol, CRow, CCardHeader, CFormSwitch } from '@coreui/react'
import CustomCheckbox from './CustomCheckbox'
import React, { useEffect, useState } from 'react'
import InformationEnvironment from '../widgets/InformationEnvironment'
import CIcon from '@coreui/icons-react'
import { cibDiscover } from '@coreui/icons'
// dalat maps
import MyMap from './MyMap'
import axios from 'axios'
import config from '../../config'

const GreenhouseA1 = () => {
  const [devices, setDevices] = useState([
    {
      id: '2e0c9661-6b21-4a1f-ab34-2b10c238bd2d',
      name: 'Quạt 7',
      type: 'fan',
      status: false,
      order: 6,
      createAt: null,
      updateAt: null,
      controllerCode: 'esp8266/ledControl',
      farmId: 'adaf9b85-edaa-4029-adfa-abc59f230d98',
    },
    {
      id: '50ec967c-fac0-40a7-b08b-7bbbd1121dcc',
      name: 'Đèn 1',
      type: 'lamp',
      status: false,
      order: 0,
      createAt: null,
      updateAt: null,
      controllerCode: 'esp8266/ledControl',
      farmId: 'adaf9b85-edaa-4029-adfa-abc59f230d98',
    },
    {
      id: 'a89d9828-7289-45ff-b84c-848f41862c2c',
      name: 'Quạt 8',
      type: 'fan',
      status: false,
      order: 7,
      createAt: null,
      updateAt: null,
      controllerCode: 'esp8266/ledControl',
      farmId: 'adaf9b85-edaa-4029-adfa-abc59f230d98',
    },
    {
      id: 'b802af41-c3b5-47eb-b714-8a148328f652',
      name: 'Đèn 2',
      type: 'lamp',
      status: false,
      order: 1,
      createAt: null,
      updateAt: null,
      controllerCode: 'esp8266/ledControl',
      farmId: 'adaf9b85-edaa-4029-adfa-abc59f230d98',
    },
    {
      id: '71ab5c65-0784-4d6e-a890-8bf2589fc1f5',
      name: 'Quạt 6',
      type: 'fan',
      status: false,
      order: 5,
      createAt: null,
      updateAt: null,
      controllerCode: 'esp8266/ledControl',
      farmId: 'adaf9b85-edaa-4029-adfa-abc59f230d98',
    },
    {
      id: '5a85de82-fc97-4081-9b83-97c3c953cfa7',
      name: 'Quạt 5',
      type: 'fan',
      status: false,
      order: 4,
      createAt: null,
      updateAt: null,
      controllerCode: 'esp8266/ledControl',
      farmId: 'adaf9b85-edaa-4029-adfa-abc59f230d98',
    },
    {
      id: '8dc5c8ed-f5be-4a93-8693-9a5a704938b8',
      name: 'Đèn 4',
      type: 'lamp',
      status: false,
      order: 3,
      createAt: null,
      updateAt: null,
      controllerCode: 'esp8266/ledControl',
      farmId: 'adaf9b85-edaa-4029-adfa-abc59f230d98',
    },
    {
      id: 'bb27e980-7810-4ee0-9839-dc6540f3fd72',
      name: 'Đèn 3',
      type: 'lamp',
      status: false,
      order: 2,
      createAt: null,
      updateAt: null,
      controllerCode: 'esp8266/ledControl',
      farmId: 'adaf9b85-edaa-4029-adfa-abc59f230d98',
    },
  ])

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
