import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { UserService } from '../services/user.service';
import { LoginDTO, RegisterDTO } from '../models/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  isCreated : boolean = false;
  userForm!: FormGroup;
  constructor(private router: Router,private userService: UserService){}

  ngOnInit() {
    const signUpButton = document.getElementById('signUp') as HTMLElement | any;
    const signInButton = document.getElementById('signIn') as HTMLElement | any;
    const container = document.getElementById('container') as HTMLElement | any;

    signUpButton.addEventListener('click', () => {
      container.classList.add("right-panel-active");
    });

    signInButton.addEventListener('click', () => {
      container.classList.remove("right-panel-active");
    });
    this.userForm = new FormGroup({
      username: new FormControl(''),
      password: new FormControl(''),
      confpassword : new FormControl(''),
    });
  }


  signIn(){
    const user: LoginDTO  = this.userForm.value;
 

    this.userService.signIn(user).subscribe({
      next: (result) => {
      
        console.log(result)
        this.router.navigate(['/home']);
      },
      error:(error) => {
        console.log(error)
      }
    })
  }

  signUp(){
    const user: RegisterDTO  = this.userForm.value;
    if (user.password != user.confpassword){
      console.log("Passwords do not mathc")

      return 
    }
    const newUser : LoginDTO = {
      username : user.username,
      password : user.password
    }

    this.userService.signUp(newUser).subscribe({
      next: (result) => {
    
        console.log(result)
        this.router.navigate(['/login']);

      },
      error:(error) => {
        console.log(error)
      }
    })
  }
}