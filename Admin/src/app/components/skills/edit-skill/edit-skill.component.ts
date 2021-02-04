import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Skill } from 'src/app/data/Skill';

@Component({
  selector: 'app-edit-skill',
  templateUrl: './edit-skill.component.html'
})
export class EditSkillComponent implements OnInit {

  @Input() skill: Skill;

  constructor() { }

  ngOnInit(): void {
  }

}
