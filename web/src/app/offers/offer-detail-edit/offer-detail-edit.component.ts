import { Component, Inject, OnInit } from "@angular/core";
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from "@angular/forms";
import { MatDialogClose, MatDialogRef, MatSnackBar, MAT_DIALOG_DATA } from "@angular/material";
import { Router } from "@angular/router";
import * as moment from "moment";
import { Offer } from "src/app/models/offer";
import { OfferService } from "../offer.service";
import { DialogData } from "../offers/offers.component";

@Component({
  selector: 'app-offer-detail-edit',
  templateUrl: './offer-detail-edit.component.html',
  styleUrls: ['./offer-detail-edit.component.scss']
})
export class OfferDetailEditComponent implements OnInit {
  offer: Offer;
  updateOfferForm: FormGroup;
  currency: string = "MYR";
  hintColor = "#ff0000";
  matdialog:MatDialogClose;

  constructor(
    private offerService: OfferService,
    public router: Router,
    private fb: FormBuilder,
    private _snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<OfferDetailEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}

  ngOnInit() {
    this.initializeForm();
  }

  initializeForm() {
    this.updateOfferForm = this.fb.group({
      id: [this.data.offer.id,Validators.required],
      shipmentNumber: [this.data.offer.shipmentNumber, Validators.required],
      price: [this.data.offer.price, [Validators.required,this.isNumberCheck()]],
      currency: [this.currency,Validators.required],
      vehicleSize: [this.data.offer.vehicleSize,Validators.required],
      vehicleBuildUp: [this.data.offer.vehicleBuildUp,Validators.required],
      pickupLocationName: [this.data.offer.pickupLocationName,Validators.required],
      pickupDateTime: [moment.unix(this.data.offer.pickupDateTime).format("YYYY-MM-DDThh:mm"),Validators.required],
      deliveryLocationName: [this.data.offer.deliveryLocationName,Validators.required],
      deliveryDateTime: [moment.unix(this.data.offer.deliveryDateTime).format("YYYY-MM-DDThh:mm"),Validators.required],
      loadDetail1: this.data.offer.loadDetail1,
      loadDetail2: this.data.offer.loadDetail2,
      loadDetail3: this.data.offer.loadDetail3,
    });
  }

  updateOffer() {
    if(this.updateOfferForm.invalid)
      return;

    this.offer = this.updateOfferForm.value;
    this.offer.pickupDateTime = moment(this.offer.pickupDateTime).unix();
    this.offer.deliveryDateTime = moment(this.offer.deliveryDateTime).unix();
    if(this.offer.deliveryDateTime < this.offer.pickupDateTime)
      return this.offerService.openSnackBar("⚠️Pickup date time should be earlier than delivery date time","Close"); 
    this.offerService.UpdateOffer(this.updateOfferForm.value).subscribe(
      (response) => {
        this.offerService.openSnackBar("✔️ Succesfully updated the offer","Close");
        this.closeDialog();
      },
      (error) => {
        this.offerService.openSnackBar(" ⛔ " + error.error,"Close");
        console.log(error);
      }
    );
  }

  isNumberCheck(): ValidatorFn {
    return  (c: AbstractControl): {[key: string]: boolean} | null => {
      let number = /^[.\d]+$/.test(c.value) ? +c.value : NaN;
      if (number !== number) {
        return { 'value': true };
      }

      return null;
    };
  }

  closeDialog() {
    this.dialogRef.close();
  }

}
