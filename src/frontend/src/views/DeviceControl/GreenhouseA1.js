import { CCard, CCardBody, CCol, CRow, CCardHeader, CFormSwitch } from '@coreui/react'
import CustomCheckbox from './CustomCheckbox'
import React, { useEffect, useState } from 'react'
import InformationEnvironment from '../widgets/InformationEnvironment'
import CIcon from '@coreui/icons-react'
import { cibDiscover } from '@coreui/icons'
// dalat maps
import MyMap from './MyMap'

const GreenhouseA1 = () => {
  const [switchStates, setSwitchStates] = useState({
    fan: true,
    light2: false,
    light3: true,
    lightS: true,
  })

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

  const handleSwitchChange = (switchName) => {
    setSwitchStates({
      ...switchStates,
      [switchName]: !switchStates[switchName],
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

  const renderSwitchControl = (label, switchName) => (
    <CRow>
      <CCol sm={6}>
        <CFormSwitch
          label={label}
          defaultChecked={switchStates[switchName]}
          onChange={() => handleSwitchChange(switchName)}
        />
      </CCol>
      <CCol sm={6}>
        <CIcon
          icon={cibDiscover}
          size="xl"
          style={{ color: switchStates[switchName] ? '#249542' : '#db5d5d' }}
        />
      </CCol>
    </CRow>
  )

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
            <CCol sm={6}>
              <h4>Controller 1</h4>
              {renderSwitchControl('Quạt', 'fan')}
              {renderSwitchControl('Đèn 2', 'light2')}
              {renderSwitchControl('Đèn 3', 'light3')}
            </CCol>
            <CCol sm={6}>
              <h4>Controller 2</h4>
              {renderSwitchControl('Đèn S', 'lightS')}
            </CCol>
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
            {/* <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d4641.859712062819!2d108.44707407521308!3d11.952111029191471!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317112deb9aaaaab%3A0xd6362221bbe37c2b!2zVHJ1bmcgdMOibSBIw6BuaCBjaMOtbmggdGjDoG5oIHBo4buRIMSQw6AgTOG6oXQ!5e0!3m2!1svi!2s!4v1713151799373!5m2!1svi!2s" width="600" height="450" style={{ border: "0" }} allowFullScreen ></iframe> */}
            <MyMap />
          </CRow>
        </CCardBody>
      </CCard>
    </>
  )
}

export default GreenhouseA1
