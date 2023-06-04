import { Component, OnInit } from '@angular/core';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  announcements: Announcement[]=[]
  selectedCategory:Category
  title: any;
  filteredAnnouncements:Announcement[]
  
  constructor ( private announcementService: AnnouncementService ){
    
  }
  ngOnInit():void{
    this.announcementService.serviceCall();
    this.announcementService.getAnnouncements().subscribe(announcements=>{
      this.announcements=announcements;
      this.filteredAnnouncements=this.announcements;
    })
  }
  FilterAnnouncementBasedOnCategory(category:Category):void{
    if(category==null)
    this.filteredAnnouncements=this.announcements
    else
    this.filteredAnnouncements=this.announcements.filter(a=>a.categoryId==category.id);
    

  }
}
