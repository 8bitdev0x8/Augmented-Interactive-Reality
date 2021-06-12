import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { defineCustomElements } from '@teamhive/lottie-player/loader';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  constructor(private router:Router) {
    defineCustomElements(window);
  }
login(){
this.router.navigate(["login"])
}
onClick(){
  let url = 'https://github.com/8bitdev0x8/Augmented-Interactive-Reality/releases';
  window.open(url);

}

discovermore()
{
  let url = 'https://github.com/8bitdev0x8/Augmented-Interactive-Reality'
  window.open(url);
}
}

