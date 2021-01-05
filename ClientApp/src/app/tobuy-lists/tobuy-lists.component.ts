import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ToBuyList } from '../models/tobuylist';

@Component({
  selector: 'tobuy-lists',
  templateUrl: './tobuy-lists.component.html',
  styleUrls: ['./tobuy-lists.component.css']
})

export class TobuyListsComponent implements OnInit {
  array: ToBuyList[] = [];
  newListName: string = '';

  constructor(private http: HttpClient) { }

  ngOnInit(): void { 
    this.updateLists();
  }

  onClickAdd(): void {
    this.http.post('/api/lists/add', { name: this.newListName }).subscribe(data => 
      {
        
        this.updateLists();
      }, 
      error => {
        console.log(error);
      })
    this.newListName = '';
  }

  onClickDelete(list) {
    this.http.delete('/api/lists/' + list.id).subscribe(() => {
      this.updateLists();
    });
  }

  updateLists(){
    this.http.get('/api/lists').subscribe((data:ToBuyList[]) => {
      console.log(data);
      this.array = data;
    });
  }

  totalChecked(list): number {
    return list.filter(x => x.isChecked).length;
  }
}
