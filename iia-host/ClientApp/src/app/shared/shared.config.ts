export interface Category {
  id: number
  category_Name: string;
  vat: string;
}

export interface CategoriesResponse {
  data: Category[];
}

export interface CategoryResponse {
  data: Category;
}

export const Unit: Array<string> = ["BOX", "PCS", "ROLL", "LITER", "METER", "PACKET"];
