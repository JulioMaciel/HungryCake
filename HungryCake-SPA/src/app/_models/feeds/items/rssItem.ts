import { FeedItem } from './feedItem';

export interface RssItem extends FeedItem {
    posted: Date;
    content: string;
}
