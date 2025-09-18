import { Component } from '@angular/core';
import { LearnerApiService } from '../learner-api.service';
import { HttpClientModule } from '@angular/common/http';
import { tap } from 'rxjs';

import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [HttpClientModule, CommonModule],
  providers: [LearnerApiService],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})

export class RegisterComponent {

  registeredLearners: any = [];
  
  constructor(private LearnerApiService: LearnerApiService) { }

  ngOnInit() {
    this.LearnerApiService.getLearner().pipe(
      tap(data => {
        console.log('Fetch Registered Learners', data);
        this.registeredLearners = data;
      })
    ).subscribe();

  }
}
