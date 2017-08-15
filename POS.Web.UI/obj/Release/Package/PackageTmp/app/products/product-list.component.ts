import { Component, OnInit } from 'angular2/core';
import { ROUTER_DIRECTIVES } from 'angular2/router';

import { IProduct } from './product';
import { ProductFilterPipe } from './product-filter.pipe';
import { StarComponent } from '../shared/star.component';
import { ProductService } from './product.service';

@Component({
    selector: 'pos-products',
    templateUrl: 'app/products/product-list.component.html',
    styleUrls: ['app/products/product-list.component.css'],
    pipes: [ProductFilterPipe],
    directives: [StarComponent, ROUTER_DIRECTIVES]
})
export class ProductListComponent implements OnInit {
    pageTitle: string = 'Product List';
    imageWidth: number = 50;
    imageMargin: number = 2;
    showImage: boolean = false;
    listFilter: string = '';
    errorMessage: string;
    products: IProduct[];
    
    constructor(private _productService: ProductService){

    }

    toggleImage(): void {
        this.showImage = !this.showImage;
    }

    ngOnInit(): void{

        //debugger;
        if(!localStorage.getItem("products")){
            this._productService.getProducts()
            .subscribe(
                products => 
                {
                    //debugger;
                    this.products = products;
                    localStorage["products"] = JSON.stringify(products);
                },
                error => this.errorMessage = <any>error);
        }else{
            let products = JSON.parse(localStorage["products"]);
            this.products = products;
        }
        
    }

    onRatingClicked(message: string): void{
       //this.pageTitle = "Product List: " + message; 
       console.log("Product List: " + message);
    }
}