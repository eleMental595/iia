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
