import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/services/nswaggClient/product.client';
import { ProductService } from '../services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  products: Product[];
  constructor(private productService:ProductService) { }

  ngOnInit() {

    this.productService.getProducts().subscribe(result => {
      this.products = result;
    });
  }

}
