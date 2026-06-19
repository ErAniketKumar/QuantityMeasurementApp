import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl } from '@angular/forms';
import { UnitMapService } from '../../services/unit-map.service';
import { NgForOf, NgIf } from '@angular/common';

@Component({
  selector: 'app-convert',
  imports: [ReactiveFormsModule, NgForOf],
  templateUrl: './convert.component.html',
  styleUrl: './convert.component.css',
})
export class ConvertComponent {
  constructor(public unitMapService: UnitMapService) {}

  availableUnits: string[] = [];

  convertForm = new FormGroup({
    measurementType: new FormControl(''),
    value: new FormControl(0),
    unit: new FormControl(''),
    targetUnit: new FormControl(''),
  });

  onMeasurementTypeChange() {
    const type = this.convertForm.value
      .measurementType as keyof typeof this.unitMapService.UNITS;

    this.availableUnits = this.unitMapService.UNITS[type] || [];

    this.convertForm.patchValue({
      unit: '',
      targetUnit: '',
    });
  }

  handleConvert() {
    console.log(this.convertForm.value);
  }
}
