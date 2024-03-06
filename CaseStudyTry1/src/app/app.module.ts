import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './navigation/nav/nav.component';
import { CustomerComponent } from './login/customer/customer.component';
import { SellerComponent } from './login/seller/seller.component';
import { AdminComponent } from './login/admin/admin.component';
import { CustomerregistrationComponent } from './register/customerregistration/customerregistration.component';
import { SellerregistrationComponent } from './register/sellerregistration/sellerregistration.component';
import { HomeComponent } from './miscellenous/home/home.component';
import { SellerhomeComponent } from './seller/sellerhome/sellerhome.component';
import { SellernavComponent } from './navigation/sellernav/sellernav.component';
import { AboutComponent } from './miscellenous/about/about.component';
import { HttpClientModule } from '@angular/common/http';
import { ManageproductsComponent } from './seller/manageproducts/manageproducts.component';
import { FormsModule } from '@angular/forms';
import { AddNewProductComponent } from './seller/add-new-product/add-new-product.component';
import { UsernavComponent } from './navigation/usernav/usernav.component';
import { ProfileComponent } from './user/profile/profile.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    CustomerComponent,
    SellerComponent,
    AdminComponent,
    CustomerregistrationComponent,
    SellerregistrationComponent,
    HomeComponent,
    SellerhomeComponent,
    SellernavComponent,
    AboutComponent,
    ManageproductsComponent,
    AddNewProductComponent,
    UsernavComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
