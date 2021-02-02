import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Message, MessageStatus } from '../../data/Message';
import { DeleteMessageComponent } from './delete-message/delete-message.component';
import { EditMessageComponent } from './edit-message/edit-message.component';


@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {

  messages: Message[] = [
    { firstName: "Bart", lastName: "Blokhuis", emailAddress: "info@bartblokhuis.com", message: "Hello world!", receivedDate: "31/0/2020", status: MessageStatus.Read, id: 0 }
  ]

  constructor(private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  editMessage(message: Message) {
    const modalRef = this.modalService.open(EditMessageComponent, { size: 'lg' })
    modalRef.componentInstance.message = message;
  }

  deleteMessage(message: Message){
    const modalRef = this.modalService.open(DeleteMessageComponent, { size: 'lg' })
    modalRef.componentInstance.message = message;
  }

}
