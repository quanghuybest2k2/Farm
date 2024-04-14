import React, { useEffect, useRef } from 'react'
import { CCard, CCardBody, CCol, CCardHeader } from '@coreui/react'
import { CChartLine } from '@coreui/react-chartjs'
import { getStyle } from '@coreui/utils'
import { format } from 'date-fns'
import PropTypes from 'prop-types'

import DataTypeEnum from '../../DataTypeEnum'

const StatisticsBySpecificDate = ({ data }) => {
  const chartRef = useRef(null)

  useEffect(() => {
    document.documentElement.addEventListener('ColorSchemeChange', () => {
      if (chartRef.current) {
        setTimeout(() => {
          chartRef.current.options.scales.x.grid.borderColor = getStyle(
            '--cui-border-color-translucent',
          )
          chartRef.current.options.scales.x.grid.color = getStyle('--cui-border-color-translucent')
          chartRef.current.options.scales.x.ticks.color = getStyle('--cui-body-color')
          chartRef.current.options.scales.y.grid.borderColor = getStyle(
            '--cui-border-color-translucent',
          )
          chartRef.current.options.scales.y.grid.color = getStyle('--cui-border-color-translucent')
          chartRef.current.options.scales.y.ticks.color = getStyle('--cui-body-color')
          chartRef.current.update()
        })
      }
    })
  }, [chartRef])

  const getLabel = () => {
    switch (dataType) {
      case DataTypeEnum.TEMPERATURE:
        return 'Temperature'
      case DataTypeEnum.HUMIDITY:
        return 'Humidity'
      case DataTypeEnum.BRIGHTNESS:
        return 'Brightness'
      default:
        return 'Data'
    }
  }

  return (
    <>
      <CCol xs={12}>
        <CCard className="mb-4">
          <CCardHeader>{getLabel()}</CCardHeader>
          <CCardBody>
            {data && data.length > 0 ? (
              <CChartLine
                data={{
                  labels: data.map((item) => format(new Date(item.date), 'dd/MM/yyyy')),
                  datasets: [
                    {
                      label: getLabel(),
                      backgroundColor: 'rgba(255, 46, 99, 0.2)',
                      borderColor: 'rgba(255, 46, 99, 1)',
                      pointBackgroundColor: 'rgba(255, 46, 99, 1)',
                      pointBorderColor: '#fff',
                      data: data.map((item) => {
                        item.a
                      }),
                    },
                  ],
                }}
              />
            ) : (
              <p>No data available</p>
            )}
          </CCardBody>
        </CCard>
      </CCol>
    </>
  )
}

StatisticsBySpecificDate.propTypes = {
  data: PropTypes.array.isRequired,
}

export default StatisticsBySpecificDate
