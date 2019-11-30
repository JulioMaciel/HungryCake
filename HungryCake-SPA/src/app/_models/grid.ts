import { User } from './user';
import { Column } from './column';

export interface Grid {
    id: number;
    name: string;
    user?: User;
    quantColumns?: number;
    quantRows?: number;
    fontSize?: number;
    template?: GridTemplate;
    rowHeightLimit?: number;
    columns?: Column[];
}

export enum GridTemplate {
    White = 0,
    Dark,
    LightGray
}
