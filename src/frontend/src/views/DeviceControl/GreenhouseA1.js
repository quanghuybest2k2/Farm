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
  const [farms, setFarms] = useState(null)

  const [checkboxes, setCheckboxes] = useState({
    parametersAutomatically: false,
    scheduledAutomation: false,
  })

  useEffect(() => {
    setCheckboxes({
      parametersAutomatically: false,
      scheduledAutomation: false,
    })
  }, [])

  const handleSwitchChange = async (topic, status, orderId) => {
    try {
      const reversedStatus = !status
      const payload = {
        topicName: topic,
        payload: {
          id: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
          status: reversedStatus,
          order: orderId,
        },
      }
      alert(status)
      const response = await axios.post(`${config.API_URL}/controldevices`, payload)
      // console.log(response)

      // Update switch status locally
      setFarms((prevFarms) => {
        return prevFarms.map((farm) => {
          return {
            ...farm,
            devices: farm.devices.map((device) => {
              if (device.controllerCode === topic) {
                return {
                  ...device,
                  status: reversedStatus,
                }
              }
              return device
            }),
          }
        })
      })
    } catch (error) {
      console.error('Lỗi khi gửi yêu cầu điều khiển thiết bị:', error)
    }
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

  const renderDeviceSwitchControls = () => {
    if (!farms) return null

    return farms.map((farm) =>
      farm.devices.map((device) => (
        <CRow key={device.id}>
          <CCol sm={6}>
            <CFormSwitch
              label={device.name}
              // defaultChecked={device.status}
              onChange={() =>
                handleSwitchChange(device.controllerCode, device.status, device.order)
              }
            />
          </CCol>
          <CCol sm={6}>
            <CIcon
              icon={cibDiscover}
              size="xl"
              style={{ color: device.status == true ? '#249542' : '#db5d5d' }}
            />
          </CCol>
        </CRow>
      )),
    )
  }

  // call api
  const fetchData = async () => {
    await axios.get(`${config.API_URL}/farms`).then((res) => {
      console.log(res.data.results)
      if (res.data) {
        setFarms(res.data.results)
      } else {
        setFarms([])
      }
    })

    // log
    // console.log('APIs called')
  }

  useEffect(() => {
    // call
    fetchData()

    // const millisecond = 5000
    // const interval = setInterval(fetchData, millisecond)
    // return () => clearInterval(interval)
  }, [])

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
            {/* <CCol sm={6}>
              <h4>Controller 1</h4>
              {renderSwitchControl('Quạt', 'fan')}
              {renderSwitchControl('Đèn 2', 'light2')}
              {renderSwitchControl('Đèn 3', 'light3')}
            </CCol>
            <CCol sm={6}>
              <h4>Controller 2</h4>
              {renderSwitchControl('Đèn S', 'lightS')}
            </CCol> */}
            {renderDeviceSwitchControls()}
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
