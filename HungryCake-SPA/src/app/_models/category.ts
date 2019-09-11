export interface Category {
    id: number;
    parent?: Category;
    english: string;
    portuguese?: string;
    spanish?: string;
    children?: Category[];
}
