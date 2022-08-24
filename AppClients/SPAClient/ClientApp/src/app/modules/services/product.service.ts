import { Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { BFFProductClient } from "src/app/shared/services/nswaggClient/BFFProductClient";
import { Product, ProductClient} from "src/app/shared/services/nswaggClient/product.client";

@Injectable({ providedIn: 'root' })
export class ProductService{
  
  constructor(private productclient:BFFProductClient) {
    
    
  }

  getProducts():Observable<Product[]> {
    return this.productclient.product();
  }

}