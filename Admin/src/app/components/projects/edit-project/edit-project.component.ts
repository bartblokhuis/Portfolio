import { Component, Input } from '@angular/core';
import { Project } from '../data/project';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-edit-project',
  templateUrl: './edit-project.component.html',
})
export class EditProjectComponent {

  @Input() project: Project;

  constructor() { }

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
