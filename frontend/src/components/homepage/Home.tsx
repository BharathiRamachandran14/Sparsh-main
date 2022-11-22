import React, { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { getAllProducts, Product } from "../../clients/apiClient";
import { About } from "../about/About";
import { ProductCard } from "../allProducts/ProductCard";
import "./Home.scss";

export const Home: React.FunctionComponent = () => {
  const [products, setProducts] = useState<Product[]>();
  const { productId } = useParams<{ productId: string }>();

  useEffect(() => {
    if (productId === undefined) {
      getAllProducts().then(setProducts);
    }
  }, []);

  if (products === undefined) {
    return <p>Loading.....</p>;
  }

  return (
    <div className="product-container">
      <h1>About</h1>
      <About />
      <h2>PRODUCTS</h2>
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
