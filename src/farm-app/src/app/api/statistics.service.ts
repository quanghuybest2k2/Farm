import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.prod';
import axios from 'axios';

@Injectable({
  providedIn: 'root',
})
export class StatisticsService {
  API_URL: string = environment.api_url;

  constructor() {}

  getSpecifiedDateData(sensorLocation: string, date: string) {
    return axios
      .get(
        `${this.API_URL}/environments/specifieddate?sensorLocation=${sensorLocation}&date=${date}`
      )
      .then((response) => response.data)
      .catch((error) => {
        console.error(error);
        throw error;
      });
  }
}
