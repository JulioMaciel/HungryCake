import { Component, OnInit, Input } from '@angular/core';
import { Grid } from 'src/app/_models/grid';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-grid-edit',
  templateUrl: './grid-edit.component.html',
  styleUrls: ['./grid-edit.component.css']
})
export class GridEditComponent implements OnInit {
  @Input() grid: Grid;
  gridForm: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.creategridForm();
  }

  creategridForm() {
    this.gridForm = this.fb.group({
      name: ['this.grid.name', [Validators.required, Validators.minLength(3), Validators.maxLength(13)]],
      // quantColumns: [this.grid.quantColumns, [Validators.required, Validators.minLength(2), Validators.maxLength(10)]],
      // quantRows: [this.grid.quantRows, [Validators.required, Validators.minLength(1), Validators.maxLength(6)]],
      // fontSize: [this.grid.fontSize, [Validators.required, Validators.minLength(10), Validators.maxLength(18)]],
      // template: [this.grid.template, [Validators.required, Validators.minLength(3), Validators.maxLength(13)]],
      // rowHeightLimit: [this.grid.rowHeightLimit, [Validators.required, Validators.minLength(10), Validators.maxLength(13)]],
    });
  }

  onSave() {

  }

  onClose() {

  }

  onReset() {

  }

  onRemove() {

  }

}
