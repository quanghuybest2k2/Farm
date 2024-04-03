import React, { useEffect, useState } from "react";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";
import { Bar } from "react-chartjs-2";
import axios from "axios";
import config from "../config";

const StackChart = () => {
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

  ChartJS.register(
    CategoryScale,
    LinearScale,
    BarElement,
    Title,
    Tooltip,
    Legend
  );

  const options = {
    plugins: {
      title: {
        display: true,
        text: "Thống kê theo ngày - Nhiệt độ, độ ẩm, chất lượng không khí, độ sáng",
      },
    },
    responsive: true,
    scales: {
      x: {
        stacked: true,
      },
      y: {
        stacked: true,
      },
    },
  };

  const labels = statisticsToday.map((dataPoint) =>
    new Date(dataPoint.date).toLocaleDateString()
  );

  const data = {
    labels,
    datasets: [
      {
        label: "Nhiệt độ",
        data: statisticsToday.map((dataPoint) => dataPoint.averageTemperature),
        backgroundColor: "rgb(255, 99, 132)",
      },
      {
        label: "Độ ẩm",
        data: statisticsToday.map((dataPoint) => dataPoint.averageHumidity),
        backgroundColor: "rgb(75, 192, 192)",
      },
      {
        label: "Chất lượng không khí",
        data: statisticsToday.map((dataPoint) => dataPoint.averageAirQuality),
        backgroundColor: "rgb(53, 162, 235)",
      },
      {
        label: "Độ sáng",
        data: statisticsToday.map((dataPoint) => dataPoint.averageBrightness),
        backgroundColor: "rgb(255, 205, 86)",
      },
    ],
  };

  return (
    <div>
      <Bar options={options} data={data} />
    </div>
  );
};

export default StackChart;
