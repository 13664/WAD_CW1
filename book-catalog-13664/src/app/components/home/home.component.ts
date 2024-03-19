import { Component, Input, inject } from '@angular/core';
import { Books } from '../../Books';
import {MatTableModule} from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { BookcatalogServiceService } from '../../bookcatalog-service.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatTableModule, MatButtonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  router = inject(Router);
  booksService=inject(BookcatalogServiceService);
  items:Books[]=[];
  ngOnInit(){
  this.booksService.getAllBooks().subscribe((result)=>{this.items = result});
  console.log(this.items)
  }

derivedColummns:string[]=['BookID', 'ISBN', 'Title', 'YearPublished', 'Author', 'Price', 'Description', 'CategoryName', 'Actions'];

EditClicked(itemID:number){
  console.log(itemID, "from edit");
  this.router.navigateByUrl("/edit/"+itemID);
};
DeleteClicked(itemID:number){
  console.log(itemID, "from delete");
  this.router.navigateByUrl("/delete/"+itemID);
};
DetailsClicked(itemID:number){
  console.log(itemID, "from details");
  this.router.navigateByUrl("/details/"+itemID);
}
}
