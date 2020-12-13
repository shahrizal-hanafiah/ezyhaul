import { FlexLayoutModule } from '@angular/flex-layout';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OffersRoutingModule } from './offers-routing.module';
import { OffersComponent } from './offers/offers.component';
import { MatTableModule, MatIconModule, MatButtonModule, MatSelectModule, MatCardModule, MatDialogModule, MatGridListModule, MatDatepickerModule } from '@angular/material';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MomentModule } from 'ngx-moment';
import { OfferDetailCreateComponent } from './offer-detail-create/offer-detail-create.component';
import { OfferDetailEditComponent } from './offer-detail-edit/offer-detail-edit.component';
import { FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@NgModule({
  declarations: [OffersComponent, OfferDetailCreateComponent, OfferDetailEditComponent],
  imports: [
    CommonModule,
    OffersRoutingModule,
    FlexLayoutModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    ReactiveFormsModule,
    MatCardModule,
    MatDialogModule,
    MatGridListModule,
    MomentModule.forRoot(),
    
  ]
})
export class OffersModule { }
