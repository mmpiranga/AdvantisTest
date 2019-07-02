import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  apiURL: string = environment.apiURL;

  constructor(private http: HttpClient) { }

  public getProducts(): Observable<any> {
    debugger;
    const url = `${this.apiURL}/Product/GetAllProducts`
    return this.http.get<any>(url, { observe: 'response' }).pipe(map(resp => {
      return resp
    }));
  };

  public addProduct(employee: Product): Observable<any> {
    debugger;
    const url = `${this.apiURL}/Product/AddProduct`
    return this.http.post<any>(url, employee, { observe: 'response' })
      .pipe(
        map(resp => {
          return resp;
        }))
  };

  public editProduct(employee: Product): Observable<any> {
    debugger;
    const url = `${this.apiURL}/Product/EditProduct`
    return this.http.put<any>(url, employee, { observe: 'response' })
      .pipe(
        map(resp => {
          return resp;
        }))
  };

  public deleteProduct(id: number): Observable<any> {
    debugger;
    const url = `${this.apiURL}/Product/RemoveProduct/` + id;
    return this.http.delete<any>(url, { observe: 'response' })
      .pipe(
        map(resp => {
          return resp;
        }))
  };
}
