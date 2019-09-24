import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category, CategoriesResponse, CategoryResponse } from '../shared/shared.config';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']

})
export class CategoriesComponent{

  public categories: Category[];
  public category: Category;
  private _http: HttpClient;
  private _baseUrl: string

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
    this.getCategories();
  }

  public loadComponent = false;

  getCategories() {
   this._http.get<CategoriesResponse>(this._baseUrl + 'api/Category').subscribe(result => {
      this.categories = result.data;
    }, error => console.error(error));
  }

  addCategory() {
    this.loadComponent = !this.loadComponent;    
  }

  onSubmit(form: any): void {
    console.log('you submitted value:', form);
    this._http.post<CategoryResponse>(this._baseUrl + 'api/Category', form).subscribe(result => {      
      this.category = result.data;
      console.log(this.category);
      this.getCategories();
    }, error => console.error(error));    
    this.loadComponent = !this.loadComponent; 
  }

  onCancel(){
    console.log("cancel btn clicked");
  this.loadComponent = !this.loadComponent;
  }
}
