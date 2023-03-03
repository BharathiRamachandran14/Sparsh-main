import React, { useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import {
  getProductById,
  Product,
  addToWishList,
} from "../../clients/apiClient";
import "./ProductById.scss";
import { AiFillHeart, AiOutlineHeart } from "react-icons/ai";
import { BsCart, BsFillCartCheckFill } from "react-icons/bs";
import { LoginContext } from "../login/LoginManager";
import { WarningPage } from "../warningPage/WarningPage";

export const ProductById: React.FunctionComponent = () => {
  const loginContext = useContext(LoginContext);
  const [product, setProduct] = useState<Product>();
  const { productId } = useParams<{ productId: string }>();
  const [wishState, setWishState] = useState(false);
  const [inCart, setInCart] = useState(false);
  const [loginState, setLoginState] = useState(loginContext.isLoggedIn);

  useEffect(() => {
    getProductById(productId).then(setProduct);
  }, [productId]);

  if (product === undefined) {
    return <p>Loading...</p>;
  }

  const addToWishListOnClick = () => {
    // if (loginState === false) {
    //   return <WarningPage />;
    // }

    setWishState(true);
    addToWishList(
      {
        productId: parseInt(productId),
        userId: loginContext.userId,
      },
      loginContext.username,
      loginContext.password
    );
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
          onClick={addToWishListOnClick}
        >
          {wishState === false ? (
            <AiOutlineHeart size={30} />
          ) : (
            <AiFillHeart size={30} />
          )}
        </button>
        <button className="product__add-cart" onClick={() => setInCart(true)}>
          {inCart === false ? (
            <BsCart size={30} />
          ) : (
            <BsFillCartCheckFill size={30} />
          )}
        </button>
      </div>
    </div>
  );
};
