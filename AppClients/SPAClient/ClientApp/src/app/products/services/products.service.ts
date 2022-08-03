import { Injectable } from "@angular/core";
import { Observable } from "rxjs/internal/Observable";
import { Product, ProductClient } from "src/app/shared/services/nswaggClient/product.client";

@Injectable({ providedIn: 'root' })
export class ProductService{
  
  constructor(private productclient:ProductClient) {
    
    
  }

  getProducts():Observable<Product[]> {
    return this.productclient.productAll();
  }

}