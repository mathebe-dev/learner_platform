import { Component, Input } from '@angular/core';
import { LearnerApiService } from '../learner-api.service';
import { HttpClientModule } from '@angular/common/http';
import { tap } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [HttpClientModule, CommonModule, FormsModule],
  providers: [LearnerApiService],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  @Input() isOpen = false;

  // Model aligned with backend RegisteredLearner
  learner = {
    FirstName: '',
    MiddleName: '',
    LastName: '',
    DateOfBirth: '', // must match API field name
    Email: '',
    Cellphone: ''
  };

  registeredLearners: any[] = [];

  constructor(private learnerApiService: LearnerApiService) {}

  ngOnInit() {
    this.learnerApiService.getLearner()
      .pipe(
        tap(data => {
          console.log('Fetch Registered Learners', data);
          this.registeredLearners = data;
        })
      )
      .subscribe();
  }

  // reset form
  clearForm() {
    this.learner = {
      FirstName: '',
      MiddleName: '',
      LastName: '',
      DateOfBirth: '',
      Email: '',
      Cellphone: ''
    };
  }

  close() {
    this.isOpen = false;
  }

  // Submit form
registerLearner() {
  this.learnerApiService.addLearner(this.learner).subscribe({
    next: (res) => {
      alert(res.message); // works fine now
      this.clearForm();
    },
    error: (err) => {
      console.error(err);
      alert('Error saving learner.');
    }
  });
}

}
