import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { UnitMapService } from '../../services/unit-map.service';
import { QuantityService } from '../../services/quantity.service';
import { ToastService } from '../../services/toast.service';
import { NgForOf, NgIf } from '@angular/common';

@Component({
  selector: 'app-compare',
  standalone: true,
  imports: [ReactiveFormsModule, NgForOf, NgIf],
  templateUrl: './compare.component.html',
  styleUrl: './compare.component.css'
})
export class CompareComponent {
  constructor(
    public unitMapService: UnitMapService,
    private quantityService: QuantityService,
    private toastService: ToastService
  ) {}

  availableUnits: string[] = [];
  resultText: string | null = null;

  compareForm = new FormGroup({
    measurementType: new FormControl(''),
    value1: new FormControl(0, Validators.required),
    unit1: new FormControl('', Validators.required),
    value2: new FormControl(0, Validators.required),
    unit2: new FormControl('', Validators.required),
  });

  onMeasurementTypeChange() {
    const type = this.compareForm.value.measurementType as keyof typeof this.unitMapService.UNITS;
    this.availableUnits = this.unitMapService.UNITS[type] || [];
    this.compareForm.patchValue({ unit1: '', unit2: '' });
  }

  handleCompare() {
    if (this.compareForm.invalid) return;

    const payload = {
      value1: this.compareForm.value.value1!,
      unit1: this.compareForm.value.unit1!,
      value2: this.compareForm.value.value2!,
      unit2: this.compareForm.value.unit2!,
      measurementType: this.compareForm.value.measurementType!
    };

    this.quantityService.compare(payload).subscribe({
      next: (res: any) => {
        this.resultText = `Comparison Result: ${res.result}`;
        // this.toastService.showSuccess(`Comparison Result: ${res.result}`);
      },
      error: (err: any) => {
        this.resultText = null;
        this.toastService.showError(err.error?.message || 'Comparison failed');
      }
    });
  }
}
