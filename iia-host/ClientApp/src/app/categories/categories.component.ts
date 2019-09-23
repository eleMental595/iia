import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']

})
export class CategoriesComponent{

  public categories: Category[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<response>(baseUrl + 'api/Category').subscribe(result => {
      this.categories = result.data; 
    }, error => console.error(error));
  }

  public loadComponent = false;

  addCategory() {
    this.loadComponent = !this.loadComponent;    
  }

  cancel() {
    this.loadComponent = !this.loadComponent;
  }
}

interface response {
  data: Category[];
}

interface Category {
  category_Name: string;
  vat: number;
}


