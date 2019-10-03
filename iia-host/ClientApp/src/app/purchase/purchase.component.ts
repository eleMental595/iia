import { Component, OnInit, Injectable } from '@angular/core';
import { Purchase, PurchaseEntry } from '../shared/shared.config';
import { FormArray, FormControl, FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})

@Injectable()
export class PurchaseComponent implements OnInit {

  ltsForm: FormGroup;
  product: FormGroup;

  private fieldArray: Array<any> = [];
  private newAttribute: any = {};

  public purchases: Purchase[];
  public model: any = {};

  private loadPurchaseEntryForm = false;

  get products() { return this.ltsForm.get('products'); }

  constructor(private formBuilder: FormBuilder) {

  }

  ngOnInit() {
    this.ltsForm = this.formBuilder.group({
      purchaseId: [''],
      vendorId: [''],
      vendorName: [''],
      invoice: [''],
      netAmount: [''],
      vatAmount: [''],
      totalAmount: [''],
      receivedBy: [''],
      products: this.formBuilder.array([this.createItem()])
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

  onSubmit() {
    console.log(this.ltsForm.value);
    this.loadPurchaseEntryForm = !this.loadPurchaseEntryForm;
  }

  addFieldValue() {
    console.log(this.newAttribute);
    this.fieldArray.push(this.newAttribute)
    console.log(this.fieldArray);
    this.newAttribute = {};
  }

  addProduct() {
    this.products.value.push(this.createItem);
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

}
