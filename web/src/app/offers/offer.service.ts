import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Offer } from '../models/offer';
import { MatSnackBar } from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class OfferService {
  durationInSeconds = 5;

  constructor(private httpClient: HttpClient,private _snackBar: MatSnackBar) { }

  GetOffers(): Observable<Offer[]> {
    return this.httpClient.get<Offer[]>(`${environment.api}/api/offers`);
  }

  AddOffer(model:Offer):Observable<any>{
    
    return this.httpClient.post<any>(`${environment.api}/api/offers`,model);
  }

  UpdateOffer(model:Offer):Observable<string>{
    return this.httpClient.put<string>(`${environment.api}/api/offers`,model);
  }

  DeleteOffer(id:string):Observable<string>{
    return this.httpClient.delete<string>(`${environment.api}/api/offers/${id}`);
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: this.durationInSeconds*1000
    });
  }

}