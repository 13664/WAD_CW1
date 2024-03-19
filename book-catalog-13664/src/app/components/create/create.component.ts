import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import {MatInputModule} from '@angular/material/input'
import { MatButtonModule } from '@angular/material/button';
import {MatChipsModule} from '@angular/material/chips'
import { BookcatalogServiceService } from '../../bookcatalog-service.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule,MatSelectModule, MatInputModule, MatButtonModule, MatChipsModule ],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
booksService = inject(BookcatalogServiceService);

router = inject(Router);

cate : any;
cID:number=0;

createBook:any={
  bookId: 0,
  isbn: "",
  title:"",
  yearPublication:0,
  author:"",
  price:0,
  description:"",
  categoryId:0
}
ngOnInit(){
  this.booksService.getAllCategories().subscribe((result)=>{
    this.cate = result
    
  });
};

create(){
  console.log(this.createBook)
  this.createBook.categoryID=this.cID
  this.booksService.create(this.createBook).subscribe(result=>{
    alert("Item saved!")
    this.router.navigateByUrl("home")
  });
};

}
