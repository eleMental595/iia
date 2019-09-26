import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product, Category, Unit, ApiResponse } from '../shared/shared.config';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent {  
  public unit = Unit;
  public categories: Category[];
  public products: Product[];
  public product: Product;
  public model: Product;

  public loadBatchEntry = true;
  public loadComponent = false;
  public loadDeletePopup = false;

  public btnCreate: boolean;

  private _baseUrl: string;
  private _url: string;

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
    this.getProducts();
  }


  getCategories() {
    this._http.get<ApiResponse>(this._baseUrl + 'api/Category').subscribe(result => {
      this.categories = result.data;
    }, error => console.error(error));
  }

  getProducts() {
    this._http.get<ApiResponse>(this._baseUrl + 'api/Product').subscribe(result => {
      this.products = result.data;
    }, error => console.error(error));
  }

  addproduct() {
    this.btnCreate = true;
    this.emptyModel();
    this.getCategories();
    this.loadComponent = !this.loadComponent;
  }

  onSubmit(form: any): void {
    form.expiryDate = this.loadBatchEntry ? 1 : 0;
    console.log('you submitted value:', form);

    this._url = this._baseUrl + 'api/Product';
    if (this.btnCreate) {
      this._http.post<ApiResponse>(this._url, form).subscribe(result => {
        this.product = result.data;
        this.getProducts();
      }, error => console.error(error));
    }
    else {
      this._http.put<ApiResponse>(this._url, form).subscribe(result => {
        this.product = result.data;
        this.getProducts();
      }, error => console.error(error));
    }
    this.loadComponent = !this.loadComponent;
  }

  editProduct(product) {
    this.btnCreate = false;
    this.model = product;
    this.getCategories();
    this.loadComponent = !this.loadComponent;
  }

  deleteCategory(event, product) {
    this.model = product;
    this.loadDeletePopup = true;
    this.loadComponent = !this.loadComponent;
    event.stopPropagation();
  }

  onDelete(form: Category): void {
    this._url = this._baseUrl + 'api/Product/' + this.model.id;
    this._http.delete<ApiResponse>(this._url).subscribe(result => {
      console.log(result.data);
      this.getProducts();
      this.loadDeletePopup = false;
    }, error => console.error(error));
  }

  onCancel() {
    console.log("cancel btn clicked");
    this.loadComponent = !this.loadComponent;
  }

  toggleLoadBatchEntry() {
    this.loadBatchEntry = !this.loadBatchEntry;
  }

  emptyModel() {
    this.model = {} as Product;
  }


}


