import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.prod';
import axios from 'axios';

@Injectable({
  providedIn: 'root',
})
export class MapService {
  API_URL: string = environment.api_url;

  constructor() {}

  getData() {
    return axios
      .get(`${this.API_URL}/farms`)
      .then((response) => response.data)
      .catch((error) => {
        console.error(error);
        throw error;
      });
  }
}
