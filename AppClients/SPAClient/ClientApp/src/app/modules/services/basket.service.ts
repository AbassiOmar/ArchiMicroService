import { Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { BasketCheckoutModel, BasketModel, BFFProductClient } from "src/app/shared/services/nswaggClient/BFFProductClient";
import { Product, ProductClient} from "src/app/shared/services/nswaggClient/product.client";

@Injectable({ providedIn: 'root' })
export class BasketService{
  
  constructor(private productclient:BFFProductClient) {
    
    
  }

  getBusketByUserNAme(userName:string):Observable<BasketModel> {
    return this.productclient.getBusketByUserName(userName);
  }

  addElementToBasket(item :BasketModel ):Observable<BasketModel>{
    return this.productclient.basket(item);
  }

  validateBasket(basketchekout:BasketCheckoutModel){

    return this.productclient.checkout(basketchekout);
  }
}