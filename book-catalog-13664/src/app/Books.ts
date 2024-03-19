export interface Books{
  bookId: number;
  isbn: string;
  title:string;
  yearPublication:number;
  author:string;
  price:number;
  description:string;
  categoryId:number;
  category:{
    id:number;
    title:string;
  }

}