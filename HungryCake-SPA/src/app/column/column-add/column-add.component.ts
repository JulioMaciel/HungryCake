import { Component, OnInit, Input } from '@angular/core';
import { Column } from 'src/app/_models/column';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-column-add',
  templateUrl: './column-add.component.html',
  styleUrls: ['./column-add.component.css']
})
export class ColumnAddComponent implements OnInit {
  // tslint:disable-next-line: no-use-before-declare
  showAddType = AddType.Initial;
  col: Column;
  @Input() rowPos: number;
  @Input() colPos: number;
  // @Input() colId

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  onAddRss() {
    // tslint:disable-next-line: no-use-before-declare
    this.showAddType = AddType.Rss;

    // this.authService.currentUserGrids.subscribe(userGrids => {
    //   this.col = userGrids.;
    // });
  }

}

export enum AddType {
  Initial,
  Rss,
  Reddit,
  Twitter,
  Regex
}
