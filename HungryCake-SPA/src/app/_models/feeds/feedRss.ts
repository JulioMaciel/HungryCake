import { Feed } from './feed';

export interface FeedRss extends Feed {
    name: string;
    urlRss: string;
    urlSite: string;
    favIconURL: string;
    description: string;
    hasPayWall: boolean;
}
