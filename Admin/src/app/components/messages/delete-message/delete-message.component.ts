import { Component, OnInit, Input } from '@angular/core';
import { Message } from '../../../data/Message';

@Component({
  selector: 'app-delete-message',
  templateUrl: './delete-message.component.html'
})
export class DeleteMessageComponent implements OnInit {

  @Input() message: Message;

  constructor() { }

  ngOnInit(): void {
  }

}
