import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/services/nswaggClient/product.client';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products: Product[];
  constructor(private productService:ProductService) { }

  ngOnInit() {

    this.productService.getProducts().subscribe(result => {
      result.forEach(element => {
        element.imageFile='assets/images/products/'+element.imageFile;
      });
      this.products = result;
    });
  }

}
