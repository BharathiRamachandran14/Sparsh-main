import React, { useContext, useState } from "react";
import { BsCart, BsFillCartCheckFill } from "react-icons/bs";
import { RiDeleteBin5Line } from "react-icons/ri";
import { WishList, deleteFromWishList } from "../../clients/apiClient";
import { Card } from "../card/Card";
import { LoginContext } from "../login/LoginManager";
import "./WishListCard.scss";

interface WishListCardProps {
  wishList: WishList;
  remove: () => void;
}

export const WishListCard: React.FC<WishListCardProps> = ({
  wishList,
  remove,
}) => {
  const loginContext = useContext(LoginContext);
  const [inCart, setInCart] = useState(false);

  const deleteFromWishListOnClick = () => {
    deleteFromWishList(
      wishList.wishListId,
      loginContext.username,
      loginContext.password
    ).then(() => remove());
  };
  return (
    <Card
      title={wishList.item.productName}
      imageUrl={wishList.item.productImageUrl}
    >
      <div className="wishList-card__price">
        £{wishList.item.pricePerProduct} per piece
      </div>
      <button
        className="wishList-card__delete-from-wish-list"
        onClick={deleteFromWishListOnClick}
      >
        <RiDeleteBin5Line size={30} />
      </button>
      <button
        className="wishList-card__add-cart"
        onClick={() => setInCart(true)}
      >
        {inCart === false ? (
          <BsCart size={30} />
        ) : (
          <BsFillCartCheckFill size={30} />
        )}
      </button>
    </Card>
  );
};
