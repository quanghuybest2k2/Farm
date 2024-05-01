import React from 'react'
import { TransformWrapper, TransformComponent } from 'react-zoom-pan-pinch'

import { CCard, CCardBody, CCardHeader, CCol, CRow } from '@coreui/react'

const Camera = () => {
  const cameras = [
    {
      id: 1,
      name: 'Camera 1',
      imageUrl: 'http://113.165.96.220:82/webcapture.jpg?command=snap&channel=1?1714539910',
    },
    {
      id: 2,
      name: 'Camera 2',
      imageUrl: 'http://103.99.244.170:8084/webcapture.jpg?command=snap&channel=1?1714539968',
    },
    {
      id: 3,
      name: 'Camera 3',
      imageUrl: 'http://113.165.166.204:83/webcapture.jpg?command=snap&channel=1?1714540410',
    },
  ]

  return (
    <CRow>
      <CCol xs>
        <CCard className="mb-4">
          <CCardHeader>Camera</CCardHeader>
          <CCardBody>
            <p className="text-body-secondary small">
              Thông tin căn bản <code>Camera</code>
            </p>
            <CRow>
              {cameras.map((camera) => (
                <CCol xs="12" sm="6" md="4" lg="3" key={camera.id}>
                  <CCard className="mb-4">
                    <CCardHeader>{camera.name}</CCardHeader>
                    <CCardBody>
                      <TransformWrapper>
                        <TransformComponent>
                          <img src={camera.imageUrl} alt={camera.name} style={{ width: '100%' }} />
                        </TransformComponent>
                      </TransformWrapper>
                    </CCardBody>
                  </CCard>
                </CCol>
              ))}
            </CRow>
            <br />
          </CCardBody>
        </CCard>
      </CCol>
    </CRow>
  )
}

export default Camera
