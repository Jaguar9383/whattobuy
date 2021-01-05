import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { AppComponent }   from './app.component';
import { TobuyListsComponent } from './tobuy-lists/tobuy-lists.component';
import { ProductListComponent } from './product-list/product-list.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
    imports:      [ BrowserModule, FormsModule, AppRoutingModule, HttpClientModule ],
    declarations: [ AppComponent, TobuyListsComponent, ProductListComponent ],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }