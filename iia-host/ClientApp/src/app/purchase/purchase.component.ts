import { Component, OnInit, Injectable, Inject } from '@angular/core';
import { Purchase, PurchaseEntry } from '../shared/shared.config';
import { FormArray, FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ApiResponse } from '../shared/shared.config';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})

@Injectable()
export class PurchaseComponent implements OnInit {

  ltsForm: FormGroup;  

  private fieldArray: Array<any> = [];
  private newAttribute: any = {};

  public purchases: Purchase[];
  public invoiceFormData: PurchaseEntry;
  public model: any = {};

  private loadPurchaseEntryForm = false;
  private loadInvoiceForm = false;

  get products() { return this.ltsForm.get('purchaseProducts') as FormArray;; }

  private _baseUrl: string;
  private _url: string;

  constructor(private formBuilder: FormBuilder, private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
    this.getPurchases();
  }

  ngOnInit() {
    this.ltsForm = this.formBuilder.group({
      purchaseId: [''],
      vendorId: [''],
      vendorName: [''],
      invoiceNumber: [''],
      netAmount: [''],
      vatAmount: [''],
      totalAmount: [''],
      recievedBy: [''],
      purchaseProducts: this.formBuilder.array([this.createItem()])
    });
  }

  createItem(): FormGroup {
    return this.formBuilder.group({
      product: '',
      description: '',
      cost: '',
      quantity: '',
      unitPrice: '',
      hasExpiryDate: '',
      expiryDate: '',
      batch: ''
    });
  }

  addPurchaseEntryForm() {
    this.loadPurchaseEntryForm = !this.loadPurchaseEntryForm;
  }

  getPurchases() {
    this._http.get<ApiResponse>(this._baseUrl + 'api/Purchase').subscribe(result => {
      this.purchases = result.data;
    }, error => console.error(error));
  }


  onSubmit() {
    console.log(this.ltsForm.value);
    this._url = this._baseUrl + 'api/Purchase';

    this._http.post<ApiResponse>(this._url, this.ltsForm.value).subscribe(result => {      
      this.getPurchases();
    }, error => console.error(error));

    this.loadPurchaseEntryForm = !this.loadPurchaseEntryForm;
  }

  addFieldValue() {
    console.log(this.newAttribute);
    this.fieldArray.push(this.newAttribute)
    console.log(this.fieldArray);
    this.newAttribute = {};
  }

  addProduct() {
    this.products.push(this.createItem());
  }

  deleteFieldValue(index: number) {
    const control = <FormArray>this.products;
    control.removeAt(index);
  }

  onCancel() {
    console.log("cancel btn clicked");
    this.loadPurchaseEntryForm = !this.loadPurchaseEntryForm;
  }

  save() {
    console.log(this.ltsForm.value);
  }

  showInvoice(id: number) {
    this._url = this._baseUrl + 'api/Purchase/'+ id;

    this._http.get<ApiResponse>(this._url).subscribe(result => {
      this.invoiceFormData = result.data;
      console.log(this.invoiceFormData); 
    }, error => console.error(error));

    this.loadInvoiceForm = !this.loadInvoiceForm;
  }

  onCancelInvoice() {
    console.log("cancel btn clicked");
    this.loadInvoiceForm = !this.loadInvoiceForm;
  }

}
