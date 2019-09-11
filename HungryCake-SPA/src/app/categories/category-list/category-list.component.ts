import { Component, OnInit, ViewChild, ViewChildren, QueryList, Input, Output, EventEmitter } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/_models/category';
import { CategoryService } from 'src/app/_services/category.service';
import { Observable } from 'rxjs/internal/Observable';
import { BehaviorSubject } from 'rxjs';
import { CategoryListChildComponent } from '../category-list-child/category-list-child.component';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  @Input() showSelectToFeed: boolean;
  @Output() catToFeed = new EventEmitter<Category>();
  @ViewChildren(CategoryListChildComponent) childrenComp: QueryList<CategoryListChildComponent>;
  categories: Category[];
  hierarchicalCategories: Category[] = [];
  category: Category = Object.assign({});
  selectedParent: Category;
  catFormDirty: boolean;
  editMode: boolean;

  constructor(private route: ActivatedRoute, private categoryService: CategoryService,
              private alertify: AlertifyService) { }

  ngOnInit() {
    this.updateCategories();
  }

  hierarchizeCategories() {
    this.hierarchicalCategories.push(this.categories.find(c => c.english === 'General'));
    this.hierarchicalCategories.push(this.categories.find(c => c.english === 'Uncategorized'));

    this.categories.forEach(cat => {
      cat.children = this.categories.filter(c => c.parent).filter(c => c.parent.id === cat.id);
    });
  }

  updateCategories() {
    this.categoryService.getCategories().subscribe(data => {
      this.hierarchicalCategories = [];
      this.categories = data;
      this.hierarchizeCategories();
    });
  }

  addCategory() {
    this.categoryService.add(this.category).subscribe(() => {
      this.updateCategories();
      this.alertify.success('Category ' + this.category.english + ' was added');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.category = Object.assign({});
    });
  }

  removeCategory() {
    this.categoryService.delete(this.category.id).subscribe(() => {
      this.updateCategories();
      this.alertify.success('Category ' + this.category.english + ' was removed');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.category = Object.assign({});
    });
  }

  onSelectedCat(cat: Category) {
    this.category = cat;
    this.childrenComp.forEach(child => {
      child.showSelectAsParent(cat.id);
    });
  }

  onSelectedParent(cat: Category) {
    this.category.parent = cat;
  }

  changeEditMode() {
    this.editMode = !this.editMode;
    this.category = Object.assign({});
  }

  editCategory() {
    this.categoryService.update(this.category).subscribe(() => {
      this.updateCategories();
      this.alertify.success('Category ' + this.category.english + ' was updated');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.category = Object.assign({});
    });
  }

  onSelectedToFeed(cat: Category) {
    this.catToFeed.emit(cat);
    // console.log('category ' + cat.english + ' was selected to feed');
  }

}
