import { Component, OnInit } from "@angular/core";
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from "@angular/forms";
import { MatDialogClose, MatDialogRef, MatSnackBar } from "@angular/material";
import { Router } from "@angular/router";
import * as moment from "moment";
import { Offer } from "src/app/models/offer";
import { OfferService } from "../offer.service";

@Component({
  selector: "app-offer-detail-create",
  templateUrl: "./offer-detail-create.component.html",
  styleUrls: ["./offer-detail-create.component.scss"],
})
export class OfferDetailCreateComponent implements OnInit {
  offer: Offer;
  addOfferForm: FormGroup;
  currency: string = "MYR";
  hintColor = "#ff0000";
  matdialog:MatDialogClose;

  constructor(
    private offerService: OfferService,
    public router: Router,
    private fb: FormBuilder,
    private _snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<OfferDetailCreateComponent>
  ) {}

  ngOnInit() {
    this.initializeForm();
  }

  initializeForm() {
    this.addOfferForm = this.fb.group({
      price: ["", [Validators.required,this.isNumberCheck()]],
      currency: [this.currency,Validators.required],
      vehicleSize: ["",Validators.required],
      vehicleBuildUp: ["",Validators.required],
      pickupLocationName: ["",Validators.required],
      pickupDateTime: ["",Validators.required],
      deliveryLocationName: ["",Validators.required],
      deliveryDateTime: ["",Validators.required],
      loadDetail1: "",
      loadDetail2: "",
      loadDetail3: "",
    });
  }

  addOffer() {

    if(this.addOfferForm.invalid)
      return;

    this.offer = this.addOfferForm.value;
    this.offer.pickupDateTime = moment(this.offer.pickupDateTime).unix();
    this.offer.deliveryDateTime = moment(this.offer.deliveryDateTime).unix();
    if(this.offer.deliveryDateTime < this.offer.pickupDateTime)
      return this.offerService.openSnackBar("⚠️Pickup date time should be earlier than delivery date time","Close"); 
    this.offerService.AddOffer(this.addOfferForm.value).subscribe(
      (response) => {
        if(response){
          console.log(response);
          this.offerService.openSnackBar(`✔️ Succesfully added the offer with shipment number ` + response.shipmentNumber,"Close");
          this.closeDialog();
        }
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
