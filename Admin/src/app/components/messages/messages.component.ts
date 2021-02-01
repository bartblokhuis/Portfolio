import { Component, OnInit } from '@angular/core';
import { Message, MessageStatus } from '../../data/Message';


@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {

  messages: Message[] = [
    { firstName: "Bart", lastName: "Blokhuis", emailAddress: "info@bartblokhuis.com", message: "Hello world!", receivedDate: "31/0/2020", status: MessageStatus.Unread, id: 0 }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
