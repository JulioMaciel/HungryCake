import { Component, OnInit, Input, ViewChild, Renderer, Renderer2, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from 'src/app/_models/user';
import { AuthService } from 'src/app/_services/auth.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FeedRss } from 'src/app/_models/feeds/feedRss';
import { FeedService } from 'src/app/_services/feed.service';
import { RssItem } from 'src/app/_models/feeds/items/rssItem';

@Component({
  selector: 'app-rss-add-edit',
  templateUrl: './rss-add-edit.component.html',
  styleUrls: ['./rss-add-edit.component.css']
})
export class RssAddEditComponent implements OnInit {
  @Input() rssToEdit: FeedRss;
  rssForm: FormGroup;
  rssPreviewItems: RssItem[] = [];

  constructor(private authService: AuthService, private alertify: AlertifyService,
              private fb: FormBuilder,
              private feedService: FeedService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(async data => {
      console.log(data);
      this.rssToEdit = data.rssToEdit;
    });

    this.createRssForm();
  }

  createRssForm() {
    this.rssForm = this.fb.group({
      name: [this.rssToEdit ? this.rssToEdit.name : '', Validators.required],
      urlSite: [this.rssToEdit ? this.rssToEdit.urlSite : '', Validators.required],
      urlRss: [this.rssToEdit ? this.rssToEdit.urlRss : '', Validators.required],
      newIconPath: [],
      description: [this.rssToEdit ? this.rssToEdit.description : '', Validators.required],
      isActive: [this.rssToEdit ? this.rssToEdit.isActive : true, Validators.required]
    });
  }

  onImportDescription() {
    const urlSite = this.rssForm.controls.urlSite.value;
    if (urlSite) {
      this.feedService.importRssDescription(urlSite).subscribe(data => {
        // tslint:disable-next-line: no-string-literal
        const importedDesc = data['description'];
        this.rssForm.controls.description.setValue(importedDesc);
      }, error => {
        this.alertify.error(error);
      });
    }
  }

  onTryIcon() {
    const urlSite = this.rssForm.controls.urlSite.value;
    if (urlSite) {
      this.feedService.tryRssIcon(urlSite).subscribe(data => {
        // tslint:disable-next-line: no-string-literal
        const iconAttempt = data['icon'];
        this.rssForm.controls.favIconURL.setValue(iconAttempt);
      }, error => {
        this.alertify.error(error);
      });
    }
  }

  onPreviewRss() {
    const urlRss = this.rssForm.controls.urlRss.value;
    this.feedService.getRssPreview(urlRss).subscribe(data => {
      this.rssPreviewItems = data;
    }, error => {
      console.log(error);
      this.alertify.error('The URL RSS seems incorrect.');
    });
  }

  addRss() {
    let newRss: FeedRss;
    newRss = Object.assign({}, this.rssForm.value);
    this.feedService.addRss(newRss).subscribe(() => {
      this.alertify.success('RSS successful added!');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.rssForm.reset();
      this.createRssForm();
      this.rssPreviewItems = [];
    });
  }

  editRss() {
    const toEdit = Object.assign(this.rssToEdit, this.rssForm.value);
    this.feedService.updateRss(toEdit).subscribe(() => {
      this.alertify.success('RSS ' + this.rssToEdit.name + ' was updated!');
    }, error => {
      this.alertify.error(error);
    }, () => {
      // TODO
    });
  }

  useDefaulRssFeed() {
    const urlSite = this.rssForm.controls.urlSite.value;
    this.rssForm.controls.urlRss.setValue(urlSite + (urlSite.endsWith('/') ? '' : '/') + 'feed');
  }

}
