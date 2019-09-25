import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiResponse, Category, CategoriesResponse, CategoryResponse } from '../shared/shared.config';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']

})
export class CategoriesComponent {

  public categories: Category[];
  public category: Category;
  public model: Category;
  public btnCreate: boolean;

  public loadComponent = false;
  public loadDeletePopup = false;

  private _baseUrl: string;
  private _url: string;

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
    this.getCategories();
  }

  getCategories() {
    this._http.get<CategoriesResponse>(this._baseUrl + 'api/Category').subscribe(result => {
      this.categories = result.data;
    }, error => console.error(error));
  }

  addCategory() {
    this.btnCreate = true;
    this.emptyModel();
    this.loadComponent = !this.loadComponent;
  }

  onSubmit(form: any): void {
    console.log('you submitted value:', form);
    this._url = this._baseUrl + 'api/Category';
    if (this.btnCreate) {
      this._http.post<CategoryResponse>(this._url, form).subscribe(result => {
        this.category = result.data;
        this.getCategories();        
      }, error => console.error(error)); 
    }
    else {
      this._http.put<CategoryResponse>(this._url, form).subscribe(result => {
        this.category = result.data;
        this.getCategories();
      }, error => console.error(error)); 
    }

    this.loadComponent = !this.loadComponent;
    
  }

  deleteCategory(event, category) {
    this.model = category;
    this.loadDeletePopup = true;
    this.loadComponent = !this.loadComponent;
    event.stopPropagation();
  }

  onDelete(form: Category): void {
    this._url = this._baseUrl + 'api/Category/' + this.model.id;
    this._http.delete<CategoryResponse>(this._url).subscribe(result => {
      console.log(result.data);
      this.getCategories();
      this.loadDeletePopup = false;
    }, error => console.error(error));
  }

  onCancel() {
    console.log("cancel btn clicked");
    this.loadComponent = !this.loadComponent;
  }

  onCancelDeletePopup() {
    this.loadDeletePopup = false;
  }

  editCategory(category) {
    this.btnCreate = false;
    this.model = category;
    this.loadComponent = !this.loadComponent;
  }

  emptyModel() {
    this.model = {} as Category;
  }
}
