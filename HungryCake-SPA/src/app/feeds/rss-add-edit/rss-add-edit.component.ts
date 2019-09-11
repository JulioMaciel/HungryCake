import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Router } from '@angular/router';
import { Category } from 'src/app/_models/category';
import { Rss, Language } from 'src/app/_models/rss';
import { FeedService } from 'src/app/_services/feed.service';
import { RssItem } from 'src/app/_models/rssItem';

@Component({
  selector: 'app-rss-add-edit',
  templateUrl: './rss-add-edit.component.html',
  styleUrls: ['./rss-add-edit.component.css']
})
export class RssAddEditComponent implements OnInit {
  rss: Rss;
  rssForm: FormGroup;
  isCollapsed = true;
  rssPreviewItems: RssItem[] = [];

  constructor(private authService: AuthService, private alertify: AlertifyService,
              private fb: FormBuilder, private router: Router,
              private feedService: FeedService) { }

  ngOnInit() {
    this.createRssForm();
  }

  createRssForm() {
    this.rssForm = this.fb.group({
      name: ['', Validators.required],
      urlSite: ['',  Validators.required],
      url: ['',  Validators.required],
      categoryName: ['',  Validators.required],
      categoryId: ['',  Validators.required],
      language: [Language.English, Validators.required],
      isActive: [true, Validators.required]
    });
  }

  onSelectedToFeed(cat: Category) {
    // this.rss.category = cat;
    this.rssForm.controls.categoryName.setValue(cat.english);
    this.rssForm.controls.categoryId.setValue(cat.id);
    this.isCollapsed = true;
  }

  onPreviewRss() {
    const urlRss = this.rssForm.controls.urlRss.value;
    this.feedService.getRssPreview(urlRss).subscribe(data => {
      this.rssPreviewItems = data;
    }, error => {
      this.alertify.error(error);
    });
  }

  addRss() {
    if (this.rssForm.valid) {
      console.log('rssForm validou!');
      this.rss = Object.assign({}, this.rssForm.value);
      this.rss.creatorId = +this.authService.decodedToken.nameid;
      console.log(this.rss);
      this.feedService.add(this.rss).subscribe(() => {
        this.alertify.success('RSS successful added!');
      }, error => {
        this.alertify.error(error);
      }, () => {
        this.rssForm.reset();
      });
    }
  }

}
