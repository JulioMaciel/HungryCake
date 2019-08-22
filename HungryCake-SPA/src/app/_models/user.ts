export interface User {
    id: number;
    userName: string;
    created: Date;
    lastActive: Date;
    interests?: string;
    roles?: string[];
}
