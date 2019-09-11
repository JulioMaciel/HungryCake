import { Component, OnInit, Input, Output, EventEmitter, ViewChild, QueryList, ViewChildren } from '@angular/core';
import { Category } from 'src/app/_models/category';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-category-list-child',
  templateUrl: './category-list-child.component.html',
  styleUrls: ['./category-list-child.component.css']
})
export class CategoryListChildComponent implements OnInit {
  @ViewChildren(CategoryListChildComponent) childrenComp: QueryList<CategoryListChildComponent>;
  @Input() category: Category;
  @Input() editMode: boolean;
  @Input() catFormDirty: boolean;
  @Input() showSelectToFeed: boolean;
  @Output() selectedCat = new EventEmitter<Category>();
  @Output() selectedParent = new EventEmitter<Category>();
  @Output() catToFeed = new EventEmitter<Category>();
  showChildren = true;
  setAsFormParent = false;

  constructor() { }

  ngOnInit() {
  }

  onHideChildren() {
    this.showChildren = !this.showChildren;
  }

  onSelectedCat(cat: Category) {
    this.selectedCat.emit(cat);
  }

  onSelectedParent(cat: Category) {
    this.selectedParent.emit(cat);
  }

  onSelectedToFeed(cat: Category) {
    this.catToFeed.emit(cat);
  }

  showSelectAsParent(formParentId: number) {
    if (formParentId === this.category.id) {
      this.setAsFormParent = true;
    }
    if (this.childrenComp) {
      this.childrenComp.forEach(child => {
        child.showSelectAsParent(formParentId);
      });
    }
  }

}
