import { Injectable } from '@angular/core';
import { Users } from '../../model/users.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserserveService {
  readonly authApiUrl = 'http://localhost:5197/api/auth/userauth';

  authToken: string;
  userid: number;

  constructor(private objHttp:HttpClient) { }

  public setUserId(id: number) {
    this.userid = id;
  }

  public getUserId(): number {
    return this.userid;
  }
  
  public setAuthToken(token: string) {
    this.authToken = token;
  }

  public authenticateuser(user:Users): Observable<string> {
    return this.objHttp.post(this.authApiUrl, user, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      responseType: 'text' 
    })
    }

}
