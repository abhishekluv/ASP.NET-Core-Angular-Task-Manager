import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskListComponent } from './task-list/task-list.component';
import { TaskCreateComponent } from './task-create/task-create.component';
import { TaskDetailComponent } from './task-detail/task-detail.component';



@NgModule({
  declarations: [
    TaskListComponent,
    TaskCreateComponent,
    TaskDetailComponent
  ],
  imports: [
    CommonModule
  ]
})
export class TasksModule { }
