import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddAnnouncementFormComponent } from './add-announcement-form/add-announcement-form.component';
import { Routes } from '@angular/router';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes:Routes=[{path:'add',component:AddAnnouncementFormComponent},
{path:"", component:HomeComponent ,pathMatch:"full"},
{path:"**", redirectTo:""}
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule {

 }
