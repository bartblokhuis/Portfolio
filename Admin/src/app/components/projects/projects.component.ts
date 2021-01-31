import { Component, OnInit } from '@angular/core';

interface Project {

  title: string,
  description: string,
  image: string,
  displayOrder: number,
  published: boolean,
  githubUrl? :string,
  demoUrl?: string,

}

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent implements OnInit {

  projects: Project[] = [
    {  title: "Ultimate reddit bot", description: "<p>Ultimate Rmework.</p>", image: "",  displayOrder: 0, published: true },
    {  title: "Ultimate localization", description: "", image: "", displayOrder: 1, published: false },
    {  title: "Martian weather", description: "", image: "", displayOrder: 3, published: true },
    {  title: "Clean download folder", description: "", image: "", displayOrder: 2, published: true },
  ].sort((a,b) => a.displayOrder - b.displayOrder)

  constructor() { }

  ngOnInit(): void {
  }

  editProject(): void {
    
  }

  deleteProject(): void {
  }

}
