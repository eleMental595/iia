import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-vendors',
  templateUrl: './vendors.component.html',
  styleUrls: ['./vendors.component.css']

})
export class VendorsComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
  public loadComponent = false;

  addVendor() {
    this.loadComponent = !this.loadComponent;
  }

  onSubmit(form: any): void {
    console.log('you submitted value:', form);
    this.loadComponent = !this.loadComponent;
  }

  onCancel() {
    console.log("cancel btn clicked");
    this.loadComponent = !this.loadComponent;
  }
}



interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
