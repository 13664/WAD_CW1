import { Component, inject } from '@angular/core';
import { MatChipsModule } from '@angular/material/chips';
import { MatCardModule } from '@angular/material/card';
import { Books } from '../../Books';
import { BookcatalogServiceService } from '../../bookcatalog-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [MatChipsModule, MatCardModule],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {

  detailsBook:Books={
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

  serviceBook= inject(BookcatalogServiceService)
  activatedRoute = inject(ActivatedRoute)
  ngOnInit(){
    this.serviceBook.getByID(this.activatedRoute.snapshot.params["id"]).subscribe((resultedItem)=>{
      this.detailsBook=resultedItem
    });
  }
}
