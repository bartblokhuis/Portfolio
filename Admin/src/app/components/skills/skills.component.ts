import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Skill, SkillType} from '../../data/Skill';
import { CreateSkillComponent } from './create-skill/create-skill.component';
import { DeleteSkillComponent } from './delete-skill/delete-skill.component';
import { EditSkillComponent } from './edit-skill/edit-skill.component';


@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.scss']
})
export class SkillsComponent implements OnInit {

  skills: Skill[] = [ 
    { name: "Angular", icon: "test", displayOrder: 1, type: SkillType.FrontEnd },
    { name: "CSS", icon: "test", displayOrder: 0, type: SkillType.FrontEnd },
    { name: "C#", icon: "test", displayOrder: 1, type: SkillType.BackEnd },
    { name: "Nopcommerce", icon: "test", displayOrder: 1, type: SkillType.BackEnd },
    { name: "Nopcommerce", icon: "test", displayOrder: 1, type: SkillType.Other },
    { name: "Nopcommerce", icon: "test", displayOrder: 1, type: SkillType.Other },
].sort((a,b) => a.displayOrder - b.displayOrder)

  frontEndSkills: Skill[] = this.skills.filter(skill => skill.type === SkillType.FrontEnd);
  backEndSkills: Skill[] = this.skills.filter(skill => skill.type === SkillType.BackEnd);
  otherSkills: Skill[] = this.skills.filter(skill => skill.type === SkillType.Other);
  
  constructor(private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  addFrontEndSkill(){
    this.addSkill(SkillType.FrontEnd)
  }

  addBackEndSkill(){
    this.addSkill(SkillType.BackEnd);
  }

  addOtherSkill(){
    this.addSkill(SkillType.Other);
  }

  addSkill(skillType: SkillType){
    const modalRef = this.modalService.open(CreateSkillComponent, { size: 'lg' })
    modalRef.componentInstance.skillType = skillType;
  }

  editSkill(skill: Skill){
    const modalRef = this.modalService.open(EditSkillComponent, { size: 'lg' })
    modalRef.componentInstance.skill = skill;
  }

  removeSkill(skill: Skill) {
    const modalRef = this.modalService.open(DeleteSkillComponent, { size: 'lg' })
    modalRef.componentInstance.skill = skill;
  }


  dropFrontEndSkills(event: CdkDragDrop<Skill[]>) {
    this.frontEndSkills = this.drop(event, this.frontEndSkills);
  }

  dropBackEndSkills(event: CdkDragDrop<Skill[]>) {
    this.backEndSkills = this.drop(event, this.backEndSkills);
  }

  dropOtherSkills(event: CdkDragDrop<Skill[]>) {
    this.otherSkills = this.drop(event, this.otherSkills);
  }

  drop(event: CdkDragDrop<Skill[]>, skills: Skill[]) {
    var startIndex = event.previousIndex;
    var endIndex = event.currentIndex;

    //Set the start and end index based on wether the project is moving up or down.
    if(event.previousIndex > event.currentIndex){
      startIndex = event.currentIndex;
      endIndex = event.previousIndex;
    }

    for (let i = startIndex; i <= endIndex; i++){
      var skill = skills[i];

      if(i === event.previousIndex){
        skill.displayOrder = event.currentIndex;
      }

      else if(event.previousIndex > event.currentIndex) {
        skill.displayOrder++;
      }

      else{
        skill.displayOrder--;
      }
    }
    
    skills.sort((a,b) => a.displayOrder - b.displayOrder);

    return skills;
  }

  
}
