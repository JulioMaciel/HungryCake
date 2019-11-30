import { Grid } from './grid';

export interface User {
    id: number;
    email: string;
    level: number;
    grids: Grid[];
}
