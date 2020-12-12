import { FlexLayoutModule } from '@angular/flex-layout';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OffersRoutingModule } from './offers-routing.module';
import { OffersComponent } from './offers/offers.component';
import { MatTableModule, MatIconModule, MatButtonModule } from '@angular/material';
import { MomentModule } from 'ngx-moment';
import { OfferDetailCreateComponent } from './offer-detail-create/offer-detail-create.component';
import { OfferDetailEditComponent } from './offer-detail-edit/offer-detail-edit.component';

@NgModule({
  declarations: [OffersComponent, OfferDetailCreateComponent, OfferDetailEditComponent],
  imports: [
    CommonModule,
    OffersRoutingModule,
    FlexLayoutModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MomentModule.forRoot()
  ]
})
export class OffersModule { }
