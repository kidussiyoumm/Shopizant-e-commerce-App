import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ICartProduct } from '../Shopizant-interfaces/cartProduct';
/*import { ICartProduct } from '../Shopizant-interfaces/cartProduct';*/
import { UserService } from '../Shopizant-services/UserServices/user.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cartItem: ICartProduct[] | any;//array of Icartproducts
  error: string | any;
  
  emailId: string | any;
  currentStat: boolean = false;

  constructor(private _userServcies: UserService, private router: Router) { }

  ngOnInit(): void {
    this.emailId = sessionStorage.getItem('userName');
    if (this.emailId == null) {
      this.router.navigate(['/login']);
    }

    this._userServcies.getCartProduct(this.emailId).subscribe(rescartItem => {
      this.cartItem = rescartItem;
      if (this.cartItem = rescartItem) {
        this.currentStat = true;
        this.error = "Your cart is empty";
      }
    },
      rescartItemErr => {
        this.cartItem = null;
        this.error = rescartItemErr;
        console.log(this.error);
        if (this.cartItem.lenght == 0) {
          this.currentStat = true;
          this.error = "No request found";
        }
      },
    );
    
  }

}
