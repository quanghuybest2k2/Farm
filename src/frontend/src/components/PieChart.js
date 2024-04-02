import React from "react";
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from "chart.js";
import { Doughnut } from "react-chartjs-2";

const PieChart = () => {
  const labels = ["Táo", "Cam", "Chuối", "Dâu tây"];
  const data = [20, 30, 40, 10];

  ChartJS.register(ArcElement, Tooltip, Legend);

  return (
    <div>
      <Doughnut
        data={{
          labels,
          datasets: [
            {
              data,
              backgroundColor: ["#FF6384", "#36A2EB", "#FFCE56", "#4BC0C8"],
            },
          ],
        }}
      />
    </div>
  );
};

export default PieChart;
