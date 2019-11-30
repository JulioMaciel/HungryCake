import { User } from './user';

export interface Filter {
    id: number;
    userId: number;
    content: string;
    percentage: number;
    caseSensitive: boolean;
}
