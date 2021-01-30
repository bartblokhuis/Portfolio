import { Component, OnInit } from '@angular/core';

enum SkillType {
 FrontEnd,
 BackEnd,
 Other
}

interface skill {
  name: string,
  icon: string,
  type: SkillType,
  displayOrder: number
}

@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.scss']
})
export class SkillsComponent implements OnInit {

  skills: skill[] = [ 
    { name: "Angular", icon: "test", displayOrder: 1, type: SkillType.FrontEnd },
    { name: "CSS", icon: "test", displayOrder: 0, type: SkillType.FrontEnd },
    { name: "C#", icon: "test", displayOrder: 1, type: SkillType.BackEnd },
    { name: "Nopcommerce", icon: "test", displayOrder: 1, type: SkillType.Other },
].sort((a,b) => a.displayOrder - b.displayOrder)

  frontEndSkills: skill[] = this.skills.filter(skill => skill.type === SkillType.FrontEnd);
  backEndSkills: skill[] = this.skills.filter(skill => skill.type === SkillType.BackEnd);
  otherSkills: skill[] = this.skills.filter(skill => skill.type === SkillType.Other);
  constructor() { }

  ngOnInit(): void {
  }

}
