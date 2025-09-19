import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LearnerApiService {

  private learnerApi = 'http://localhost:8000/get_learner';
  private addlearnerApi = 'http://localhost:8000/add_learner';

  constructor(private http: HttpClient) {}

  getLearner(): Observable<any>{
    return this.http.get<any>(this.learnerApi);
  }

  addLearner(learner: any): Observable<any> {
    return this.http.post<any>(this.addlearnerApi, learner);
  }

}
