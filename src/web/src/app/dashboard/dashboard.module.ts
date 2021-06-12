import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AngularFireStorageModule} from '@angular/fire/storage';
import { AngularFireModule} from '@angular/fire';

import { IonicModule } from '@ionic/angular';

import { DashboardPageRoutingModule } from './dashboard-routing.module';

import { DashboardPage } from './dashboard.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DashboardPageRoutingModule,
    AngularFireStorageModule,
    AngularFireModule.initializeApp({apiKey: "AIzaSyDY9lsJLcMRfi39eoMyeFzeBA8hd0P4FvQ",
    authDomain: "augmented-interactive-re-69a5e.firebaseapp.com",
    projectId: "augmented-interactive-re-69a5e",
    storageBucket: "augmented-interactive-re-69a5e.appspot.com",
    messagingSenderId: "774468452808",
    appId: "1:774468452808:web:8aed54c8380585fb2f40fd"})
  
  ],
  declarations: [DashboardPage]
})
export class DashboardPageModule {}
