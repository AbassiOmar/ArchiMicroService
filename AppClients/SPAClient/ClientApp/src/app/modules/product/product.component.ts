import { Component, OnInit } from '@angular/core';
import { BasketItemModel, BasketModel } from 'src/app/shared/services/nswaggClient/BFFProductClient';
import { Product } from 'src/app/shared/services/nswaggClient/product.client';
import { BasketService } from '../services/basket.service';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
   iteminbasket:BasketModel=new BasketModel();
  products: Product[];
  constructor(private productService:ProductService,private basketService:BasketService) { 
    this.iteminbasket.items=[];
  }

  ngOnInit() {

    this.productService.getProducts().subscribe(result => {
      result.forEach(element => {
        element.imageFile='assets/images/products/'+element.imageFile;
      });
      this.products = result;
    });
  }

  addToBasket(event,item:Product)
  {
    let tmpproduct:BasketItemModel=new BasketItemModel();
    tmpproduct.quantity=2;
    tmpproduct.productId=item.id;
    tmpproduct.productName=item.name;
    tmpproduct.color="Red";
    tmpproduct.price=item.price;
    
    let totalprice:number;
    totalprice=totalprice+item.price;
    this.iteminbasket

    this.iteminbasket.userName="abassi";
   

    this.iteminbasket.items.push(tmpproduct); 
    this.iteminbasket.totalPrice=this.iteminbasket.items.reduce((accumulator, current) => {
      return accumulator + current.price;
    }, 0);
    this.basketService.addElementToBasket(this.iteminbasket).subscribe(res=>console.log(res));
    console.log(this.iteminbasket);
  }

}
