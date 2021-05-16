import { Component, Input, NgZone, OnInit } from '@angular/core';
import { Cloudinary } from '@cloudinary/angular-5.x';
import { FileItem, FileUploader, FileUploaderOptions, ParsedResponseHeaders } from 'ng2-file-upload';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { ScheduleService } from '../core/services/schedule.service';

const mockedRoomData = [
  {
    name: 'Практичне занняття.doc',
    fileLink: 'https://www.google.com/'
  },
  {
    name: 'Практичне занняття.pdf',
    fileLink: 'https://www.google.com/'
  },
  {
    name: 'Практичне занняття.gif',
    fileLink: 'https://www.google.com/'
  }
];

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.scss']
})
export class RoomComponent implements OnInit {
  materials = mockedRoomData;
  lessonName = this.route.snapshot.queryParams.lesson;

  @Input() responses: Array<any>;

  private hasBaseDropZoneOver = false;
  uploader: FileUploader;
  private title: string;
  currentUser = this.authService.getCurrentUser();

  constructor(
    private cloudinary: Cloudinary,
    private zone: NgZone,
    private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
    private scheduleService: ScheduleService
  ) {
    this.responses = [];
    this.title = '';
  }

  ngOnInit(): void {
    this.scheduleService.getAllFiles().subscribe((files) => {
      this.materials = files;
    });
    // Create the file uploader, wire it to upload to your account
    const uploaderOptions: FileUploaderOptions = {
      url: `https://api.cloudinary.com/v1_1/${this.cloudinary.config().cloud_name}/upload`,
      // Upload files automatically upon addition to upload queue
      autoUpload: true,
      // Use xhrTransport in favor of iframeTransport
      isHTML5: true,
      // Calculate progress independently for each uploaded file
      removeAfterUpload: true,
      // XHR request headers
      headers: [
        {
          name: 'X-Requested-With',
          value: 'XMLHttpRequest'
        }
      ]
    };

    this.uploader = new FileUploader(uploaderOptions);

    this.uploader.onSuccessItem = (item, response, status, headers) =>
      this.onSuccessItem(item, response, status, headers);
    this.uploader.onErrorItem = (item, response, status, headers) =>
      this.onErrorItem(item, response, status, headers);


    this.uploader.onBuildItemForm = (fileItem: any, form: FormData): any => {
      // Add Cloudinary unsigned upload preset to the upload form
      form.append('upload_preset', this.cloudinary.config().upload_preset);

      // Add file to upload
      form.append('file', fileItem);

      // Use default "withCredentials" value for CORS requests
      fileItem.withCredentials = false;
      return { fileItem, form };
    };

  }

  onSuccessItem(item: FileItem, response: string, status: number, headers: ParsedResponseHeaders): any {
    const data = JSON.parse(response); // success server response
    this.scheduleService.postFile(data.original_filename, data.url);
  }

  onErrorItem(item: FileItem, response: string, status: number, headers: ParsedResponseHeaders): any {
    const error = JSON.parse(response); // error server response
  }

  onSilabusEnter(): void {
    this.router.navigate(['/silabus'], { queryParams: { lesson: this.lessonName } });
  }
}
