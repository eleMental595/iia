import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category, CategoryResponse } from '../shared/shared.config';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']

})
export class CategoriesComponent{

  public categories: Category[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<CategoryResponse>(baseUrl + 'api/Category').subscribe(result => {
      this.categories = result.data; 
    }, error => console.error(error));
  }

  public loadComponent = false;

  addCategory() {
    this.loadComponent = !this.loadComponent;    
  }

  onSubmit(form: any): void {
    console.log('you submitted value:', form);
    this.loadComponent = !this.loadComponent; 
  }

  onCancel(){
    console.log("cancel btn clicked");
  this.loadComponent = !this.loadComponent;
  }
}
