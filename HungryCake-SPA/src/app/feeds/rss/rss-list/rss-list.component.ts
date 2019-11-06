import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FeedRss } from 'src/app/_models/feeds/feedRss';

@Component({
  selector: 'app-rss-list',
  templateUrl: './rss-list.component.html',
  styleUrls: ['./rss-list.component.css']
})
export class RssListComponent implements OnInit {
  rssList: FeedRss[];

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(async data => {
      this.rssList = data.rssList;
    });
  }

}
