import { Router } from "@angular/router";
import { Component, OnInit, ViewChild, NgZone } from "@angular/core";
import { COMMA, ENTER } from "@angular/cdk/keycodes";
import { UserService } from "../../shared/user.service";
import * as moment from "moment";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

@Component({
  selector: "app-create-user",
  templateUrl: "./create-user.component.html",
  styleUrls: ["./create-user.component.css"],
})
export class CreateUserComponent implements OnInit {
  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  @ViewChild("chipList", { static: true }) chipList;
  @ViewChild("resetUserForm", { static: true }) myNgForm;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  UserForm: FormGroup;
  selectedValue: number;
  educationLevels: any[] = [
    { name: "Infantil", value: 0 },
    { name: "Fundamental", value: 1 },
    { name: "Médio", value: 2 },
    { name: "Superior", value: 3 },
  ];

  ngOnInit() {
    this.UserForm = this.fb.group({
      firstName: ["", [Validators.required]],
      lastName: ["", [Validators.required]],
      educationLevel: ["", [Validators.required]],
      emailAddress: [
        "",
        [
          Validators.required,
          Validators.email,
          Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$"),
        ],
      ],
      birthDate: ["", [Validators.required]],
    });
  }

  constructor(
    public fb: FormBuilder,
    private router: Router,
    private ngZone: NgZone,
    private userService: UserService
  ) {}

  formatDate(e) {
    const convertDate = new Date(e.target.value).toISOString().substring(0, 10);

    const dateCompare = moment(new Date(e.target.value)).format("YYYY-MM-DD");
    const today = moment(Date.now()).format("YYYY-MM-DD");
    if (dateCompare >= today) {
      return this.UserForm.controls["birthDate"].setErrors({
        incorrect: true,
      });
    }

    this.UserForm.get("birthDate").setValue(convertDate, {
      onlyself: true,
    });
  }

  public handleError = (controlName: string, errorName: string) => {
    return this.UserForm.controls[controlName].hasError(errorName);
  };

  submitUserForm() {
    if (this.UserForm.valid) {
      this.userService.CreateUser(this.UserForm.value).subscribe((res) => {
        this.ngZone.run(() => this.router.navigateByUrl("/list-users"));
      });
    }
  }
}
