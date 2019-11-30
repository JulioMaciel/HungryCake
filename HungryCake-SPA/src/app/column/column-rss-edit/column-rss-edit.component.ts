import { Component, OnInit, Input } from '@angular/core';
import { Grid } from 'src/app/_models/grid';
import { Column } from 'src/app/_models/column';

@Component({
  selector: 'app-column-rss-edit',
  templateUrl: './column-rss-edit.component.html',
  styleUrls: ['./column-rss-edit.component.css']
})
export class ColumnRssEditComponent implements OnInit {
  @Input() column: Column;

  constructor() { }

  ngOnInit() {
  }

}
