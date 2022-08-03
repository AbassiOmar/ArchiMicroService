import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { PostsComponent } from './posts/posts.component';
import { LoginComponent } from './login/login.component';



@NgModule({
  declarations: [HomeComponent, PostsComponent],
  imports: [
    CommonModule
  ]
})
export class ModulesModule { }
