import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DefaultComponent } from './default/default.component';
 import { HomeComponent } from 'src/app/modules/home/home.component';
import { PostsComponent } from 'src/app/modules/posts/posts.component';
import { RouterModule } from '@angular/router';
import { FlexLayoutModule } from '@angular/flex-layout';
import { SharedModule } from 'src/app/shared/shared.module';
import { LoginComponent } from 'src/app/modules/login/login.component';
import { ProductComponent } from 'src/app/modules/product/product.component';
import { BasketComponent } from 'src/app/modules/basket/basket.component';



@NgModule({
  declarations: [
    DefaultComponent,
     HomeComponent,
    PostsComponent,
    ProductComponent,
    BasketComponent
  ],
  
  imports: [
    CommonModule,
    RouterModule,
    FlexLayoutModule,
      SharedModule
  ],
  exports:[RouterModule,HomeComponent,PostsComponent,ProductComponent]
})
export class DefaultModule { }
