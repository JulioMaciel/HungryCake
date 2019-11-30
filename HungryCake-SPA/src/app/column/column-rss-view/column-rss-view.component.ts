import { Component, OnInit, Input } from '@angular/core';
import { RssItem } from 'src/app/_models/feeds/items/rssItem';
import { Column } from 'src/app/_models/column';
import { Logs } from 'selenium-webdriver';

@Component({
  selector: 'app-column-rss-view',
  templateUrl: './column-rss-view.component.html',
  styleUrls: ['./column-rss-view.component.css']
})
export class ColumnRssViewComponent implements OnInit {
  @Input() column: Column;
  // @Input() rssItems: RssItem[] = [];

  constructor() { }

  ngOnInit() {
    this.populateColumnFakeItems();
  }

  populateColumnFakeItems() {
    if (typeof this.column.items === 'undefined') {
      this.column.items = [
        { title: 'one', posted: new Date(), content: 'lalalala', link: 'http://globo.com'  },
        { title: 'two', posted: new Date(), content: 's2s2s2s2', link: 'http://globo.com'  },
        { title: 'tre', posted: new Date(), content: 'g3g3g3g3', link: 'http://globo.com'  },
        { title: 'fou', posted: new Date(), content: 'd4d44d4d', link: 'http://globo.com'  },
        { title: 'fiv', posted: new Date(), content: 'x5x5x555', link: 'http://globo.com'  },
        { title: 'six', posted: new Date(), content: 'b6b6b66b', link: 'http://globo.com'  },
        { title: 'sev', posted: new Date(), content: 'n7n77n7n', link: 'http://globo.com'  },
        { title: 'eig', posted: new Date(), content: 'm8m8m8m8', link: 'http://globo.com'  },
        { title: 'nin', posted: new Date(), content: 'p9p9p9p9', link: 'http://globo.com'  },
        { title: 'ten', posted: new Date(), content: 'o0o0o0o0', link: 'http://globo.com'  },
        { title: 'ele', posted: new Date(), content: 'onze1111', link: 'http://globo.com'  },
      ];
    }
  }

}
