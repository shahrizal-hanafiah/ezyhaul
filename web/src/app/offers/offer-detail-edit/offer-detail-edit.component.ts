import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OfferService } from '../offer.service';

@Component({
  selector: 'app-offer-detail-edit',
  templateUrl: './offer-detail-edit.component.html',
  styleUrls: ['./offer-detail-edit.component.scss']
})
export class OfferDetailEditComponent implements OnInit {

  constructor(private offerService: OfferService, public router: Router) { }

  ngOnInit() {
  }

}
