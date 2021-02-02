import { Component, OnInit, Input } from '@angular/core';
import { Message, MessageStatusToLabelMapping, MessageStatus } from '../../../data/Message';


@Component({
  selector: 'app-edit-message',
  templateUrl: './edit-message.component.html',
})

export class EditMessageComponent implements OnInit {

  @Input() message: Message;

  constructor() { }

  ngOnInit(): void {
  }

  messageTypes = [MessageStatus.Closed, MessageStatus.Read, MessageStatus.Unread, MessageStatus.WaitingResponse];

}
