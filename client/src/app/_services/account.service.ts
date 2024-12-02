import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { User } from '../_models/user';
import { catchError, map, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);
  baseUral = 'https://localhost:5001/api/';
  currentUser = signal<User | null>(null);

  login(model: any){
    return this.http.post<User>(this.baseUral + 'account/login', model).pipe(
      map(user =>{
        if(user){
          localStorage.setItem('user', JSON.stringify(user))
          this.currentUser.set(user)
        }
      }),
      catchError(error => {
        console.error('Login failed', error);
        return throwError(error);
      })
    )
  }

  register(model: any){
    return this.http.post<User>(this.baseUral + 'account/register', model).pipe(
      map(user =>{
        if(user){
          localStorage.setItem('user', JSON.stringify(user))
          this.currentUser.set(user)
        }
        return user;
      })
    )
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
}
