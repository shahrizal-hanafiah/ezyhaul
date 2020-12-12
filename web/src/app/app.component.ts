import { Observable } from 'rxjs';
import { OfferService } from './offers/offer.service';
import { Component, OnInit } from '@angular/core';
import { Offer } from './models/offer';

@Component({
  selector: 'app-root',
  template: `
    <!--The content below is only a placeholder and can be replaced.-->
    <div style="text-align:center" class="content">
      <h1>
        Welcome to {{title}}!
      </h1>
    </div>
    <router-outlet></router-outlet>
  `,
  styles: []
})
export class AppComponent {
  title = 'web';
}
