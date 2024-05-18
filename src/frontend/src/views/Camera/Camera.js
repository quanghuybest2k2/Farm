import React, { useRef, useEffect, useState } from 'react'
import { CCard, CCardBody, CCardHeader, CCol, CRow } from '@coreui/react'
import * as cocoSsd from '@tensorflow-models/coco-ssd'
import '@tensorflow/tfjs'
import video from './video.mp4'
// thư viện nhận diện khuôn mặt
// import * as faceapi from 'face-api.js'

const Camera = () => {
  const videoRef = useRef()
  const [numPeople, setNumPeople] = useState(0)

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
