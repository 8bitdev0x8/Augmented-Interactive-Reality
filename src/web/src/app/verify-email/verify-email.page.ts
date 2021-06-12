import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { defineCustomElements } from '@teamhive/lottie-player/loader';
@Component({
  selector: 'app-verify-email',
  templateUrl: './verify-email.page.html',
  styleUrls: ['./verify-email.page.scss'],
})
export class VerifyEmailPage implements OnInit {

  constructor(public authService:AuthenticationService) {
    defineCustomElements(window);
   }

  ngOnInit() {
  }

}
