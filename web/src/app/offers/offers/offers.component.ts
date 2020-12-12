import { OfferDataSource } from './offers.datasource';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { OfferService } from '../offer.service';
import { Offer } from 'src/app/models/offer';
import { Router } from '@angular/router';

@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrls: ['./offers.component.scss']
})
export class OffersComponent implements OnInit {

  dataSource = new OfferDataSource(this.offerService);
  displayedColumns = ["shipmentNumber", "price", "vehicleSize", "vehicleBuildUp","pickupLocationName", "pickupDateTime","deliveryLocationName","deliveryDateTime","loadDetail1","loadDetail2","loadDetail3","edit","delete"];
  offers: Observable<Offer[]>;

  constructor(private offerService: OfferService, public router: Router) { }

  ngOnInit() {
    this.offers = this.offerService.GetOffers();

    this.offers.subscribe((offers) => {
      console.log(`offers`, offers);
    });
  }

  alertDialog() {
    alert('alertDialog');
  }

}
