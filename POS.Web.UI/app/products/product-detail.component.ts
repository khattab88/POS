import { Component } from 'angular2/core';
import { OnInit, OnDestroy } from 'angular2/core';
import { RouteParams, Router } from 'angular2/router';
//import { ActivatedRoute } from '@angular/router';

import { Subscription } from 'rxjs/Subscription';

import { IProduct } from './product';
import { ProductService } from './product.service';

@Component({
    templateUrl: 'app/products/product-detail.component.html'
})
export class ProductDetailComponent implements OnInit, OnDestroy  {
    productId: number;
    pageTitle: string = 'Product Detail';
    product: IProduct;
    errorMessage: string;
    private sub: Subscription;
    
    constructor(private _routeParams: RouteParams,
                private _router: Router,
                private _productService: ProductService) {
          let id = +this._routeParams.get('id');
          this.productId = id;
          this.pageTitle += `: ${id}`;
    }

    onBack(): void {
        this._router.navigate(['Products']);
    }

    ngOnInit(): void {
        // this.sub = this._route.params.subscribe(
        //     params => {
        //         let id = +params['id'];
        //         this.getProduct(id);
        // });

        if(localStorage["products"]){
            //debugger;
            let products = JSON.parse(localStorage.getItem('products'));
            this.product = products.find(x => x.productId == this.productId);
        }
    }

    ngOnDestroy() {
        //this.sub.unsubscribe();
    }

    getProduct(id: number) {
        // this._productService.getProduct(id).subscribe(
        //     product => this.product = product,
        //     error => this.errorMessage = <any>error);
    }

}
