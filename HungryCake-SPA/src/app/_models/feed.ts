import { User } from './user';

export interface Feed {
    id: number;
    created: Date;
    creator: User;
    feedName: string;
    urlSite: string;
    urlFeed: string;
    topic: string;
    language: string;
    isActive: boolean;
}
