import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import {AngularFireStorage} from '@angular/fire/storage';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.page.html',
  styleUrls: ['./dashboard.page.scss'],
})

export class DashboardPage implements OnInit {

  selectedFile = null;

  constructor(    
    private authService:AuthenticationService,
    private af:AngularFireStorage
    ) { }

  ngOnInit() {
  }

  logout()
  {
    this.authService.SignOut()
  }

  onFileSelected(event){
    this.selectedFile = event.target.files[0];
    console.log(event);
  }

  onUpload(){
    this.af.upload("/360image",this.selectedFile)
    .then((res) => {
      console.log(res)
       {
        window.alert('Uploaded')
        
      }
    }).catch((error) => {
      window.alert(error.message)
    })
    console.log("uploaded");
  }

}
