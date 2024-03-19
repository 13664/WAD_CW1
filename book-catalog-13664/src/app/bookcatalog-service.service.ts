import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Books } from './Books';

@Injectable({
  providedIn: 'root'
})
export class BookcatalogServiceService {
 httpClient= inject(HttpClient);
  constructor() { }

  getAllBooks(){
    return this.httpClient.get<Books[]>( "http://localhost:5145/api/Book/GetAll" )
  };
  getByID(id:number){
    return this.httpClient.get<Books>("http://localhost:5145/api/Book/GetById/" + id)
  };

  edit(id:number, item:Books){
    return this.httpClient.put(`http://localhost:5145/api/Book/Update/${id}`, item)
  };

  delete(id:number){
    return this.httpClient.delete("http://localhost:5145/api/Book/Delete?id="+id)
  };
  create(item:Books){
    console.log(item)
    return this.httpClient.post<Books>("http://localhost:5145/api/Book/Create", item )
  };

  getAllCategories(){
    return this.httpClient.get("http://localhost:5145/api/Category/GetAll")
  };
}
