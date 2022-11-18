import React, { useState } from "react";
import { Product } from "../../clients/apiClient";
import {
  AiFillHeart,
  AiOutlineHeart,
  AiOutlineShoppingCart,
} from "react-icons/ai";
import { Card } from "../card/Card";
import "./ProductCard.scss";

AiOutlineHeart;
AiFillHeart;

interface ProductCardProps {
  product: Product;
}

export const ProductCard: React.FC<ProductCardProps> = ({ product }) => {
  const [wishState, setWishState] = useState(false);

  return (
    <Card title={product.productName} imageUrl={product.productImageUrl}>
      <div className="product-card__price">
        £{product.pricePerProduct} per piece
      </div>
      <div className="product-card__description">
        {product.productDescription}
      </div>
      <button
        className="product-card__add-to-wish-list"
        onClick={() => setWishState((current) => !current)}
      >
        {wishState === false ? (
          <AiOutlineHeart size={30} />
        ) : (
          <AiFillHeart size={30} />
        )}
      </button>
      <button className="product-card__add-cart">
        <AiOutlineShoppingCart size={30} />
      </button>
    </Card>
  );
};
