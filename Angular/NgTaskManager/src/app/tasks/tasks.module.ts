import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskListComponent } from './task-list/task-list.component';
import { TaskCreateComponent } from './task-create/task-create.component';
import { TaskDetailComponent } from './task-detail/task-detail.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AuthGuard } from '../guards/auth.guard';
import { TaskService } from './task.service';



@NgModule({
  declarations: [
    TaskListComponent,
    TaskCreateComponent,
    TaskDetailComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule
  ],
  providers: [AuthGuard, TaskService],
  exports: [
    TaskListComponent,
    TaskCreateComponent,
    TaskDetailComponent
  ]
})
export class TasksModule { }
