import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { ProductsModule } from './products/products.module';
import { DefaultModule } from './layouts/default/default.module';
import { AppRoutingModule } from './app-routing.module';
import { FullwidthModule } from './layouts/fullwidth/fullwidth.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    CoreModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ProductsModule,
    AppRoutingModule,
    DefaultModule,
    FullwidthModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
