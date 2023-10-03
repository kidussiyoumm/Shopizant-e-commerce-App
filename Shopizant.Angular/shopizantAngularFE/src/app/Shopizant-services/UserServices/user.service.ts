import { Injectable } from '@angular/core'; //Can be injected to other components 
import { HttpClient, HttpErrorResponse } from '@angular/common/http'; 
import { catchError, map, Observable, throwError } from 'rxjs'; //used in the observable to add mods to the call
import { IUser } from '../../Shopizant-interfaces/user';
import { Icart } from '../../Shopizant-interfaces/cart';
import { ICartProduct } from '../../Shopizant-interfaces/cartProduct';



@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }


  errorHandler(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error || "Server Error");
  }
  userCredentials(emailId: string, password: string): Observable<string> { //method accepts two strings and invokes the psot from services layer and returnsan observable type converted to string
    var userName: IUser;
    userName = { emailID: emailId, password: password }; //, gender: string, dateOfBirth: Date, address: string, roleID: null
    return this.http.post<string>('https://localhost:44363/api/User/Validate', userName).pipe(map(res => res), (catchError(this.errorHandler)));;
  }
  addToCart(ProductId: string, EmailId: string): Observable<boolean> {//method accepts two strings and invokes the post from services layer and returnsan observable type converted to boolean
    var cartValue: Icart;
    cartValue = { productId: ProductId, emailId: EmailId, quantity: 1 };
    return this.http.post<boolean>('https://localhost:44363/api/User/AddToCart', cartValue).pipe(map(res => res), (catchError(this.errorHandler)));;


  }
  getCartProduct(emailId: string): Observable<ICartProduct[]> {
    let temp = "?emailId=" + emailId;
    return this.http.get<ICartProduct[]>('https://localhost:44363/api/User/GetCartItems?emailId=kidusman.ka@gmail.com' + temp).pipe(map(res => res), (catchError(this.errorHandler)));;

  }
} 
