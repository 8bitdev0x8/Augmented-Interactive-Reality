import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { LoadingController, Platform, ToastController } from '@ionic/angular';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {
  loginForm: FormGroup;
  public hasPermission: boolean;

  constructor(
    private formBuilder: FormBuilder,
    private platform: Platform,
    private router: Router,
    private toastController:ToastController,
    private loadingController:LoadingController,
    private authService:AuthenticationService

  ) {
    this.initializeApp();
    this.loginForm = this.formBuilder.group({
      email: new FormControl(
        '',
        Validators.compose([
          Validators.pattern(
            '[A-Za-z0-9._%+-]{1,}@[a-zA-Z]{3,}([.]{1}[a-zA-Z]{2,}|[.]{1}[a-zA-Z]{2,}[.]{1}[a-zA-Z]{2,})'
          ),
          Validators.required,
        ])
      ),
      password: new FormControl('',Validators.compose([Validators.required,])),
    });

  }

  initializeApp() {
  }

  ngOnInit() {
   
  }

  validation_messages = {
    name: [
      { type: 'required', message: 'Username is required.' },
      {
        type: 'minlength',
        message: 'Username must be at least 4 characters long.',
      },
      {
        type: 'maxlength',
        message: 'Username cannot be more than 25 characters long.',
      },
      {
        type: 'validUsername',
        message: 'Your username has already been taken.',
      },
    ],
    email: [
      { type: 'required', message: 'Email is required.' },
      {
        type: 'pattern',
        message: 'Invalid Email address.',
      },
    ],
    password: [{ type: 'required', message: 'Please enter your password' }],
  };

  login() {
    this.loginForm.markAllAsTouched();
    Object.keys( this.loginForm.controls).forEach(key => {
      this.loginForm.controls[key].markAsDirty();
     });
    if (this.loginForm.valid) {
      console.log(this.loginForm.value)
      this.logInFirebase(this.loginForm.value.email,this.loginForm.value.password)
      // this.router.navigate(['home'], { replaceUrl: true });
    }
  }

  logInFirebase(email, password) {
    this.authService.SignIn(email, password)
      .then((res) => {
        console.log(res)
        if(res.user.emailVerified) {
          this.authService.SetUserData(res.user)
          this.router.navigate(['dashboard']);          
        } else {
          window.alert('Email is not verified')
          return false;
        }
      }).catch((error) => {
        window.alert(error.message)
      })
  }



  forgotPassword() {
    this.router.navigate(['forgot-password']);
  }

  goToSignUp(){
    this.router.navigate(['sign-up']);
  }

  handleResponse(data){
    this.loadingController.dismiss()
    console.log(data)
    localStorage.setItem("member_id",data.member_id)
    this.router.navigate(['home'],{replaceUrl:true})
  }
  handleError(error){
    this.loadingController.dismiss()
    console.log(error)
    this.presentToast(error.error.message)

  }


  async presentToast(msg) {
    const toast = await this.toastController.create({
      message: msg,
      duration: 2000,
      color: 'danger',
      position: 'middle',
    });
    toast.present();
  }

  async presentLoading() {
    const loading = await this.loadingController.create({
      spinner: 'crescent',
      cssClass: 'custom-spinner',

      showBackdrop: true,
    });
    await loading.present();
  }
}
