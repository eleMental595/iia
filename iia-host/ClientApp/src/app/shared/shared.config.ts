export interface Category {
  category_Name: string;
  vat: number;
}

export interface CategoriesResponse {
  data: Category[];
}

export interface CategoryResponse {
  data: Category;
}

export const Unit: Array<string> = ["BOX", "PCS", "ROLL", "LITER", "METER", "PACKET"];
