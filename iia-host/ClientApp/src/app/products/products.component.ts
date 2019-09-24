import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category, CategoriesResponse, CategoryResponse, Unit } from '../shared/shared.config';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent {
  public forecasts: WeatherForecast[];
  public unit = Unit;
  public categories: Category[];
  public loadBatchEntry = true;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<CategoriesResponse>(baseUrl + 'api/Category').subscribe(result => {
      this.categories = result.data;
    }, error => console.error(error));
    http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));   
  }
  public loadComponent = false;

  addproduct() {
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

  toggleLoadBatchEntry() {
    this.loadBatchEntry = !this.loadBatchEntry;
  }

}


interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}


