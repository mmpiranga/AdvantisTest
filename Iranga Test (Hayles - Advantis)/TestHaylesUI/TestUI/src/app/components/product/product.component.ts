import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  product: Product = new Product();
  products: Product[] = [];
  isEditMode: boolean = false;

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.getProductDetails();
  }

  public getProductDetails() {
    debugger;
    this.productService.getProducts()
      .subscribe(data => {
        this.products = data.body.data;
      },
        err => {

        }

      )
  };

  public saveProduct(prod: Product) {
    this.productService.addProduct(prod)
      .subscribe(data => {
        if (data.status == 200) {
          alert("Successfully Saved!");
          this.getProductDetails();
        }
        else {
          alert("Save Failed!");
        }
      },
        err => {
          alert("Save Failed!");
        }
      )
  };

  public editProduct(prod: Product) {
    this.isEditMode = true;
    this.product = prod;
  };

  public updateProduct(prod: Product) {
    this.productService.editProduct(prod)
      .subscribe(data => {
        if (data.status == 200) {
          alert("Successfully Updated!");
          this.isEditMode = false;
          this.product = new Product();
          this.getProductDetails();
        }
        else {
          alert("Update Failed!");
        }
      }, err => {
        alert("Update Failed!");
      })
  };

  public deleteProduct(id: number) {
    var result = confirm("Are you sure, you want to delete?");
    if (result) {
      this.productService.deleteProduct(id)
        .subscribe(data => {
          if (data.status == 200) {
            alert("Successfully Deleted!");
            this.getProductDetails();
          }
          else {
            alert("Delete Failed!");
          }
        },
          err => {
            alert("Delete Failed!");
          }
        )
    }
  };

  public clearForm() {
    this.isEditMode = false;
    this.product = new Product();
  };
}
