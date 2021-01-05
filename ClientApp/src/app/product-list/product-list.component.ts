import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product';

@Component({
  selector: 'product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})

export class ProductListComponent implements OnInit {
  id: string;
  products: Product[] = [];
  newProductName: string = "";

  constructor(private activateRoute: ActivatedRoute, private http: HttpClient ) { 
    this.id = activateRoute.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.updateProducts();
  }

  onClickCheck(product){
    this.http.post('/api/products/check', { id: product.id }).subscribe(data => {
      this.updateProducts();
    }, error => {
      console.log(error);
    });
  }

  onClickAdd() {
    this.http.post('/api/products/' + this.id, { name: this.newProductName, whatToBuyListId: this.id }).subscribe(data => {
      this.updateProducts();
      this.newProductName = '';
    });
  }

  onClickDelete(id){
    this.http.delete('/api/products/' + id).subscribe(data => {
      this.updateProducts();
    })
  }

  updateProducts(){
    this.http.get('/api/products/list/' + this.id).subscribe((data: Product[]) => {
      this.products = data;
    });
  }
}
