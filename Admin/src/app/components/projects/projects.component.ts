import { Component, OnInit } from '@angular/core';

interface Project {

  title: string,
  description: string,
  image: string,
  displayOrder: number,
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
    {  title: "Ultimate reddit bot", description: "<p>Ultimate Rmework.</p>", image: "",  displayOrder: 0 },
    {  title: "Ultimate localization", description: "", image: "", displayOrder: 1 },
    {  title: "Martian weather", description: "", image: "", displayOrder: 3 },
    {  title: "Clean download folder", description: "", image: "", displayOrder: 2 },
  ].sort((a,b) => a.displayOrder - b.displayOrder)

  constructor() { }

  ngOnInit(): void {
  }

  editProject(): void {
    
  }

  deleteProject(): void {
  }

}
