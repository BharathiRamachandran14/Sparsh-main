import React, { useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import {
  getProductById,
  Product,
  addToWishList,
  deleteFromWishList,
} from "../../clients/apiClient";
import "./ProductById.scss";
import {
  AiFillHeart,
  AiOutlineHeart,
  AiOutlineShoppingCart,
} from "react-icons/ai";
import { LoginContext } from "../login/LoginManager";
import { Wishlist } from "../wishlist/Wishlist";

export const ProductById: React.FunctionComponent = () => {
  const loginContext = useContext(LoginContext);
  const [product, setProduct] = useState<Product>();
  const { productId } = useParams<{ productId: string }>();
  const { wishListId } = useParams<{ wishListId: string }>();
  const [wishState, setWishState] = useState(false);
  useEffect(() => {
    getProductById(productId).then(setProduct);
  }, [productId]);

  if (product === undefined) {
    return <p>Loading...</p>;
  }

  const addOrDeleteWishListOnClick = () => {
    setWishState((current) => !current);
    if (wishState == true) {
      addToWishList(
        {
          productId: parseInt(productId),
          userId: loginContext.userId,
        },
        loginContext.username,
        loginContext.password
      );
    } // else {
    //   deleteFromWishList(
    //     {
    //       productId: parseInt(productId),
    //       userId: loginContext.userId,
    //     },
    //     loginContext.username,
    //     loginContext.password
    //   );
    // }
  };

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
          onClick={addOrDeleteWishListOnClick}
        >
          {wishState === false ? (
            <AiOutlineHeart size={30} />
          ) : (
            <AiFillHeart size={30} />
          )}
        </button>
        <button className="product__add-cart">
          Add to cart <AiOutlineShoppingCart size={30} />
        </button>
      </div>
    </div>
  );
};
