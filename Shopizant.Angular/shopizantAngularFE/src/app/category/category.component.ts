import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/Shopizant-interfaces/product';
import { ICategory } from 'src/app/Shopizant-interfaces/category'; //path or parent folder of the class
import { CategoryService } from '../Shopizant-services/CategoryServices/category.service';
//import { ProductService } from 'src/app/Shopizant-services/ProductServices/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  products: IProduct[] | any;
  categories: ICategory[] | undefined;
  showMessage: boolean = false;
  imageCart: string | any;


  constructor(private category_Service: CategoryService) { }   //(private product_Service: ProductService)instance of product services

  ngOnInit(): void {




    //this.getProducts();
     this.getCatgories();


    //if (this.product == null) {
    //  this.showMessage = true;
    //}
    this.imageCart = "src/assets/Shopizant-images/ShopcartIcon.jpg";
  }



 



  getCatgories() {
    this.category_Service.getCategories().subscribe(
      responseProductData => {
      this.categories = responseProductData;

    }
    );
  }


}
