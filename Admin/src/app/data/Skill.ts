export enum SkillType {
    FrontEnd,
    BackEnd,
    Other
}
   
export interface Skill {
    name: string,
    icon: string,
    type: SkillType,
    displayOrder: number
}
   