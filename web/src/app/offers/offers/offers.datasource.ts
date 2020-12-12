import { Observable } from 'rxjs';
import { OfferService } from './../offer.service';
import { DataSource } from '@angular/cdk/table';
import { Offer } from 'src/app/models/offer';

export class OfferDataSource extends DataSource<any> {
    constructor(private offerService: OfferService) {
        super();
    }

    connect(): Observable<Offer[]> {
        return this.offerService.GetOffers();
    }

    // tslint:disable-next-line:no-empty
    disconnect() {}
}