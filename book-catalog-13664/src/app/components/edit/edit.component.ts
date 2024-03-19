import { JsonpInterceptor } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit ,inject} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput, MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { BookcatalogServiceService } from '../../bookcatalog-service.service';
import { Action } from 'rxjs/internal/scheduler/Action';
import { ActivatedRoute } from '@angular/router';
import {Router} from '@angular/router';
import { Books } from '../../Books';
import { resourceLimits } from 'worker_threads';
import { Console } from 'console';


@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, FormsModule, MatInputModule, MatButtonModule],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent implements OnInit {
  constructor(
   
  

    private cdr: ChangeDetectorRef  
  ) { }
  bookService = inject(BookcatalogServiceService);
  activatedRoute = inject(ActivatedRoute);
  router = inject(Router);
  editBook: Books={
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


  cate : any;
  cID:number=0;
  
 
  categoryObject: any;
  selected:any;
 


  ngOnInit(): void {
    this.bookService.getByID(this.activatedRoute.snapshot.params["id"]).subscribe(result => {
      this.editBook = result;
    
      this.selected = this.editBook.categoryId;
      // Call detectChanges() after updating values
      this.cdr.detectChanges();
    });

    this.bookService.getAllCategories().subscribe((result) => {
      this.categoryObject = result;
    
      // Call detectChanges() after updating values
      this.cdr.detectChanges();
    });
  }

  toHome() {
    this.router.navigateByUrl("home");
  }

  edit() {
    this.editBook.categoryId = this.cID;
    // Call detectChanges() after updating values
    this.cdr.detectChanges();
    this.editBook.category = this.categoryObject[this.findIndexByID(this.categoryObject, this.cID)];
    this.bookService.edit(this.editBook.bookId, this.editBook).subscribe((res) => {
      alert("Changes have been updated");
      this.router.navigateByUrl("home");
    });
  }
   findIndexByID(jsonArray:any[], indexToFind:number): number{
    return jsonArray.findIndex((item) => item.id === indexToFind)
  }
}
