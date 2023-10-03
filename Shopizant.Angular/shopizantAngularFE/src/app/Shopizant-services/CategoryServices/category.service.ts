//Main responsibilty of product serces class is to prodvice products data to the compomenents that asks for it
import { Injectable } from '@angular/core';
import { IProduct } from 'src/app/Shopizant-interfaces/product';
import { ICategory } from 'src/app/Shopizant-interfaces/category';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';//used to comunicate to the server
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';



@Injectable({ //this @ declarations means DI can take place
  providedIn: 'root'
})
export class CategoryService {

  products: IProduct[] | undefined;
  categories: ICategory[] | undefined;
  router: any;
  //private url = 'https://localhost:44390/api/Product/';

  constructor(private http: HttpClient) { }//Httpclient is injected into the constructor

  errorHandlder(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error || "Server Error");
  }
  getProducts(): Observable<IProduct[]> { //converts the recived Observable from repsonse type of valuess depending on the context
    let fetchProduct = this.http.get<IProduct[]>('https://localhost:44363/api/Product').pipe(map(res => res), catchError(this.errorHandlder));;//from the serices layer
    return fetchProduct;
  }

  getCategories(): Observable<ICategory[]> { //converts the recived Observable from repsonse type of valuess depending on the context
    let fetchCategories = this.http.get<ICategory[]>('https://localhost:44390/api/Category').pipe(map(res => res), catchError(this.errorHandlder));;//from the serices layer
    return fetchCategories;
  }

}



