import { Component, OnInit } from '@angular/core';

interface MenuItems {
  name: string
  path?: string
  icon: string
  menuItems?: MenuItems[]
  badge?: Badge
}

interface Badge {
  value: any
  style: string
}


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  menuItems : MenuItems[] = [ 
    { name: "Dashboard", path: "/dashboard", icon: "nav-icon fas fa-home" }, 
    { name: "About me", path: "/about-me", icon: "nav-icon fas fa-male" }, 
    { name: "Sklls", path: "/skills", icon: "nav-icon fas fa-trophy" }, 
    { name: "Projects", path: "/projects", icon: "nav-icon fas fa-trophy" },
    { name: "Messages", path: "/messages", icon: "nav-icon fas fa-inbox", badge: { value: "New", style: "right badge badge-danger" } },
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
