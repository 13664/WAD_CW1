import { Component, inject } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { Books } from '../../Books';
import { BookcatalogServiceService } from '../../bookcatalog-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-delete',
  standalone: true,
  imports: [MatChipsModule, MatCardModule, MatButtonModule],
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.css'
})
export class DeleteComponent {
  deleteBook:Books={
    bookId:0,
    isbn:"",
    title:"",
    yearPublication:0,
    author:"",
    price:0,
    description:"",
    categoryId:0,
    category:{
      id:0,
      title:""
    }
  }
  booksService = inject(BookcatalogServiceService);

router = inject(Router);

cate : any;
cID:number=0;
  serviceBook= inject(BookcatalogServiceService)
  activatedRoute = inject(ActivatedRoute)
  ngOnInit(){
    this.booksService.getByID(this.activatedRoute.snapshot.params["id"]).subscribe(result=>{
      this.deleteBook = result;
      
    });

  }

  delete(id:number){
    this.booksService.delete(id).subscribe(
      (result) => {
        alert("Item deleted!");
        this.router.navigateByUrl("home");
      },
      (error) => {
        console.error("Error deleting book:", error);
        // Handle error (e.g., show error message to user)
      }
    );
  }
}
