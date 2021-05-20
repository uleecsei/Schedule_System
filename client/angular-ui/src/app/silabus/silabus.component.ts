import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ScheduleService } from '../core/services/schedule.service';

@Component({
  selector: 'app-silabus',
  templateUrl: './silabus.component.html',
  styleUrls: ['./silabus.component.scss']
})
export class SilabusComponent implements OnInit {
  lessonName = this.route.snapshot.queryParams.lesson;
  files = [];

  constructor(private route: ActivatedRoute, private scheduleService: ScheduleService) { }

  ngOnInit(): void {
    this.scheduleService.getAllFiles().subscribe((files: string[]) => {
      this.files = files;
    });
  }
}
