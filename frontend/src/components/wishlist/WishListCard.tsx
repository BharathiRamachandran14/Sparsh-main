import React, { useContext } from "react";
import { AiOutlineShoppingCart } from "react-icons/ai";
import { WishList, deleteFromWishList } from "../../clients/apiClient";
import { Card } from "../card/Card";
import { LoginContext } from "../login/LoginManager";
import { Wishlist } from "./Wishlist";
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
        Remove
      </button>
      <button className="wishList-card__add-cart">
        Add to cart <AiOutlineShoppingCart size={30} />
      </button>
    </Card>
  );
};
