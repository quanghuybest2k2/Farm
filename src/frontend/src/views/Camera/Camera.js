import React, { useRef, useEffect, useState } from 'react'
import {
  CCard,
  CCardBody,
  CCardHeader,
  CCol,
  CRow,
  CDropdown,
  CDropdownToggle,
  CDropdownMenu,
  CDropdownItem,
} from '@coreui/react'
import * as cocoSsd from '@tensorflow-models/coco-ssd'
import '@tensorflow/tfjs'
import video from './video.mp4'
import DataTypeEnum from '../../DataTypeEnum'
// thư viện nhận diện khuôn mặt
// import * as faceapi from 'face-api.js'

const Camera = () => {
  const videoRef = useRef()
  const [numPeople, setNumPeople] = useState(0)
  const [selectedLocationValue, setSelectedLocationValue] = useState(
    DataTypeEnum.SENSORLOCATION.KV2,
  )

  useEffect(() => {
    const runObjectDetection = async () => {
      const net = await cocoSsd.load()
      setInterval(async () => {
        const result = await net.detect(videoRef.current)
        const people = result.filter((item) => item.class === 'person')
        setNumPeople(people.length)
      }, 100)
    }

    if (videoRef.current.readyState >= 3) {
      // HAVE_FUTURE_DATA
      runObjectDetection()
    } else {
      videoRef.current.onloadeddata = runObjectDetection
    }
  }, [])

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

  return (
    <CRow>
      <CCol xs>
        <CCard className="mb-4">
          <CCardHeader>Camera</CCardHeader>
          <CCardBody>
            <h6 className="text-body-secondary small">
              Thông tin căn bản <code>Camera</code>
            </h6>
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
            <CRow>
              <CCol xs={12}>
                <CCard className="mb-4">
                  <CCardHeader>Camera 1</CCardHeader>
                  <CCardBody>
                    <video ref={videoRef} width="100%" height="100%" controls>
                      <source src={video} type="video/mp4" />
                    </video>
                    <p>Tổng số người: {numPeople}</p>
                  </CCardBody>
                </CCard>
              </CCol>
            </CRow>
            <br />
          </CCardBody>
        </CCard>
      </CCol>
    </CRow>
  )
}

export default Camera
