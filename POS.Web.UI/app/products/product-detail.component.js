System.register(['angular2/core', 'angular2/router', './product.service'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, router_1, product_service_1;
    var ProductDetailComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (product_service_1_1) {
                product_service_1 = product_service_1_1;
            }],
        execute: function() {
            ProductDetailComponent = (function () {
                function ProductDetailComponent(_routeParams, _router, _productService) {
                    this._routeParams = _routeParams;
                    this._router = _router;
                    this._productService = _productService;
                    this.pageTitle = 'Product Detail';
                    var id = +this._routeParams.get('id');
                    this.productId = id;
                    this.pageTitle += ": " + id;
                }
                ProductDetailComponent.prototype.onBack = function () {
                    this._router.navigate(['Products']);
                };
                ProductDetailComponent.prototype.ngOnInit = function () {
                    // this.sub = this._route.params.subscribe(
                    //     params => {
                    //         let id = +params['id'];
                    //         this.getProduct(id);
                    // });
                    var _this = this;
                    if (localStorage["products"]) {
                        //debugger;
                        var products = JSON.parse(localStorage.getItem('products'));
                        this.product = products.find(function (x) { return x.productId == _this.productId; });
                    }
                };
                ProductDetailComponent.prototype.ngOnDestroy = function () {
                    //this.sub.unsubscribe();
                };
                ProductDetailComponent.prototype.getProduct = function (id) {
                    // this._productService.getProduct(id).subscribe(
                    //     product => this.product = product,
                    //     error => this.errorMessage = <any>error);
                };
                ProductDetailComponent = __decorate([
                    core_1.Component({
                        templateUrl: 'app/products/product-detail.component.html'
                    }), 
                    __metadata('design:paramtypes', [router_1.RouteParams, router_1.Router, product_service_1.ProductService])
                ], ProductDetailComponent);
                return ProductDetailComponent;
            }());
            exports_1("ProductDetailComponent", ProductDetailComponent);
        }
    }
});
//# sourceMappingURL=product-detail.component.js.map