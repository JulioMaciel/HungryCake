import { Component, OnInit } from '@angular/core';
import { TreeviewItem, TreeItem, TreeviewConfig } from 'ngx-treeview';
import { Category } from 'src/app/_models/category';
import { ActivatedRoute, ChildrenOutletContexts } from '@angular/router';

@Component({
    selector: 'app-tree-categories',
    templateUrl: './tree-categories.component.html',
    styleUrls: ['./tree-categories.component.css']
})
export class TreeCategoriesComponent implements OnInit {
    items: TreeviewItem[] = [];
    categories: Category[];

    config = TreeviewConfig.create({
        hasAllCheckBox: true,
        hasFilter: true,
        hasCollapseExpand: true,
        decoupleChildFromParent: false,
        maxHeight: 400
    });

    constructor(private route: ActivatedRoute) { }

    ngOnInit() {
        this.route.data.subscribe(data => {
            this.categories = data.categories;
        });

        this.categories.forEach(cat => {
            cat.children = this.categories.filter(c => c.parent).filter(c => c.parent.id === cat.id);
        });

        const general = this.categories.find(c => c.english === 'General');
        this.insertCategoryOnTreeView(general);

        const uncat = this.categories.find(c => c.english === 'Uncategorized');
        this.insertCategoryOnTreeView(uncat);
    }

    insertCategoryOnTreeView(cat: Category) {
        const treeItem = this.categoryToTreeItem(cat);
        this.items.push(treeItem);

        if (cat.children) {
            this.categoryChildrenIntoTreeviewChildren(cat, treeItem);
        }

    }

    categoryChildrenIntoTreeviewChildren(catParent: Category, treeParent: TreeviewItem) {
        catParent.children.forEach(child => {

            const formatted = this.categoryToTreeItem(child);

            if (treeParent.children) {
                treeParent.children.push(formatted);
            } else {
                treeParent.children = [ new TreeviewItem(formatted) ];
            }

            if (child.children) {
                this.categoryChildrenIntoTreeviewChildren(child, formatted);
            }
        });
    }

    categoryToTreeItem(cat: Category): TreeviewItem {
        return new TreeviewItem({
            text: cat.english, value: cat.id
        });
    }

    //   export interface TreeItem {
    //     text: string;
    //     value: any;
    //     disabled?: boolean;
    //     checked?: boolean;
    //     collapsed?: boolean;
    //     children?: TreeItem[];
    // }


}
