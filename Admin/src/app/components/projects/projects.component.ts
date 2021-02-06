import { Component, OnInit } from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { CreateProjectComponent } from './create-project/create-project.component';
import { Project } from '../../data/project';
import { DeleteProjectComponent } from './delete-project/delete-project.component';
import { EditProjectComponent } from './edit-project/edit-project.component';
import { CdkDragDrop, DragDropModule, moveItemInArray } from '@angular/cdk/drag-drop';



@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent implements OnInit {

  projects: Project[] = [
    { id: 0, title: "Ultimate reddit bot", description: "<p>Ultimate Rmework.</p>", image: "",  displayOrder: 0, published: true },
    { id: 1, title: "Ultimate localization", description: "", image: "", displayOrder: 1, published: false },
    { id: 2, title: "Martian weather", description: "", image: "", displayOrder: 3, published: true },
    { id: 3, title: "Clean download folder", description: "", image: "", displayOrder: 2, published: true },
  ].sort((a,b) => a.displayOrder - b.displayOrder)

  closeResult = '';

  constructor(private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  addProject() {
    this.modalService.open(CreateProjectComponent, { size: 'lg' })
  }

  editProject(project: Project) {
    const modalRef = this.modalService.open(EditProjectComponent, { size: 'lg' })
    modalRef.componentInstance.project = project;
  }

  deleteProject(project: Project): void {
    const modalRef = this.modalService.open(DeleteProjectComponent, { size: 'lg' })
    modalRef.componentInstance.project = project;
  }

  drop(event: CdkDragDrop<Project[]>) {

    var startIndex = event.previousIndex;
    var endIndex = event.currentIndex;

    //Set the start and end index based on wether the project is moving up or down.
    if(event.previousIndex > event.currentIndex){
      startIndex = event.currentIndex;
      endIndex = event.previousIndex;
    }

    for (let i = startIndex; i <= endIndex; i++){
      var project = this.projects[i];

      if(i === event.previousIndex){
        project.displayOrder = event.currentIndex;
      }

      else if(event.previousIndex > event.currentIndex) {
        project.displayOrder++;
      }

      else{
        project.displayOrder--;
      }
    }
    
    this.projects.sort((a,b) => a.displayOrder - b.displayOrder);
  }
  

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

}
