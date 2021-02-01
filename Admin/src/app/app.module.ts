import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AboutMeComponent } from './components/about-me/about-me.component';
import { SkillsComponent } from './components/skills/skills.component';
import { ProjectsComponent } from './components/projects/projects.component';
import { MessagesComponent } from './components/messages/messages.component';
import { RichTextEditorComponent } from './components/rich-text-editor/rich-text-editor.component';
import { QuillModule } from 'ngx-quill';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CreateProjectComponent } from './components/projects/create-project/create-project.component';
import { EditProjectComponent } from './components/projects/edit-project/edit-project.component';
import { FormsModule } from '@angular/forms';
import { DeleteProjectComponent } from './components/projects/delete-project/delete-project.component';


@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    SidebarComponent,
    DashboardComponent,
    AboutMeComponent,
    SkillsComponent,
    ProjectsComponent,
    MessagesComponent,
    RichTextEditorComponent,
    CreateProjectComponent,
    EditProjectComponent,
    DeleteProjectComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    QuillModule.forRoot(),
    NgbModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
