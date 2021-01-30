import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RichTextEditorComponent } from './rich-text-editor.component';
import { QuillModule } from 'ngx-quill';


@NgModule({
  imports: [CommonModule, QuillModule ],
  declarations: [RichTextEditorComponent],
  exports: [RichTextEditorComponent]
})

export class RichTextEditorModule { }
