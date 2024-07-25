// src/app/app.component.ts
import { Component } from '@angular/core';
import { TodoListComponent } from './todo-list/todo-list.component';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    imports: [TodoListComponent] // Import TodoListComponent here
})
export class AppComponent {
    title = 'My Angular App';
}
