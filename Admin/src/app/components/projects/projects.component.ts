import { Component, OnInit } from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { CreateProjectComponent } from './create-project/create-project.component';
import { Project } from './data/project';
import { EditProjectComponent } from './edit-project/edit-project.component';



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

    // this.modalService.open(content, {size: 'lg'}).result.then((result) => {
    //   this.closeResult = `Closed with: ${result}`;
    // }, (reason) => {
    //   this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    // });
  }

  deleteProject(): void {
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
