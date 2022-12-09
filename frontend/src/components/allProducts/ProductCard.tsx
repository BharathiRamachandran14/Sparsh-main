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
  return (
    <Card title={product.productName} imageUrl={product.productImageUrl}>
      <div className="product-card__price">
        £{product.pricePerProduct} per piece
      </div>
    </Card>
  );
};
