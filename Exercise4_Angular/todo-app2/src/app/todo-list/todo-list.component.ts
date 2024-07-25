import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms'; // Import necessary modules
import { CommonModule } from '@angular/common';
import { Task } from '../models/task.model';
import { TaskService } from '../services/task.service';

@Component({
    selector: 'app-todo-list',
    templateUrl: './todo-list.component.html',
    styleUrls: ['./todo-list.component.css'],
    standalone: true,
    imports: [FormsModule, CommonModule] // Import FormsModule and CommonModule
})
export class TodoListComponent implements OnInit {
    tasks: Task[] = [];
    newTaskDescription: string = '';
    isEditing: boolean = false;
    editingTaskId: number | null = null;
    editedTaskDescription: string = '';

    constructor(private taskService: TaskService) { }

    ngOnInit(): void {
        this.tasks = this.taskService.getTasks();
    }

    get notCompletedTasks(): Task[] {
        return this.tasks.filter(task => !task.completed);
    }

    get completedTasks(): Task[] {
        return this.tasks.filter(task => task.completed);
    }

    addTask(): void {
        if (this.newTaskDescription.trim()) {
            const newTask: Task = {
                id: Date.now(), // generate a simple unique id based on timestamp
                description: this.newTaskDescription,
                completed: false,
            };
            this.taskService.addTask(newTask);
            this.tasks = this.taskService.getTasks();
            this.newTaskDescription = '';
        }
    }

    startEditing(taskId: number): void {
        const task = this.tasks.find(t => t.id === taskId);
        if (task) {
            this.isEditing = true;
            this.editingTaskId = taskId;
            this.editedTaskDescription = task.description;
        }
    }

    updateTask(): void {
        if (this.editingTaskId !== null && this.editedTaskDescription.trim()) {
            const updatedTask: Task = {
                id: this.editingTaskId,
                description: this.editedTaskDescription,
                completed: this.tasks.find(t => t.id === this.editingTaskId)!.completed,
            };
            this.taskService.updateTask(updatedTask);
            this.tasks = this.taskService.getTasks();
            this.cancelEdit();
        }
    }

    cancelEdit(): void {
        this.isEditing = false;
        this.editingTaskId = null;
        this.editedTaskDescription = '';
    }

    deleteTask(taskId: number): void {
        this.taskService.deleteTask(taskId);
        this.tasks = this.taskService.getTasks();
    }

    toggleTaskCompletion(taskId: number, event: any): void {
        const task = this.tasks.find(t => t.id === taskId);
        if (task) {
            task.completed = event.target.checked;
            this.taskService.updateTask(task);
            this.tasks = this.taskService.getTasks();
        }
    }
}
