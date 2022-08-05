import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { SchoolRecordWrite } from '../models/school-record-write.model';
import { SchoolingWrite } from '../models/schooling-write.model';
import { UserQuery } from '../models/user-query.model';
import { UserRead } from '../models/user-read.model';
import { UserWrite } from '../models/user-write.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public path = 'api/User';

  constructor(private http: HttpClient) { }

  public deleteUser(id: string): Observable<any> {
    return this.http.delete(`${environment.URL_API}/${this.path}/Delete/${id}`);
  }

  public getById(id: string): Observable<UserRead> {
    const url = `${environment.URL_API}/${this.path}/GetById/${id}`;
    return this.http.get(url).pipe(take(1), map((response: UserRead) => response));
  }

  public getList(query: UserQuery): Observable<Array<UserRead>> {
    const url = `${environment.URL_API}/${this.path}/GetList`;
    return this.http.post(url, query).pipe(take(1), map((response: Array<UserRead>) => response));
  }

  public createUser(user: UserWrite): Observable<any> {
    const url = `${environment.URL_API}/${this.path}/Create`;
    return this.http.post(url, user).pipe(take(1));
  }

  public updateUser(user: UserWrite): Observable<any> {
    const url = `${environment.URL_API}/${this.path}/Update`;
    return this.http.post(url, user).pipe(take(1));
  }
  
  public addSchoolingUser(Schooling: SchoolingWrite): Observable<any> {
    const url = `${environment.URL_API}/${this.path}/AddSchooling`;
    return this.http.post(url, Schooling).pipe(take(1));
  }
  
  public removeSchoolingUser(userId: string): Observable<any> {
    const url = `${environment.URL_API}/${this.path}/RemoveSchooling/${userId}`;
    return this.http.post(url, null).pipe(take(1));
  }
  
  public addSchoolRecordUser(schoolRecord: SchoolRecordWrite): Observable<any> {
    const url = `${environment.URL_API}/${this.path}/AddSchoolRecord`;
    return this.http.post(url, schoolRecord).pipe(take(1));
  }

  public removeSchoolRecordUser(userId: string): Observable<any> {
    const url = `${environment.URL_API}/${this.path}/RemoveSchoolRecord/${userId}`;
    return this.http.post(url, null).pipe(take(1));
  }
}
