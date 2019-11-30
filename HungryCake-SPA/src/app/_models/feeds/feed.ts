import { User } from '../user';
import { Filter } from '../filter';

export interface Feed {
    id: number;
    created: Date;
    lastSuccess: Date;
    lastFail: Date;
    icon: Uint8Array;
    newIconPath: string;
    isActive: boolean;
    filter: Filter;
    adjustPostsTime: number;
}
