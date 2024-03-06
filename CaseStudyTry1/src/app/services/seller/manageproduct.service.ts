import { Injectable } from '@angular/core';
import { Products } from '../../model/products.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Sellers } from '../../model/sellers.model';
import { Observable, catchError, throwError } from 'rxjs';
import { Categories } from '../../model/categories.model';


@Injectable({
  providedIn: 'root'
})
export class ManageproductService {
  readonly prodApiUrl = 'http://localhost:5197/api/products';
  readonly catApiUrl = 'http://localhost:5197/api/categories';
  readonly authApiUrl = 'http://localhost:5197/api/auth/sellerauth';

  prodlist: Products[];
  proddata: Products = new Products();
  sellerId: number;
  authToken: string;

    constructor(private objHttp: HttpClient) {}

    public setSellerId(id: number) {
      this.sellerId = id;
    }

    public getSellerId(): number {
      return this.sellerId;
    }

    public setAuthToken(token: string) {
      this.authToken = token;
    }

    public authenticateSeller(seller: Sellers): Observable<string> {
      return this.objHttp.post(this.authApiUrl, seller, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      responseType: 'text' 
      })
    }
    
    public ProductsListForSeller(id: number): Observable<Products[]> {
      this.setSellerId(id);
      const headers = new HttpHeaders({ Authorization: `Bearer ${this.authToken}` }); 
      return this.objHttp.get<Products[]>(`${this.prodApiUrl}/getforseller/${id}`, { headers });
    }

    getCategories(): Observable<Categories[]> {
      return this.objHttp.get<Categories[]>(`${this.catApiUrl}`);
    }

    addProduct(product: Products): Observable<Products> {
      const headers = new HttpHeaders({ Authorization: `Bearer ${this.authToken}` }); 
      return this.objHttp.post<Products>(`${this.prodApiUrl}`, product,{ headers });
    }

    deleteProduct(productId: number): Observable<void> {
      return this.objHttp.delete<void>(`${this.prodApiUrl}/${productId}`);
    }

    public updateproduct()
    {
      return this.objHttp.put(this.prodApiUrl+'/'+this.proddata.ProductId,this.proddata);
    }
}
