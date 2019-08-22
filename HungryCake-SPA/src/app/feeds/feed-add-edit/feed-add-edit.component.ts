import { Component, OnInit } from '@angular/core';
import { Feed } from 'src/app/_models/feed';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-feed-add-edit',
  templateUrl: './feed-add-edit.component.html',
  styleUrls: ['./feed-add-edit.component.css']
})
export class FeedAddEditComponent implements OnInit {
  user: User;
  feed: Feed;
  feedForm: FormGroup;

  constructor(private authService: AuthService, private alertify: AlertifyService,
              private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
  }

  createFeedForm() {
    this.feedForm = this.fb.group({
      feedName: ['', Validators.required],
      urlSite: ['',  Validators.required],
      urlFeed: ['',  Validators.required],
      topic: ['',  Validators.required],
      language: ['', Validators.required],
      isActive: ['', Validators.required]
    });
  }

  addFeed() {
    if (this.feedForm.valid) {
      this.user = Object.assign({}, this.feedForm.value);
      this.authService.register(this.user).subscribe(() => {
        this.alertify.success('Registration successful');
      }, error => {
        this.alertify.error(error);
      }, () => {
        this.authService.login(this.user).subscribe(() => {
          this.router.navigate(['/feeds']);
        });
      });
    }
  }

}
