import { Component, Input } from '@angular/core';
import { Skill } from '../../../data/Skill';

@Component({
  selector: 'app-delete-skill',
  templateUrl: './delete-skill.component.html'
})
export class DeleteSkillComponent {

  @Input() skill: Skill;

  constructor() { }

}
