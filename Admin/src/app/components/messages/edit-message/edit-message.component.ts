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
    // console.log(this.mapping);
  }

  mapping = MessageStatusToLabelMapping;
  messageTypes = [MessageStatus.Closed, MessageStatus.Read, MessageStatus.Unread, MessageStatus.WaitingResponse];

}
