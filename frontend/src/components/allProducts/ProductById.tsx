import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getProductById, Product } from "../../clients/apiClient";
import "./ProductById.scss";
import {
  AiFillHeart,
  AiOutlineHeart,
  AiOutlineShoppingCart,
} from "react-icons/ai";

export const ProductById: React.FunctionComponent = () => {
  const [product, setProduct] = useState<Product>();
  const { productId } = useParams<{ productId: string }>();
  const [wishState, setWishState] = useState(false);
  useEffect(() => {
    getProductById(productId).then(setProduct);
  }, [productId]);

  if (product === undefined) {
    return <p>Loading...</p>;
  }

  return (
    <div className="product">
      <h3
        className="product__name"
        dangerouslySetInnerHTML={{ __html: product.productName }}
      ></h3>
      <img
        className="product__image"
        src={product.productImageUrl}
        alt={product.productName}
      />

      <div className="product__price">£{product.pricePerProduct} per piece</div>
      <div className="product__description">{product.productDescription}</div>
      <div className="fieldset">
        <button
          className="product__add-to-wish-list"
          onClick={() => setWishState((current) => !current)}
        >
          {wishState === false ? (
            <AiOutlineHeart size={30} />
          ) : (
            <AiFillHeart size={30} />
          )}
        </button>
        <button className="product__add-cart">
          <AiOutlineShoppingCart size={30} />
        </button>
      </div>
    </div>
  );
};
