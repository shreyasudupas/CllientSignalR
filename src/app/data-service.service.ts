import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataServiceService {

  constructor(private _http:HttpClient) { }

  getAllMessage(){

    return this._http.get("http://localhost:61525/api/Home/GetAllMessages");
    
  }
}
