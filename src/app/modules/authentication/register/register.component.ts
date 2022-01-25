import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { EmployeesComponent } from '../../employees/employees/employees.component';
import { Register } from 'src/app/interfaces/register';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registrationForm = this.fb.group({
    email: ['', Validators.required],
    password: ['', Validators.required],
  })
  constructor(private fb: FormBuilder, private authService: AuthService) { }

  ngOnInit(): void {
  }

  onRegister() {
    var newUser: Register = this.registrationForm.value;
    newUser.Role = "BasicUser";

    this.authService.register(newUser).subscribe();
  }

}
