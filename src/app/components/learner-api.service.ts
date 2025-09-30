import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../enviroments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class LearnerApiService {

  private baseUrl = environment.apiUrl;

  //private baseUrl = 'https://backend20250929151252-euckazbch2hwcte9.southafricanorth-01.azurewebsites.net/api/Learner_Platform';

  constructor(private http: HttpClient) {}

  getLearner(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/get_learners`);
  }

  addLearner(learner: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/add_learner`, learner);
  }
}
