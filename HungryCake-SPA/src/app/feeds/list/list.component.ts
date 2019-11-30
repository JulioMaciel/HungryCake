import { Component, OnInit } from '@angular/core';
import { FeedRss } from 'src/app/_models/feeds/feedRss';
import { ActivatedRoute } from '@angular/router';
import { Grid } from 'src/app/_models/grid';
import { Column } from 'src/app/_models/column';
import { FormGroup } from '@angular/forms';
import { AuthService } from 'src/app/_services/auth.service';
import { GridService } from 'src/app/_services/grid.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  userGrids: Grid[] = [];
  selectedGrid: Grid;
  rssList: FeedRss[] = [];
  // redditList: RedditRss[];

  constructor(private route: ActivatedRoute, public authService: AuthService,
              private gridService: GridService) { }

  ngOnInit() {
    this.loadRssList();
    this.loadUserGrids();

    // this.selectedGrid = { id: 0, name: 'teste'};
    // this.selectedGrid.columns = [ {} as Column, {} as Column, {} as Column, {} as Column];
  }


  loadUserGrids() {
    this.authService.currentUserGrids.subscribe(userGrids => {
      this.userGrids = userGrids;
      this.loadGrid(userGrids[1].id);
    });
  }

  loadGrid(gridId: number) {
    this.gridService.loadGrid(gridId).subscribe(gridInfo => {
      this.selectedGrid = gridInfo;
    });
  }

  loadRssList() {
    this.route.data.subscribe(async (data) => {
      this.rssList = data.rssList;
    });
  }

  onCreateColumn(columnNumber: number) {
  }
}
