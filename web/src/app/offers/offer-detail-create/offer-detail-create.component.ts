import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OfferService } from '../offer.service';

@Component({
  selector: 'app-offer-detail-create',
  templateUrl: './offer-detail-create.component.html',
  styleUrls: ['./offer-detail-create.component.scss']
})
export class OfferDetailCreateComponent implements OnInit {

  constructor(private offerService: OfferService, public router: Router) { }

  ngOnInit() {
  }

}
