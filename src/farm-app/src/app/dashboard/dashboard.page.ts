import { Component, OnInit } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.page.html',
  styleUrls: ['./dashboard.page.scss'],
})
export class DashboardPage implements OnInit {
  sensorData: any;
  loading: boolean = true;
  sensorLocation: string = 'KV2';
  connection: any;

  constructor() {}

  ngOnInit() {
    this.getRealtimeEnvironment();
  }

  getRealtimeEnvironment() {
    const connect = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.base_url}/farmhub`)
      .withAutomaticReconnect()
      .build();

    connect
      .start()
      .then(() => {
        console.log('Connected!');
        this.connection = connect;
        /**
         * KV2
         * esp8266/ledStatus
         */
        connect.on(this.sensorLocation, (dataString) => {
          // console.log('Data received from server: ', dataString)
          try {
            const data = JSON.parse(dataString);
            console.log('Parsed data:', data);
            this.sensorData = data;
            this.loading = false;
          } catch (error) {
            console.error('Error parsing JSON string:', error);
            this.loading = false;
          }
        });
      })
      .catch((err) => {
        console.error('Error while establishing connection:', err);
        this.loading = false;
      });
  }

  onSensorLocationChange(event: any) {
    this.sensorLocation = event.detail.value;
    console.log(this.sensorLocation);
  }
}
