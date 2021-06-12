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
  selector: 'app-sign-up',
  templateUrl: './sign-up.page.html',
  styleUrls: ['./sign-up.page.scss'],
})
export class SignUpPage implements OnInit {
  signUpForm: FormGroup;
  constructor(
    private platform: Platform,
    private formBuilder: FormBuilder,
    private router: Router,
    private toastController: ToastController,
    private loadingController: LoadingController,
    private authService:AuthenticationService
  ) {

  }


  ngOnInit() {
    this.signUpForm = this.formBuilder.group({
      user_name: new FormControl(
        '',
        Validators.compose([
          Validators.maxLength(25),
          Validators.minLength(4),
          Validators.required,
        ])
      ),
      email: new FormControl(
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern(
            '[A-Za-z0-9._%+-]{1,}@[a-zA-Z]{3,}([.]{1}[a-zA-Z]{2,}|[.]{1}[a-zA-Z]{2,}[.]{1}[a-zA-Z]{2,})'
          ),
        ])
      ),
      password: new FormControl(
        '',
        Validators.compose([Validators.required, Validators.minLength(8)])
      ),
      phone: new FormControl(
        '',
        Validators.compose([
          Validators.required,
          Validators.required,
          Validators.maxLength(10),
          Validators.minLength(10),
          Validators.pattern('[0-9]*'),
        ])
      ),
      password_confirmation: new FormControl(
        '',
        Validators.compose([Validators.required, Validators.minLength(4)])
      ),
    });
  }

  //  emailDomainValidator(control: FormControl) {
  //   let passwordagain = control.value.passwordagain;
  //   let password = control.value.password;
  //   console.log(control)
  //      if (passwordagain !== password) {
  //       return {
  //         passwordMismatch: {
  //           message: "Error"
  //         }
  //       }
  //     }

  //   return null;
  // }

  validation_messages = {
    user_name: [
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
    phone: [
      { type: 'required', message: 'Phone is required.' },
      {
        type: 'pattern',
        message: 'Invalid phone number.',
      },
      {
        type: 'minlength',
        message: 'Phone number cannot be less than 10 digits long.',
      },
      {
        type: 'maxlength',
        message: 'Phone number cannot be more than 10 digits long.',
      },
    ],
    password: [
      { type: 'required', message: 'Please enter your password' },
      {
        type: 'minlength',
        message: 'Password must be at least 8 characters long.',
      },
    ],
    password_confirmation: [
      { type: 'required', message: 'Please enter your password' },
      {
        type: 'minlength',
        message: 'Password must be at least 8 characters long.',
      },
      {
        type: 'passwordMismatch',
        message: 'wrong',
      },
    ],
  };

  signUp() {
    console.log(this.signUpForm.value);
    this.signUpForm.markAllAsTouched();
    Object.keys(this.signUpForm.controls).forEach((key) => {
      this.signUpForm.controls[key].markAsDirty();
    });
    this.signUpFirebase(this.signUpForm.value.email,this.signUpForm.value.password)
    // if (this.signUpForm.valid) {
    // }
  }

  signUpFirebase(email, password){
    this.authService.RegisterUser(email, password)      
    .then((res) => {
      console.log(res)
      this.authService.SendVerificationMail()
      this.router.navigate(['verify-email']);
    }).catch((error) => {
      window.alert(error.message)
    })
}

  handleResponse(data) {
    this.loadingController.dismiss();
    console.log(data);
    this.presentToastSuccess(data.message);
    this.router.navigate(['login'])
  }
  handleError(error) {
    this.loadingController.dismiss();
    console.log(error.error);
    console.log(error.error.error[0]);
    this.presentToast(error.error.error[0]);
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
  async presentToastSuccess(msg) {
    const toast = await this.toastController.create({
      message: msg,
      duration: 2000,
      color: 'success',
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
