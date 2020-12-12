import { OfferDetailEditComponent } from './offer-detail-edit/offer-detail-edit.component';
import { OfferDetailCreateComponent } from './offer-detail-create/offer-detail-create.component';
import { OffersComponent } from './offers/offers.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {path: "", component: OffersComponent},
  {path: "new", component: OfferDetailCreateComponent},
  {path: "edit/:id", component: OfferDetailEditComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OffersRoutingModule { }
