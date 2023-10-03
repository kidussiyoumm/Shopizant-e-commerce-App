import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';//import to use NgForm
import { UserService } from '../Shopizant-services/UserServices/user.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  current: string | any;//placeholder status
  error: string | any;
  messageDis: string | any;
  showDisplay: boolean = false;


  constructor(private _userServices: UserService) { }// Depedncy injection from the user services class




  submitLoginForm(form: NgForm) { // input from user coming in as a form

      //console.log(form.value.email);//passing the html email value
      //console.log(form.value.password);//passing the html password value}

      this._userServices.userCredentials(form.value.email , form.value.password).subscribe(//user passes crediantials 
        responseLoginCurrent => {
          this.current = responseLoginCurrent;
          this.showDisplay = true;
          if (this.current.toLoswercase() != "invalid credentials") {
            sessionStorage.setItem('userName', form.value.email);//User name is created
            sessionStorage.setItem('userRole', this.current)//user role is created 
            this.messageDis = "login Sucessful";
          } else { this.messageDis = "Invaild Entry" }; //if the users passes invalid credinatail response recieved from the userServices is also invalid
        },
        responseLoginErrorMessage => {
          this.error = responseLoginErrorMessage;
        },
        () => console.log("Submission succesfull") 
      );
    }
  
      ngOnInit(): void {
      }
}

