import { Component, OnInit } from '@angular/core';
import { QuantityService } from '../../services/quantity.service';
import { ToastService } from '../../services/toast.service';
import { NgForOf, NgIf, DatePipe } from '@angular/common';

@Component({
  selector: 'app-history',
  standalone: true,
  imports: [NgForOf, NgIf, DatePipe],
  templateUrl: './history.component.html',
  styleUrl: './history.component.css'
})
export class HistoryComponent implements OnInit {
  historyRecords: any[] = [];
  loading: boolean = false;

  constructor(
    private quantityService: QuantityService,
    private toastService: ToastService
  ) {}

  ngOnInit(): void {
    this.fetchHistory();
  }

  fetchHistory() {
    this.loading = true;
    this.quantityService.hostory().subscribe({
      next: (res: any) => {
        this.historyRecords = res || [];
        this.loading = false;
      },
      error: (err: any) => {
        this.toastService.showError('Failed to load history');
        this.loading = false;
      }
    });
  }

  clearHistory() {
    if (!confirm('Are you sure you want to clear all history?')) return;

    this.quantityService.deleteHistory().subscribe({
      next: () => {
        this.toastService.showSuccess('History cleared successfully');
        this.historyRecords = [];
      },
      error: (err: any) => {
        this.toastService.showError('Failed to clear history');
      }
    });
  }
}
