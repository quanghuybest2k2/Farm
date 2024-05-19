import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import Chart from 'chart.js/auto';
import { StatisticsService } from '../api/statistics.service';
import DataTypeEnum from '../enums/DataTypeEnum';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.page.html',
  styleUrls: ['./statistics.page.scss'],
})
export class StatisticsPage implements OnInit {
  @ViewChild('temperatureChart') temperatureChart!: ElementRef;
  @ViewChild('humidityChart') humidityChart!: ElementRef;
  @ViewChild('brightnessChart') brightnessChart!: ElementRef;

  currentDate!: string;
  SpecifiedData!: any;
  temChart!: Chart;
  humiChart!: Chart;
  brightChart!: Chart;

  constructor(private statisticsService: StatisticsService) {}

  ngAfterViewInit() {
    this.createCharts();
  }

  ngOnInit() {
    this.currentDate = this.getCurrentDate();
    this.getSpecifiedDateList(this.getCurrentDate());
  }

  getSpecifiedDateList(day: any) {
    this.statisticsService
      .getSpecifiedDateData(DataTypeEnum.SENSORLOCATION.KV2, day)
      .then((data) => {
        this.SpecifiedData = data;
        this.createCharts();
      })
      .catch((error) => {
        console.error(error);
      });
  }

  getCurrentDate(): string {
    const today: Date = new Date();
    const year: number = today.getFullYear();
    const month: number = today.getMonth() + 1;
    const day: number = today.getDate();

    const formattedMonth: string = month < 10 ? '0' + month : '' + month;
    const formattedDay: string = day < 10 ? '0' + day : '' + day;

    return year + '-' + formattedMonth + '-' + formattedDay;
  }

  dateChanged(event: CustomEvent) {
    const selectedDate: string = event.detail.value;
    this.getSpecifiedDateList(selectedDate);
  }

  formatDate(dateString: string): string {
    const date = new Date(dateString);
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const year = date.getFullYear();
    const hour = date.getHours();
    const minute = date.getMinutes();
    const second = date.getSeconds();
    return `${day}/${month}/${year} ${hour}:${minute}:${second}`;
  }

  createCharts() {
    if (this.temChart) {
      this.temChart.destroy();
    }

    if (this.humiChart) {
      this.humiChart.destroy();
    }

    if (this.brightChart) {
      this.brightChart.destroy();
    }

    // Kiểm tra xem dữ liệu có tồn tại không
    const noDataCtx = this.temperatureChart.nativeElement.getContext('2d');
    if (!this.SpecifiedData || this.SpecifiedData.length === 0) {
      noDataCtx.font = '30px Arial';
      noDataCtx.fillStyle = 'black';
      noDataCtx.fillText('Không có dữ liệu', 10, 50);
      return;
    }

    // Biểu đồ nhiệt độ
    const temperatureCtx = this.temperatureChart.nativeElement.getContext('2d');
    const temperatureLabels = this.SpecifiedData.map((entry: any) =>
      this.formatDate(entry.createAt)
    );
    const temperatureData = this.SpecifiedData.map(
      (entry: any) => entry.temperature
    );

    // Tạo biểu đồ nhiệt độ
    this.temChart = new Chart(temperatureCtx, {
      type: 'line',
      data: {
        labels: temperatureLabels,
        datasets: [
          {
            label: 'Nhiệt độ',
            data: temperatureData,
            backgroundColor: 'rgba(255, 46, 99, 0.2)',
            borderColor: 'rgba(255, 46, 99, 1)',
            pointBackgroundColor: 'rgba(255, 46, 99, 1)',
            pointBorderColor: '#fff',
            tension: 0.1,
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });

    // Biểu đồ độ ẩm
    const humidityCtx = this.humidityChart.nativeElement.getContext('2d');
    const humidityLabels = this.SpecifiedData.map((entry: any) =>
      this.formatDate(entry.createAt)
    );
    const humidityData = this.SpecifiedData.map((entry: any) => entry.humidity);

    // Tạo biểu đồ độ ẩm
    this.humiChart = new Chart(humidityCtx, {
      type: 'line',
      data: {
        labels: humidityLabels,
        datasets: [
          {
            label: 'Độ ẩm',
            data: humidityData,
            backgroundColor: 'rgba(46, 204, 113, 0.2)',
            borderColor: 'rgba(46, 204, 113, 1)',
            pointBackgroundColor: 'rgba(46, 204, 113, 1)',
            pointBorderColor: '#fff',
            tension: 0.1,
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });

    // Biểu đồ độ sáng
    const brightnessCtx = this.brightnessChart.nativeElement.getContext('2d');
    const brightnessLabels = this.SpecifiedData.map((entry: any) =>
      this.formatDate(entry.createAt)
    );
    const brightnessData = this.SpecifiedData.map(
      (entry: any) => entry.brightness
    );

    // Tạo biểu đồ độ sáng
    this.brightChart = new Chart(brightnessCtx, {
      type: 'line',
      data: {
        labels: brightnessLabels,
        datasets: [
          {
            label: 'Độ sáng',
            data: brightnessData,
            backgroundColor: 'rgba(255, 193, 7, 0.2)',
            borderColor: 'rgba(255, 193, 7, 1)',
            pointBackgroundColor: 'rgba(255, 193, 7, 1)',
            pointBorderColor: '#fff',
            tension: 0.1,
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });
  }
}
