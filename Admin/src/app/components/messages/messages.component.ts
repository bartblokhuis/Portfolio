import { Component, OnInit } from '@angular/core';

enum MessageStatus {
  Unread,
  Read,
  WaitingResponse,
  Closed
}

interface Message{
  firstName: string,
  lastName: string,
  emailAddress: string,
  message: string,
  receivedDate: string,
  lastUpdatedDate?: string,
  status: MessageStatus
}

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {

  messages: Message[] = [
    { firstName: "Bart", lastName: "Blokhuis", emailAddress: "info@bartblokhuis.com", message: "Hello world!", receivedDate: "31/0/2020", status: MessageStatus.Unread }
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
