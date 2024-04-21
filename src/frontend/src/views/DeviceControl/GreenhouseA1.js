import { CCard, CCardBody, CCol, CRow, CCardHeader } from '@coreui/react'
import CustomCheckbox from './CustomCheckbox'
import React, { useEffect, useState } from 'react'
import InformationEnvironment from '../widgets/InformationEnvironment'
import CIcon from '@coreui/icons-react'
import { cibDiscover } from '@coreui/icons'
import * as signalR from '@microsoft/signalr'
// dalat maps
import MyMap from './MyMap'
import axios from 'axios'
import config from '../../config'

const GreenhouseA1 = () => {
  const [data, setData] = useState([])
  const [connection, setConnection] = useState(null)
  const [sensorData, setSensorData] = useState([])

  const [checkboxes, setCheckboxes] = useState({
    parametersAutomatically: false,
    scheduledAutomation: false,
  })

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get(`${config.API_URL}/farms`)
        setData(response.data)
      } catch (error) {
        console.error('Error fetching data: ', error)
      }
    }

    const connectSignalR = async () => {
      try {
        const connect = new signalR.HubConnectionBuilder()
          .withUrl(`${config.BASE_URL}/farmhub`)
          .withAutomaticReconnect()
          .build()

        connect.on('esp8266/ledStatus', (dataString) => {
          try {
            const data = JSON.parse(dataString)
            console.log('Parsed data:', data)
            setSensorData(data)
          } catch (error) {
            console.error('Error parsing JSON string:', error)
          }
        })

        await connect.start()
        console.log('Connected!')
        setConnection(connect)
        return () => {
          connect.stop()
        }
      } catch (err) {
        console.error('Error while establishing connection:', err)
      }
    }

    fetchData()
    connectSignalR()

    // Clean up
    return () => {
      if (connection) {
        connection.stop()
      }
    }
  }, [])

  const controlDevice = (device, statusDevice) => {
    const postData = {
      topicName: device.controllerCode,
      payload: {
        id: device.id,
        status: !statusDevice,
        order: device.order,
      },
    }

    axios
      .post(`${config.API_URL}/controldevices`, postData)
      .then((response) => {})
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
            {/* display devices */}
            <CCol sm={6}>
              {data.results &&
                data.results.map((farm) => (
                  <div key={farm.id}>
                    <h4>{farm.sensorLocation}</h4>
                    {farm.devices.map((device) => (
                      <CRow key={device.id}>
                        <CCol sm={6}>
                          <div className="form-check form-switch">
                            <input
                              className="form-check-input"
                              type="checkbox"
                              onChange={() => controlDevice(device, !sensorData.Status)}
                              checked={sensorData.Status}
                            />
                            <label className="form-check-label">{device.name}</label>
                          </div>
                        </CCol>
                        <CCol sm={6}>
                          <CIcon
                            icon={cibDiscover}
                            size="xl"
                            style={{ color: sensorData.Status ? '#249542' : '#db5d5d' }}
                          />
                        </CCol>
                      </CRow>
                    ))}
                  </div>
                ))}
            </CCol>
            {/* end display devices */}
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
