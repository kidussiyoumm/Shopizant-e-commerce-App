import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';//creating methods for generating controls
import { FormControl } from '@angular/forms';//Tracks the value and validation status of an indivual from control like email and password
import { FormGroup } from '@angular/forms';//tracks value of a group of FormControl instances
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {


  signupForm!: FormGroup; 

  constructor(private formBuilder: FormBuilder) { }//inject formbuilder in the constructor 


  ngOnInit(): void {
    this.signupForm = this.formBuilder.group({
      emailId: [''],//declares emailId as form control
      password: [''],
      gender: [''],
      dateOfBirth: [''],
      address: ['']
    });




  }

  SubmitForm(form: FormGroup) { //SubmitForm method read the value entered in the emailId Text box
    console.log(form.value.emailId , form.value.password , form.value.gender, form.value.dateOfBirth , form.value.address );
  }

}
