export interface Category {
  id: number;
  category_Name: string;
  vat: string;
}

export interface Product {
  id: number;
  category: string;
  product_Name: string;
  name_Arabic: string;
  unit: string;
  selling_price: number;
  cost: number;
  expiry_Date: number;
  batch: string;
}

export enum Status {
  Success,
  Failure
}

export interface ApiResponse {
  data: any;
  status: Status;
}


export const Unit: Array<string> = ["BOX", "PCS", "ROLL", "LITER", "METER", "PACKET"];

export interface Purchase {
  id: number;
  vendorName: string;
  invoice: string;
  totalAmount: number;
  receivedBy: string;
}

export interface PurchaseEntry {
  purchaseId: number;
  vendorId: number;
  vendorName: string;
  invoice: string;
  netAmount: number;
  vatAmount: number;
  totalAmount: number;
  receivedBy: string;
  purchaseProducts: PurchaseProduct[]
}

export interface PurchaseProduct {
  id: '',
  description: '',
  cost: '',
  quantity: '',
  unitPrice: '',
  hasExpiryDate: '',
  expiryDate: '',
  batch: ''
}
