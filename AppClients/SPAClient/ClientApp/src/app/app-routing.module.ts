import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DefaultComponent } from './layouts/default/default/default.component';
// import { HomeComponent } from './modules/home/home.component';
import { PostsComponent } from './modules/posts/posts.component';
import { LoginComponent } from './modules/login/login.component';
import { FullwidthModule } from './layouts/fullwidth/fullwidth.module';
import { FullwidthComponent } from './layouts/fullwidth/fullwidth/fullwidth.component';
import { ProductComponent } from './modules/product/product.component';
import { HomeComponent } from './modules/home/home.component';


const routes: Routes = [
  {
    path: '', component: DefaultComponent, children:
      [
        { path: '', component: HomeComponent },
        {path:'posts',component:PostsComponent},
        {path:'products',component:ProductComponent}
      ]
  },
  {
    path: '', component: FullwidthComponent, children: [{
      path:'login',component:LoginComponent
    }]
  }
];
@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
