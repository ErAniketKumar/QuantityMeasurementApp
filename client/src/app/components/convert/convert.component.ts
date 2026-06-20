import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl } from '@angular/forms';
import { UnitMapService } from '../../services/unit-map.service';
import { QuantityService } from '../../services/quantity.service';
import { ToastService } from '../../services/toast.service';
import { NgForOf, NgIf } from '@angular/common';

@Component({
  selector: 'app-convert',
  standalone: true,
  imports: [ReactiveFormsModule, NgForOf, NgIf],
  templateUrl: './convert.component.html',
  styleUrl: './convert.component.css',
})
export class ConvertComponent {
  constructor(
    public unitMapService: UnitMapService,
    private quantityService: QuantityService,
    private toastService: ToastService
  ) {}

  availableUnits: string[] = [];
  resultText: string | null = null;

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
    if (this.convertForm.invalid) return;

    const payload = {
      quantity: {
        value: this.convertForm.value.value!,
        unit: this.convertForm.value.unit!,
        measurementType: this.convertForm.value.measurementType!
      },
      targetUnit: this.convertForm.value.targetUnit!
    };

    this.quantityService.convert(payload).subscribe({
      next: (res: any) => {
        const unitStr = typeof res.unit === 'string' && res.unit ? res.unit : this.convertForm.value.targetUnit;
        this.resultText = `Converted successfully: ${res.value} ${unitStr}`;
        // this.toastService.showSuccess(`Converted successfully: ${res.value} ${unitStr}`);
      },
      error: (err: any) => {
        this.resultText = null;
        this.toastService.showError(err.error?.message || 'Conversion failed');
      }
    });
  }
}
