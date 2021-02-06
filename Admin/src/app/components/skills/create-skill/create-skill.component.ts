import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { SkillType } from 'src/app/data/Skill';

@Component({
  selector: 'app-create-skill',
  templateUrl: './create-skill.component.html'
})
export class CreateSkillComponent implements OnInit {

  @Input() skillType: SkillType;

  constructor() { }

  ngOnInit(): void {
  }

}
