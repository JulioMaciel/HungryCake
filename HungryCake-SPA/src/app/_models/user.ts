export interface User {
    id: number;
    created: Date;
    lastActive: Date;
    interests?: string;
    roles?: string[];
}
