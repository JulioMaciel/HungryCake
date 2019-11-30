import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Grid } from 'src/app/_models/grid';
import { Column } from 'src/app/_models/column';
import { GridService } from 'src/app/_services/grid.service';

@Component({
  selector: 'app-grid-view',
  templateUrl: './grid-view.component.html',
  styleUrls: ['./grid-view.component.css']
})
export class GridViewComponent implements OnInit {
  grid: Grid;
  showConfig: boolean;
  emptyColumns: number;

  constructor(private route: ActivatedRoute, private gridService: GridService) { }

  ngOnInit() {
    this.route.data.subscribe(async data => {
      // this.populateGridFakeColumns(data);
      this.grid = data.grid;
    });

    this.gridService.getGridConfigVisibility().subscribe(data => {
      this.showConfig = data as boolean;
    });

    this.emptyColumns = this.grid.quantColumns - this.grid.columns.length;
  }

  populateGridFakeColumns(data) {
    if (data.grid.columns.length === 0) {
      data.grid.columns.push({} as Column);
      data.grid.columns.push({} as Column);
      data.grid.columns.push({} as Column);
      data.grid.columns.push({} as Column);
    }
  }

  // changeGridConfigVisibility(val: boolean) {
  //   console.log('grid-view.component');
  //   console.log(val);
  //   this.showConfig = val;
  // }

}
