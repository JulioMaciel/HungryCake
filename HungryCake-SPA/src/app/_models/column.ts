import { Grid } from './grid';
import { FeedRss } from './feeds/feedRss';
import { RssItem } from './feeds/items/rssItem';

export interface Column {
    id: number;
    grid: Grid;
    name: string;
    type: FeedType;
    rowPos: number;
    columnPos: number;
    maxItems: number;
    showRollBar: boolean;
    showImage: boolean;
    showSummary: boolean;
    showDateTime: boolean;
    feedsRss: FeedRss[];
    items: RssItem[];
}

export enum FeedType {
    Rss,
    Reddit,
    Twitter,
    Regex,
}
