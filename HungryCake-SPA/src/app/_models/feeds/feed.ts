import { User } from '../user';

export interface Feed {
    id: number;
    created: Date;
    lastSuccess: Date;
    lastFail: Date;
    icon: Uint8Array;
    newIconPath: string;
    isActive: boolean;
}
