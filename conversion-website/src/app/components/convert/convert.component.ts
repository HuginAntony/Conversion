import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConversionService } from 'src/app/shared/services/conversion.service';
import Swal from 'sweetalert2';
import { AuthService } from 'src/app/shared/services/auth.service';
import { User } from 'src/app/shared/models/user.model';
import { ConversionType } from 'src/app/shared/enums/conversionType.enum';
import { MassUnit } from 'src/app/shared/enums/massUnit.enum';
import { HistoryRequest } from 'src/app/shared/models/history-request.model';
import { LengthUnit } from 'src/app/shared/enums/lengthUnit.enum';
import { TempUnit } from 'src/app/shared/enums/tempUnit.enum';

@Component({
  selector: 'app-convert',
  templateUrl: './convert.component.html',
  styleUrls: ['./convert.component.scss'],
})
export class ConvertComponent implements OnInit {
  conversionTypes = ConversionType;
  massUnits = MassUnit;
  tempUnits = TempUnit;
  lenghtUnits = LengthUnit;
  statusKeys: string[];
  lengthKeys: string[];
  massKeys: string[];
  tempKeys: string[];
  user: User = {};

  constructor(
    private conversionService: ConversionService,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.statusKeys = Object.keys(this.conversionTypes).map(String);
    this.lengthKeys = Object.keys(this.lenghtUnits).map(String);
    this.massKeys = Object.keys(this.massUnits).map(String);
    this.tempKeys = Object.keys(this.tempUnits).map(String);

    this.authService.user$.subscribe((user) => (this.user = user)); // Get the current user
  }

  onChange(c, form: NgForm): void{
    if (form.controls.toUnit.value === form.controls.fromUnit.value){
      form.controls.fromUnit.setErrors({sameUnit: true });
      form.controls.toUnit.setErrors({sameUnit: true });
    }
    else{
      form.controls.fromUnit.setErrors({sameUnit: false });
      form.controls.toUnit.setErrors({sameUnit: false });
    }
  }
  saveChanges(form: NgForm): void {
    const conType = form.controls.conversionType.value;
    switch (conType) {
      case ConversionType.Temperature:
        this.conversionService.getCelsius(form.controls.valueToConvert.value).subscribe(r => {
          this.handleSuccess(`${form.controls.valueToConvert.value} degrees Fahrenheit is ${r} degrees celsius`);
        });
        break;
      case ConversionType.Length:
        this.conversionService.getMiles(form.controls.valueToConvert.value).subscribe(r => {
          this.handleSuccess(`${form.controls.valueToConvert.value} kilometers is ${r} miles`);
        });
        break;
      case ConversionType.Mass:
        this.conversionService.getKilograms(form.controls.valueToConvert.value).subscribe(r => {
          this.handleSuccess(`${form.controls.valueToConvert.value} pounds is ${r} kilograms`);
        });
        break;
    }
  }

  saveUserHistory(form: NgForm, result: number): void{
    let h: HistoryRequest;
    h.conversionFrom = form.controls.fromUnit.value;
    h.conversionTo = form.controls.toUnit.value;
    h.userId = this.user.id;
    h.valueToConvert = form.controls.valueToConvert.value;
    h.coversionType = form.controls.conversionType.value;
    h.convertedResult = result;

    this.conversionService.create(h).subscribe(r => {
      //this.handleSuccess(`${form.controls.valueToConvert.value} degrees Fahrenheit is ${r} degrees celsius`);
    });
  }

  handleSuccess(message: string): void {
    Swal.fire({
      icon: 'success',
      title: message,
      showConfirmButton: false,
      timer: 3000,
    });
  }
}
