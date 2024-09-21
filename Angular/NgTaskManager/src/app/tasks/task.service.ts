import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn:'root'
})
export class TaskService {
    private apiUrl: string = "https://localhost:7060/api/taskitems";

    constructor(private http: HttpClient){

    }

    getTasks(): Observable<any>{
        return this.http.get<any[]>(this.apiUrl);
    }
}