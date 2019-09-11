import { Category } from './category';
import { User } from './user';

export interface Rss {
    id: number;
    name: string;
    url: string;
    urlSite: string;
    category: Category;
    categoryId: number;
    language: Language;
    created: Date;
    creator: User;
    creatorId: number;
    isActive: boolean;
    loadedLastTime: boolean;
    hasPayWall: boolean;
}

export enum Language {
    English,
    Portuguese,
    Spanish
}
