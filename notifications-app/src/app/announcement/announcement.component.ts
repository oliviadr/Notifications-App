import { Component, Input } from '@angular/core';
import { AnnouncementService } from '../services/announcement.service';

@Component({
  selector: 'app-announcement',
  templateUrl: './announcement.component.html',
  styleUrls: ['./announcement.component.scss']
})
export class AnnouncementComponent {
  
  @Input() message: string;
  @Input() title: string;
  @Input() author: string;
  @Input() id:string;
  @Input() imageUrl:string;

  constructor(private announcementService:AnnouncementService)
{

}

deleteAnnouncement (id:string)
{
  this.announcementService.deleteAnnouncement(id);
  window.location.reload();
}
}
