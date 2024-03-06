import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavComponent } from './navigation/nav/nav.component';
import { CustomerComponent } from './login/customer/customer.component';
import { SellerComponent } from './login/seller/seller.component';
import { AdminComponent } from './login/admin/admin.component';
import { CustomerregistrationComponent } from './register/customerregistration/customerregistration.component';
import { SellerregistrationComponent } from './register/sellerregistration/sellerregistration.component';
import { HomeComponent } from './miscellenous/home/home.component';
import { SellerhomeComponent } from './seller/sellerhome/sellerhome.component';
import { AboutComponent } from './miscellenous/about/about.component';
import { ManageproductsComponent } from './seller/manageproducts/manageproducts.component';
import { AddNewProductComponent } from './seller/add-new-product/add-new-product.component';
import { ProfileComponent } from './user/profile/profile.component';

const routes: Routes = [
  {path:"",component:HomeComponent},
  {path:"about",component:AboutComponent},
  {path:"customerlogin",component:CustomerComponent},
  {path:"sellerlogin",component:SellerComponent},
  {path:"adminlogin",component:AdminComponent},
  {path:"customerregister",component:CustomerregistrationComponent},
  {path:"sellerregister",component:SellerregistrationComponent},
  {path:"sellerhome",component:SellerhomeComponent},
  {path:"manageproductseller",component:ManageproductsComponent},
  {path:"addnewproduct",component:AddNewProductComponent},
  {path:"userprofile",component:ProfileComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
