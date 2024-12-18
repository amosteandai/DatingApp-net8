import { HttpClient} from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment';
import { Member } from '../_models/member';
import { of, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  private http = inject(HttpClient);
  baseUral = environment.apiUrl;
  members = signal<Member[]>([]);

  getMembers(){
    return this.http.get<Member[]>(this.baseUral + 'users').subscribe({
      next: members => this.members.set(members)
    })
  }

  getMember(username : string){
    const member = this.members().find(x => x.userName === username);
    if(member) return of(member)

    return this.http.get<Member>(this.baseUral + 'users/' + username)
  }

  updateMember(member : Member){
    return this.http.put(this.baseUral + 'users', member).pipe(
      tap(() =>{
        this.members.update(members => members.map( m => m.userName === member.userName ? member : m))
      })
    )
  }
}
