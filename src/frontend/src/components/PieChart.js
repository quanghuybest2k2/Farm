import React, { useEffect, useState } from "react";
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from "chart.js";
import { Doughnut } from "react-chartjs-2";
import config from "../config";
import axios from "axios";

const PieChart = () => {
  const [statisticsToday, setStatisticsToday] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const res = await axios.get(
          `${config.API_URL}/environments/daily-statistics`
        );
        setStatisticsToday(res.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, []);

  ChartJS.register(ArcElement, Tooltip, Legend);

  const labels = ["Nhiệt độ", "Độ ẩm", "Chất lượng không khí", "Độ sáng"];
  const backgroundColor = ["#FF6384", "#36A2EB", "#FFCE56", "#4BC0C8"];

  const data = statisticsToday.map((dataPoint) => [
    dataPoint.averageTemperature,
    dataPoint.averageHumidity,
    dataPoint.averageAirQuality,
    dataPoint.averageBrightness,
  ]);

  return (
    <>
      <div>
        <Doughnut
          data={{
            labels,
            datasets: statisticsToday.map((dataPoint, index) => ({
              label: new Date(dataPoint.date).toLocaleDateString(),
              data: [
                dataPoint.averageTemperature,
                dataPoint.averageHumidity,
                dataPoint.averageAirQuality,
                dataPoint.averageBrightness,
              ],
              backgroundColor: backgroundColor,
            })),
          }}
        />
      </div>
    </>
  );
};

export default PieChart;
