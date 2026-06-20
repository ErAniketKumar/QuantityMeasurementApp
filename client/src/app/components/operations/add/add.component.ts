import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { UnitMapService } from '../../../services/unit-map.service';
import { QuantityService } from '../../../services/quantity.service';
import { ToastService } from '../../../services/toast.service';
import { NgForOf, NgIf } from '@angular/common';

@Component({
  selector: 'app-add',
  standalone: true,
  imports: [ReactiveFormsModule, NgForOf, NgIf],
  templateUrl: './add.component.html',
  styleUrl: './add.component.css'
})
export class AddComponent {
  constructor(
    public unitMapService: UnitMapService,
    private quantityService: QuantityService,
    private toastService: ToastService
  ) {}

  availableUnits: string[] = [];
  resultText: string | null = null;

  operationForm = new FormGroup({
    measurementType: new FormControl(''),
    val1: new FormControl(0, Validators.required),
    unit1: new FormControl('', Validators.required),
    val2: new FormControl(0, Validators.required),
    unit2: new FormControl('', Validators.required)
  });

  onMeasurementTypeChange() {
    const type = this.operationForm.value.measurementType as keyof typeof this.unitMapService.UNITS;
    this.availableUnits = this.unitMapService.UNITS[type] || [];
    this.operationForm.patchValue({ unit1: '', unit2: '' });
  }

  handleAdd() {
    if (this.operationForm.invalid) return;

    const payload = {
      quantity1: {
        value: this.operationForm.value.val1!,
        unit: this.operationForm.value.unit1!,
        measurementType: this.operationForm.value.measurementType!
      },
      quantity2: {
        value: this.operationForm.value.val2!,
        unit: this.operationForm.value.unit2!,
        measurementType: this.operationForm.value.measurementType!
      }
    };

    this.quantityService.add(payload).subscribe({
      next: (res: any) => {
        const unitStr = typeof res.unit === 'string' && res.unit ? res.unit : this.operationForm.value.unit1;
        this.resultText = `Addition Result: ${res.value} ${unitStr}`;
      },
      error: (err: any) => {
        this.resultText = null;
        this.toastService.showError(err.error?.message || 'Operation failed');
      }
    });
  }
}
