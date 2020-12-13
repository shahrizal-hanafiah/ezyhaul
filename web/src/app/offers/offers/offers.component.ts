import { OfferDataSource } from "./offers.datasource";
import { Observable } from "rxjs";
import { Component, OnInit } from "@angular/core";
import { OfferService } from "../offer.service";
import { Offer } from "src/app/models/offer";
import { Router } from "@angular/router";
import { MatDialog } from "@angular/material/dialog";
import { OfferDetailCreateComponent } from "../offer-detail-create/offer-detail-create.component";
import { OfferDetailEditComponent } from "../offer-detail-edit/offer-detail-edit.component";

export interface DialogData {
  offer: Offer;
}

@Component({
  selector: "app-offers",
  templateUrl: "./offers.component.html",
  styleUrls: ["./offers.component.scss"],
})
export class OffersComponent implements OnInit {
  dataSource = new OfferDataSource(this.offerService);
  displayedColumns = [
    "shipmentNumber",
    "price",
    "vehicleSize",
    "vehicleBuildUp",
    "pickupLocationName",
    "pickupDateTime",
    "deliveryLocationName",
    "deliveryDateTime",
    "loadDetail1",
    "loadDetail2",
    "loadDetail3",
    "edit",
    "delete",
  ];
  offers: Observable<Offer[]>;

  constructor(
    private offerService: OfferService,
    public router: Router,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    this.getOffers();
  }

  getOffers() {
    this.offers = this.offerService.GetOffers();

    this.offers.subscribe((offers) => {
      console.log(`offers`, offers);
    });
  }

  openDialog() {
    const dialogRef = this.dialog.open(OfferDetailCreateComponent, {
      width: "600px",
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  updateDialog(offer:Offer) {
    const dialogRef = this.dialog.open(OfferDetailEditComponent, {
      width: "600px",
      data:{offer:offer}
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.getDataSource();
    });
  }

  getDataSource(){
    this.dataSource = new OfferDataSource(this.offerService);
  }

  alertDialog(id: string) {
    if (confirm("⚠️ Do you want to delete the record?")) {
      this.offerService.DeleteOffer(id).subscribe(
        (response) => {
          this.offerService.openSnackBar(
            "✔️ Succesfully deleted the offer",
            "Close"
          );
          this.getDataSource();
        },
        (error) => {
          this.offerService.openSnackBar(
            " ⛔ Something went wrong while deleting the offer",
            ""
          );
        }
      );
    }
  }
}
