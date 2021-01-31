export interface Project {
    id: number,
    title: string,
    description: string,
    image: string,
    displayOrder: number,
    published: boolean,
    githubUrl? :string,
    demoUrl?: string,
}
