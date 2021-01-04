import { Router, ActivatedRoute } from "@angular/router";
import { Component, OnInit, ViewChild, NgZone } from "@angular/core";
import { COMMA, ENTER } from "@angular/cdk/keycodes";
import { UserService } from "../../shared/user.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import * as moment from "moment";

@Component({
  selector: "app-edit-user",
  templateUrl: "./edit-user.component.html",
  styleUrls: ["./edit-user.component.css"],
})
export class EditUserComponent implements OnInit {
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
    private actRoute: ActivatedRoute,
    private userService: UserService
  ) {
    var id = this.actRoute.snapshot.paramMap.get("id");
    this.userService.GetUserById(id).subscribe((data) => {
      console.log(`data: ${JSON.stringify(data)}`);
      this.selectedValue = data.educationLevel;
      this.UserForm = this.fb.group({
        firstName: [data.firstName, [Validators.required]],
        lastName: [data.lastName, [Validators.required]],
        educationLevel: [data.educationLevel],
        emailAddress: [
          data.emailAddress,
          [
            Validators.required,
            Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$"),
          ],
        ],
        birthDate: [data.birthDate, [Validators.required]],
      });
    });
  }

  formatDate(e) {
    var convertDate = new Date(e.target.value).toISOString().substring(0, 10);

    var dateCompare = moment(new Date(e.target.value)).format("YYYY-MM-DD");
    var today = moment(Date.now()).format("YYYY-MM-DD");
    if (dateCompare >= today)
      return this.UserForm.controls["birthDate"].setErrors({
        incorrect: true,
      });

    this.UserForm.get("birthDate").setValue(convertDate, {
      onlyself: true,
    });
  }

  public handleError = (controlName: string, errorName: string) => {
    return this.UserForm.controls[controlName].hasError(errorName);
  };
  
  updateUserForm() {
    console.log(this.UserForm.value);
    var id = this.actRoute.snapshot.paramMap.get("id");
    if (window.confirm("Tem certeza que deseja atualizar?")) {
      this.userService.UpdateUser(id, this.UserForm.value).subscribe((res) => {
        this.ngZone.run(() => this.router.navigateByUrl("/list-users"));
      });
    }
  }
}
