import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';

@Component({
  selector: 'app-add-announcement-form',
  templateUrl: './add-announcement-form.component.html',
  styleUrls: ['./add-announcement-form.component.scss']
})
export class AddAnnouncementFormComponent  {
  title:string;
  author:string;
  imageUrl:string;
  message:string;
  id:string
  selectedCategory:string;
  categories:Category[]=[{id:"1",name:"Course"},{id:"2",name:"General"},{id:"3",name:"Laboratory"},];
  constructor ( private announcementService: AnnouncementService ,private router:Router ){
    
  }
  AddAnnouncement(){
    let announcement:Announcement={
    title:this.title,
    author:this.author,
    imageUrl:this.imageUrl,
    message:this.message,
    categoryId:this.selectedCategory,
    id:this.id
    }
    this.announcementService.addAnnouncement(announcement).subscribe(r=>this.router.navigateByUrl("''"))
    console.log(announcement)
    

  }

}
