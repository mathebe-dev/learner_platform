import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LearnerApiService {

  private learnerApi = 'http://localhost:8000/get_learner';

  constructor(private http: HttpClient) {}

  getLearner(): Observable<any>{
    return this.http.get<any>(this.learnerApi);
  }

}
