import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sellernav',
  templateUrl: './sellernav.component.html',
  styleUrl: './sellernav.component.css'
})
export class SellernavComponent {

  constructor(public selnav:Router){}
  
  logout() {
    const logoutConfirmed = confirm("Are you sure you want to logout?");
    if (logoutConfirmed) {
      this.selnav.navigate(['/']);
    }
  }
}
