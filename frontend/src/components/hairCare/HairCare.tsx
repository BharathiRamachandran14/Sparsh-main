import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getProductsByType, Product } from "../../clients/apiClient";
import { ProductCard } from "../allProducts/ProductCard";
import "./HairCare.scss";

export const HairCare: React.FunctionComponent = () => {
  const [products, setProducts] = useState<Product[]>();

  useEffect(() => {
    getProductsByType("hair").then(setProducts);
  }, []);

  if (products === undefined) {
    return <p>Loading.....</p>;
  }

  return (
    <div className="hair-product-container">
      <h1>PRODUCTS</h1>
      <div className="product-list">
        {products.map((product) => {
          const productRoute = "/products/" + product.productId;
          return (
            <Link
              className="product__link"
              key={product.productId}
              to={productRoute}
            >
              <ProductCard product={product} />
            </Link>
          );
        })}
      </div>
    </div>
  );
};
