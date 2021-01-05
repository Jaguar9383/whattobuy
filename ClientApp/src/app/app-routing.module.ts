import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { CommonModule } from '@angular/common';
import { ProductListComponent } from './product-list/product-list.component';
import { TobuyListsComponent } from './tobuy-lists/tobuy-lists.component';

const routes: Routes = [
  { path: 'list/:id', component: ProductListComponent },
  { path: '', component: TobuyListsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})

export class AppRoutingModule { }
