import { Injectable } from "@angular/core";
import { UserModel } from "./user.model";
import { Observable, throwError } from "rxjs";
import { catchError, map } from "rxjs/operators";
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse,
} from "@angular/common/http";

@Injectable({
  providedIn: "root",
})
export class UserService {
  endpoint: string = "https://localhost:44334/api/v1/Users";
  headers = new HttpHeaders().set("Content-Type", "application/json");

  constructor(private http: HttpClient) {}

  CreateUser(data: UserModel): Observable<any> {
    const API_URL = `${this.endpoint}`;
    return this.http.post(API_URL, data).pipe(catchError(this.errorMgmt));
  }

  GetUsers() {
    return this.http.get(`${this.endpoint}`);
  }

  GetUserById(id): Observable<any> {
    const API_URL = `${this.endpoint}/${id}`;
    return this.http.get(API_URL, { headers: this.headers }).pipe(
      map((res: Response) => {
        return res || {};
      }),
      catchError(this.errorMgmt)
    );
  }

  UpdateUser(id, data): Observable<any> {
    const API_URL = `${this.endpoint}/${id}`;
    return this.http.put(API_URL, data).pipe(catchError(this.errorMgmt));
  }

  DeleteUser(id): Observable<any> {
    var API_URL = `${this.endpoint}/${id}`;
    return this.http.delete(API_URL).pipe(catchError(this.errorMgmt));
  }

  errorMgmt(error: HttpErrorResponse) {
    let errorMessage = "";
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
