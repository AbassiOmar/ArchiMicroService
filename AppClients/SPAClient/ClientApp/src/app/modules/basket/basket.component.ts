import { Component, OnInit } from '@angular/core';
import { BasketCheckoutModel, BasketModel, BFFProductClient } from 'src/app/shared/services/nswaggClient/BFFProductClient';
import { BasketService } from '../services/basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {

  baskets:BasketModel;
  constructor(private basketService:BasketService) { }

  ngOnInit() {
    this.basketService.getBusketByUserNAme("abassi").subscribe(result => {
      this.baskets = result;
      console.log('result',result);
      console.log(this.baskets);
    });
  }

  checkoutBasket()
  {
    let basketCheckoutModel:BasketCheckoutModel=new BasketCheckoutModel();
    const sum = this.baskets.items.reduce((accumulator, current) => {
      return accumulator + current.price;
    }, 0);
    basketCheckoutModel.userName="abassi"
    basketCheckoutModel.totalPrice=sum;
    basketCheckoutModel.addressLine="adresse line";
    basketCheckoutModel.cardName="oabassi";
    basketCheckoutModel.cardNumber="9998887775544";
    basketCheckoutModel.country="France";
    basketCheckoutModel.cvv="999";
    basketCheckoutModel.emailAddress="omar@gmail.com";
    basketCheckoutModel.firstName="abassi";
    basketCheckoutModel.lastName="omar";
    basketCheckoutModel.paymentMethod=0;
    basketCheckoutModel.expiration="01/01/2025";
    basketCheckoutModel.state="ok";
    this.basketService.validateBasket(basketCheckoutModel).subscribe(res=>{
      console.log(res);
    });
  }

}
