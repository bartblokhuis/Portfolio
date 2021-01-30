import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  amountOfMessages: number = 7;
  constructor() { }

  ngOnInit(): void {
  }

}
