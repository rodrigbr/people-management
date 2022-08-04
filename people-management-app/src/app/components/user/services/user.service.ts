import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserQuery } from '../models/user-query.model';
import { UserRead } from '../models/user-read.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public path = 'api/User';

  constructor(private http: HttpClient) { }

  public deleteUser(email: string): Observable<any> {
    return this.http.delete(`${environment.URL_API}/${this.path}/DeleteUser?email=${email}`);
  }

  public getById(id: string): Observable<UserRead> {
    const url = `${environment.URL_API}/${this.path}/GetById/${id}`;
    return this.http.get(url).pipe(take(1), map((response: UserRead) => response));
  }

  public getList(query: UserQuery): Observable<Array<UserRead>> {
    const url = `${environment.URL_API}/${this.path}/GetList`;
    return this.http.post(url, query).pipe(take(1), map((response: Array<UserRead>) => response));
  }

  //CreateUser
  //UpdateUser
  //AddSchooling
  //RemoveSchooling
  //AddSchooolRecord
  //RemoveSchoolRecord
}
