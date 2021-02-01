import { BaseEntity } from './BaseEntity';

export interface Project extends BaseEntity {
    title: string,
    description: string,
    image: string,
    displayOrder: number,
    published: boolean,
    githubUrl? :string,
    demoUrl?: string,
}